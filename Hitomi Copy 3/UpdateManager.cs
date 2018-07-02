/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public class UpdateManager
    {
        public const string Version = "3.28";
        public const string UpdateCheckUrl = @"https://raw.githubusercontent.com/dc-koromo/hitomi-downloader-2/master/version";

        static public string NewestVersionUrl;

        static public bool UpdateRequired()
        {
            string version_text;
            using (var wc = new System.Net.WebClient())
                version_text = wc.DownloadString(UpdateCheckUrl);

            string[] lines = version_text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            LogEssential.Instance.PushLog(() => "Recieving update text");
            LogEssential.Instance.PushLog(lines);

            NewestVersionUrl = lines[2];

            int checking_major = Convert.ToInt32(lines[0].Split('.')[0]);
            int checking_minor = Convert.ToInt32(lines[0].Split('.')[1]);

            int now_major = Convert.ToInt32(Version.Split('.')[0]);
            int now_minor = Convert.ToInt32(Version.Split('.')[1]);
            
            if (checking_major > now_major) return true;
            if (checking_major < now_major) return false; // error
            if (checking_minor > now_minor) return true;

            UpdateFileTidy();

            return false;
        }

        static public void UpdateFileTidy()
        {
            string now_fpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (File.Exists(now_fpath + ".tmp"))
            {
                File.Delete(now_fpath + ".tmp");
                Application.OpenForms[0].Invoke((MethodInvoker)delegate () { (new PatchNote()).Show(); });
            }
        }

        static public void UpdateProgram()
        {
            string temp = Path.GetTempFileName();

            using (var wc = new System.Net.WebClient())
                wc.DownloadFile(NewestVersionUrl, temp);

            string now_fpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            File.Move(now_fpath, now_fpath + ".tmp");
            File.Move(temp, now_fpath);

            Process.Start(now_fpath);
            Application.Exit();
        }
    }
}
