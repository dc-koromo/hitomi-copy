/* Copyright (C) 2018. Hitomi Parser Developer */

using hitomi.Parser;
using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2.GalleryInfo;
using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Hitomi_Copy_2
{
    public class HitomiCore
    {
        public delegate void CallBack(IPicElement pe);
        
        static public void DownloadAndSetImageLink(IPicElement pe, CallBack callback)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.DownloadStringCompleted += wc_dasil;
            wc.DownloadStringAsync(new Uri(HitomiDef.HitomiGalleryAddress + pe.Article.Magic + ".js"),
                new Tuple<IPicElement, CallBack>(pe, callback));
        }
        static private void wc_dasil(object sender, DownloadStringCompletedEventArgs e)
        {
            Tuple<IPicElement, CallBack> tuple = (Tuple<IPicElement, CallBack>)e.UserState;
            
            try
            {
                tuple.Item1.Article.ImagesLink = HitomiGalleryInfo.GetImageLink(e.Result);
                lock (tuple.Item2)
                {
                    tuple.Item2(tuple.Item1);
                }
            }
            catch
            {
                Thread.Sleep(1000);
                DownloadAndSetImageLink(tuple.Item1, tuple.Item2);
            }
        }

        static public string GetThumbnailAddress(string id)
        {
            try
            {
                if (HitomiData.Instance.thumbnail_collection.ContainsKey(id))
                    return HitomiData.Instance.thumbnail_collection[id];
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                return HitomiParser.ParseGallery2(wc.DownloadString(
                    new Uri($"{HitomiDef.HitomiGalleryBlock}{id}.html"))).Thumbnail;
            }
            catch { }
            return "";
        }

        static public int GetPageCount(IPicElement pe)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.DownloadStringCompleted += wc_dasil;
            return HitomiGalleryInfo.GetImageLink(wc.DownloadString(new Uri(HitomiDef.HitomiGalleryAddress + pe.Article.Magic + ".js"))).Count;
        }

        static public int GetPageCount(string magic)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.DownloadStringCompleted += wc_dasil;
            return HitomiGalleryInfo.GetImageLink(wc.DownloadString(new Uri(HitomiDef.HitomiGalleryAddress + magic + ".js"))).Count;
        }
    }
}
