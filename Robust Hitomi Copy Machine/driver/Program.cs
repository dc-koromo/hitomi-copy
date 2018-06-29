/* Copyright (C) 2018. Hitomi Parser Developer */

using System;
using System.IO;
using System.Net;
using System.Threading;

namespace driver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Image download driver");
                Console.WriteLine("Copyright (C) 2018. Hitomi Parser Developer");
                Console.WriteLine("");
                Console.WriteLine("  - driver.exe [path] [url]");
                return;
            }
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args[1]);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36";
            if (args[1].Contains("wasabisyrup.com")) request.Referer = "http://wasabisyrup.com/archives/";

            request.Timeout = Timeout.Infinite;
            request.KeepAlive = true;
            
            try
            {
                int total_bytes = 0;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if ((response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Moved ||
                    response.StatusCode == HttpStatusCode.Redirect) &&
                    response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {
                    using (Stream inputStream = response.GetResponseStream())
                    using (Stream outputStream = File.OpenWrite(args[0]))
                    {
                        byte[] buffer = new byte[131072];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                            total_bytes += bytesRead;
                        } while (bytesRead != 0);
                    }
                }
                Environment.Exit(total_bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured! {e.Message}");
                Environment.Exit(-1);
            }
        }
    }
}
