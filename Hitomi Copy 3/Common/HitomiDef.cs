/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Linq;

namespace hitomi.Parser
{
    public class HitomiDef
    {
        /*
         * Hitomi Defines
         */
        public const string HitomiAddress = @"https://hitomi.la/";
        public const string HitomiGalleryAddress = @"https://ltn.hitomi.la/galleries/";
        public const string HitomiGalleryBlock = @"https://ltn.hitomi.la/galleryblock/";
        public const string HitomiReaderAddress = @"https://hitomi.la/reader/";
        public const string HitomiThumbnail = @"https://tn.hitomi.la/";
        
        public static string GetDownloadImageAddress(
            string gallery,
            string page_with_extension)
        {
            // download.js
            var number_of_frontends = 2;
            char subdomain = Convert.ToChar(97 + (Convert.ToInt32(gallery.Last()) % number_of_frontends));
            if (gallery.Last() == '1')
                subdomain = 'a';
            return $"https://{subdomain}a.hitomi.la/galleries/{gallery}/{page_with_extension}";
        }
    }
}
