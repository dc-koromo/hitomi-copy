/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using Hitomi_Copy_4.Interface;
using System;
using System.Collections.Generic;
using System.Net;

namespace Hitomi_Copy_4.Net
{
    public class DownloadQueue : ISemaphore
    {
        public int capacity = 32;
        public int mtx = 0;
        public List<Tuple<string, string, object>> queue = new List<Tuple<string, string, object>>();
        public List<Tuple<string, HttpWebRequest>> requests = new List<Tuple<string, HttpWebRequest>>();
        public List<string> aborted = new List<string>();
        public IWebProxy proxy { get; set; }

        public bool timeout_infinite = true;
        public int timeout_ms = 10000;

        public bool shutdown = false;
        
        public int Capacity { get { return capacity; } set { capacity = value; } }

        public bool Abort(string url)
        {
            return true;
        }

        public void Abort()
        {
        }

        public void Add(string url, string path, object obj, SemaphoreCallBack callback, SemaphoreExtends se = null)
        {
        }
    }
}
