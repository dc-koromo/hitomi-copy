/* Copyright (C) 2018. Hitomi Parser Developers */

using System;

namespace Hitomi_Copy_3
{
    public class NoticeReceiver
    {
        public const string NoticeUrl = @"https://raw.githubusercontent.com/dc-koromo/hitomi-downloader-2/master/notice";

        static public bool NoticeRequired()
        {
            string version_text;
            using (var wc = new System.Net.WebClient())
                version_text = wc.DownloadString(NoticeUrl);

            string[] lines = version_text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            LogEssential.Instance.PushLog(() => "Recieving notice text");
            LogEssential.Instance.PushLog(lines);
            
            return false;
        }

    }
}
