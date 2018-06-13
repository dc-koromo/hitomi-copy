﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Hitomi_Copy_2
{
    public class HitomiQueue
    {
        public int capacity = 32;
        int mtx = 0;
        List<Tuple<string, string, object>> queue = new List<Tuple<string, string, object>>();
        List<Tuple<string,HttpWebRequest>> requests = new List<Tuple<string, HttpWebRequest>>();
        List<string> aborted = new List<string>();
        public IWebProxy proxy { get; set; }

        public bool timeout_infinite = true;
        public int timeout_ms = 10000;

        public delegate void CallBack(string uri, string filename, object obj);
        public delegate void DownloadSizeCallBack(string uri, long size);
        public delegate void DownloadStatusCallBack(string uri, int size);
        public delegate void RetryCallBack(string uri);

        CallBack callback;
        DownloadSizeCallBack download_callback;
        DownloadStatusCallBack status_callback;
        RetryCallBack retry_callback;

        object int_lock = new object();
        object notify_lock = new object();

        public HitomiQueue(CallBack notify, DownloadSizeCallBack notify_size, DownloadStatusCallBack notify_status, RetryCallBack retry)
        {
            capacity = HitomiSetting.Instance.GetModel().Thread;
            ServicePointManager.DefaultConnectionLimit = 128;
            callback = notify;
            download_callback = notify_size;
            status_callback = notify_status;
            retry_callback = retry;
            proxy = null;
        }

        public void DownloadRemoteImageFile(string uri, string fileName, object obj)
        {
        RETRY:
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36";

            request.Timeout = timeout_infinite ? Timeout.Infinite : timeout_ms;
            request.KeepAlive = true;
            request.Proxy = proxy;

            lock (requests) requests.Add(new Tuple<string, HttpWebRequest>(uri,request));

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if ((response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Moved ||
                    response.StatusCode == HttpStatusCode.Redirect) &&
                    response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {
                    using (Stream inputStream = response.GetResponseStream())
                    using (Stream outputStream = File.OpenWrite(fileName))
                    {
                        byte[] buffer = new byte[131072];
                        int bytesRead;
                        lock (download_callback) download_callback(uri, response.ContentLength);
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                            lock (status_callback) status_callback(uri, bytesRead);
                        } while (bytesRead != 0);
                    }
                }
            }
            catch
            {
                lock (aborted)
                    if (!aborted.Contains(uri))
                    {
                        lock (retry_callback) retry_callback(uri);
                        request.Abort();
                        goto RETRY;
                    }
                    else
                    {
                        lock (callback) callback(uri, fileName, obj);
                        return;
                    }
            }

            lock (callback) callback(uri, fileName, obj);

            lock (queue)
            {
                int at = 0;
                for (; at < queue.Count; at++)
                    if (queue[at].Item1 == uri && queue[at].Item2 == fileName)
                        break;
                if (at != queue.Count) queue.RemoveAt(at);
            }

            lock (int_lock) mtx--;
            lock (notify_lock) Notify();
        }

        public bool Abort(string uri)
        {
            lock (queue)
            {
                for (int i = 0; i < queue.Count; i++)
                    if (queue[i].Item1 == uri)
                    {
                        queue.RemoveAt(i);
                        lock (int_lock) mtx--;
                        lock (notify_lock) Notify();
                        break;
                    }
            }
            lock (requests)
            {
                foreach (var i in requests)
                    if (i.Item1 == uri)
                        lock(i.Item2) i.Item2.Abort();
            }
            aborted.Add(uri);
            return false;
        }

        public void Add(string uri, string filename, object obj)
        {
            queue.Add(new Tuple<string, string, object>(uri, filename, obj));
            if (Wait())
                lock (notify_lock) Notify();
        }

        private void Notify()
        {
            int i = mtx;
            if (queue.Count > i)
            {
                string s1 = queue[i].Item1;
                string s2 = queue[i].Item2;
                object s3 = queue[i].Item3;
                Task.Run(() => DownloadRemoteImageFile(s1, s2, s3));
                lock (int_lock) mtx++;
            }
        }

        private bool Wait()
        {
            if (mtx == capacity)
                return false;
            return true;
        }
    }
}
