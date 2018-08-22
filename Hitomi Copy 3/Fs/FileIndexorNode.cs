/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hitomi_Copy_3.Fs
{
    public class FileIndexorNode
    {
        string now_path;
        UInt64 size;
        UInt64 this_size;
        List<FileIndexorNode> nodes = new List<FileIndexorNode>();
        List<FileInfo> files;

        public string Path { get { return now_path; } }
        public UInt64 Size { get { return size; } set { size = value; } }
        public UInt64 ThisSize { get { return this_size; } }
        public List<FileIndexorNode> Nodes { get { return nodes; } }
        public List<FileInfo> Files { get { return files; } }

        public FileIndexorNode(string path, UInt64 size, bool listing_files = false)
        {
            now_path = path;
            this.this_size = this.size = size;
            if (listing_files)
            {
                files = new List<FileInfo>();
                Task.Run(() =>
                {
                    foreach (FileInfo f in new DirectoryInfo(path).GetFiles())
                        files.Add(f);
                });
            }
        }

        public void AddItem(FileIndexorNode node)
        {
            nodes.Add(node);
        }

        public bool Exist(string path)
        {
            foreach (FileIndexorNode n in nodes)
                if (n.Path == path)
                    return true;
            return false;
        }

        public UInt64 GetTotalSize()
        {
            UInt64 v = this_size;
            foreach (FileIndexorNode fin in nodes)
                v += fin.GetTotalSize();
            return v;
        }

        public List<FileIndexorNode> GetListSortWithSize()
        {
            List<FileIndexorNode> r = new List<FileIndexorNode>(nodes);
            r.Sort((n1, n2) => n2.Size.CompareTo(n1.Size));
            return r;
        }

        public DateTime LastFileAccessTime()
        {
            return new DirectoryInfo(now_path).GetFiles()
                .OrderByDescending(f => f.LastWriteTime).First().LastAccessTime;
        }

        public DateTime LastAccessTime()
        {
            return new DirectoryInfo(now_path).GetFileSystemInfos()
                .OrderByDescending(f => f.LastWriteTime).First().LastAccessTime;
        }
    }
}