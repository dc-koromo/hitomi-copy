/* Copyright (C) 2018. Hitomi Parser Developer */

namespace Hitomi_Copy_3
{
    public interface ISemaphore
    {
        int Capacity { get; set; }
        bool Abort(string uri);
        void Abort();
        void Add(string uri, string filename, object obj);
    }
}
