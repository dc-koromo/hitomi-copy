/* Copyright (C) 2018. Hitomi Parser Developer */

using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Hitomi_Copy_3
{
    /// <summary>
    /// Semaphore for Hitomi Copy Downloader
    /// </summary>
    public class DriverManager : ISemaphore
    {
        public int capacity = 12;
        public int mutex = 0;

        public List<Tuple<string, string, object>> queue = new List<Tuple<string, string, object>>();
        public List<string> aborted = new List<string>();

        object int_lock = new object();
        object notify_lock = new object();

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

        public int Capacity { get { return capacity; } set { capacity = value; } }

        public DriverManager(CallBack notify, DownloadSizeCallBack notify_size, DownloadStatusCallBack notify_status, RetryCallBack retry)
        {
            // Set capacity to processor threads count
            capacity = HitomiSetting.Instance.GetModel().Thread;
            ServicePointManager.DefaultConnectionLimit = 1048576;
            callback = notify;
            download_callback = notify_size;
            status_callback = notify_status;
            retry_callback = retry;
        }

        private static Process CreateProcess(string url, string path)
        {
            ProcessStartInfo processInfo;
            Process process;
            processInfo = new ProcessStartInfo("driver.exe", $"\"{path}\" \"{url}\"");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            process = Process.Start(processInfo);
            LogEssential.Instance.PushLog(() => $"driver.exe \"{path}\" \"{url}\"");
            return process;
        }

        private void AddArticle(string uri, string fileName, object obj)
        {
        RETRY:
            Process process = CreateProcess(uri, fileName);
            process.WaitForExit();
            int exitCode = process.ExitCode;
            process.Close();
            LogEssential.Instance.PushLog(() => $"process terminated {uri} {exitCode}");
            
            if (exitCode == -1)
            {
                lock (aborted)
                    if (!aborted.Contains(uri))
                    {
                        lock (retry_callback) retry_callback(uri);
                        Thread.Sleep(10000);
                        goto RETRY;
                    }
                    else
                    {
                        lock (callback) callback(uri, fileName, obj);
                        return;
                    }
            }
            else
            {
                lock (download_callback) download_callback(uri, exitCode);
                lock (status_callback) status_callback(uri, exitCode);
            }

            lock (callback) callback(uri, fileName, obj);

            lock (queue)
            {
                int at = 0;
                for (; at < queue.Count; at++) if (queue[at].Item1 == uri && queue[at].Item2 == fileName) break;
                if (at != queue.Count) queue.RemoveAt(at);
            }

            lock (int_lock) mutex--;
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
                        lock (int_lock) mutex--;
                        lock (notify_lock) Notify();
                        break;
                    }
            }
            aborted.Add(uri);
            return false;
        }

        public void Abort()
        {
            lock (queue)
            {
                aborted.AddRange(queue.Select(x => x.Item1));
                queue.Clear();
            }
        }

        public void Add(string uri, string filename, object obj)
        {
            queue.Add(new Tuple<string, string, object>(uri, filename, obj));
            if (Wait()) lock (notify_lock) Notify();
        }

        private void Notify()
        {
            int i = mutex;
            if (queue.Count > i)
            {
                string uri = queue[i].Item1;
                string path = queue[i].Item2;
                object obj = queue[i].Item3;
                Task.Run(() => AddArticle(uri, path, obj));
                lock (int_lock) mutex++;
            }
        }

        private bool Wait()
        {
            if (mutex == capacity)
                return false;
            return true;
        }
    }
}
