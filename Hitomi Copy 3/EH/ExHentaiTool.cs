/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Hitomi_Copy_3.EH
{
    public class ExHentaiTool
    {
        public static string GetAddressFromMagicTitle(string magic, string title)
        {
            string search_url = $"https://exhentai.org/?f_search={title}&page=0";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Cookie, "igneous=30e0c0a66;ipb_member_id=2742770;ipb_pass_hash=6042be35e994fed920ee7dd11180b65f;");
            string html = wc.DownloadString(search_url);
            if (html.Contains($"/{magic}/"))
                return Regex.Match(html, $"(https://exhentai.org/g/{magic}/\\w+/)").Value;
            return "";
        }
    }
}
