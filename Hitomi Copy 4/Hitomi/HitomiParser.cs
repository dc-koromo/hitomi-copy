/* Copyright (C) 2018. Hitomi Parser Developers */

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hitomi_Copy_4.Hitomi
{
    public class HitomiParser
    {
        /// <summary>
        /// 갤러리 블록으로 썸네일 파싱
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static public HitomiArticle ParseGallery(string source)
        {
            HitomiArticle article = new HitomiArticle();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(source);
            HtmlNode nodes = document.DocumentNode.SelectNodes("//div")[0];

            article.Thumbnail = nodes.SelectSingleNode(".//a//div//img").GetAttributeValue("src", "").Substring("//tn.hitomi.la/".Length);

            return article;
        }

        // Current Settings
        //--------- Block 1
        //    <a href = "/galleries/1189352.html" >< div class="dj-img-cont">
        //        <div class="dj-img1"> <img src = "//tn.hitomi.la/bigtn/1189352/1.jpg.jpg" > </ div >
        //        < div class="dj-img2"> <img src = "//tn.hitomi.la/bigtn/1189352/13.jpg.jpg" > </ div >
        // 
        //         < div class="dj-img-back"></div>
        //    </div></a>
        //--------- Block 2
        //    <h1><a href = "/galleries/1189352.html" > Scorched Girl Kouhen</a></h1>
        //    <div class="artist-list"><ul>
        //            
        //            <li><a href = "/artist/monorino-all-1.html" > monorino </ a ></ li >
        //            </ul>
        //
        //    </div>
        //--------- Block 3
        //    <div class="dj-content">
        //        <table class="dj-desc">
        //        <tr><td>Series</td>
        //        <td>
        //        N/A
        //        </td>
        //        </tr>
        //        <tr><td>Type</td><td><a href = "/type/manga-all-1.html" > manga </ a ></ td ></ tr >
        //        < tr >< td > Language </ td >< td >< a href="/index-chinese-1.html">中文</a></td></tr>
        //        <tr><td>Tags</td><td class="relatedtags"><ul>
        //                                                <li><a href = "/tag/female%3Aanal-all-1.html" > anal ♀</a></li>
        //                                                
        //                                                <li><a href = "/tag/female%3Abig%20breasts-all-1.html" > big breasts ♀</a></li>
        //                                                
        //                                                <li><a href = "/tag/female%3Acollar-all-1.html" > collar ♀</a></li>
        //                                                
        //                                                <li><a href = "/tag/female%3Aexhibitionism-all-1.html" > exhibitionism ♀</a></li>
        //                                                
        //                                                <li><a href = "/tag/full%20censorship-all-1.html" > full censorship</a></li>
        //                                                
        //                                                <li><a href = "/tag/group-all-1.html" > group </ a ></ li >
        //
        //
        //                                          </ ul >
        //        </ td ></ tr >
        //        </ table >
        //        < p class="manga-date date">2018-03-01 23:36:00-06</p>
        //    </div>
        //---------
        const string article_block = @"(<a href=""/galleries/[\s\S]*?</div>[\s\S]*?</a>)[\s\S]*?(<h1><a href=""/galleries/[\s\S]*?</div>)[\s\S]*?(<div class=[\s\S]*?</div>)";
        // {magic, thumbnail}
        const string block1_magic = @"<a href=""/galleries/(.*?)\.html";
        const string block1_thumbnail = @"<img src=""//tn.hitomi.la/(.*?)"">";
        // {title, artist}
        const string block2_title = @"html"">(.*?)</a></h1>";
        const string block2_artist = @"<div class=""artist-list""><ul>([\s\S]*?)</div>";
        // {series, type, language, tags}
        const string block3_series = @"<tr><td>Series</td>[\s\S]*?<td>([\s\S]*?)</td>";
        const string block3_type = @"<tr><td>Type</td><td><a href=""/type/.*?"">(.*?)</a>";
        const string block3_language = @"<tr><td>Language</td><td><a href=""/.*?"">(.*?)</a>";
        const string block3_tags = @"<li><a href=""/tag/.*?"">(.*?)</a>";
        const string block3_date = @"date"">(.*?)</p>";
        static private string getMatch1(string pattern, string source)
        {
            Regex regex = new Regex(pattern, RegexOptions.Multiline);
            Match match = regex.Match(source);
            return match.Groups[1].Value;
        }
        static private string artist_legalize(string what)
        {
            StringBuilder builder = new StringBuilder();
            if (!what.Contains(@"<li><a href=""/artist/")) return "N/A";
            return getMatch1(@"<li><a href=""/artist/.*?"">(.*?)</a>", what);
        }
        static private string series_legalize(string what)
        {
            StringBuilder builder = new StringBuilder();
            if (!what.Contains(@"<li><a href=""")) return "N/A";
            return getMatch1(@"<li><a href=""/series/.*?"">(.*?)</a>", what);
        }
        static public string replaceEntity(string str)
        {
            string strs = str;
            string[] oj = {"&nbsp;", "&amp;", "&quot;", "&lt;",
                "&gt;", "&reg;", "&copy;", "&bull;", "&trade;", "&#39;" };
            string[] kj = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢", "'" };
            for (int i = 0; i <= oj.Length - 1; i++)
            {
                strs = strs.Replace(oj[i], kj[i]);
            }
            return strs;
        }
        static public List<HitomiArticle> ParseArticles(string source)
        {
            List<HitomiArticle> result = new List<HitomiArticle>();
            // Get total blocks
            Regex regex = new Regex(article_block, RegexOptions.Multiline);
            Match match = regex.Match(source);

            while (match.Success)
            {
                HitomiArticle article = new HitomiArticle();

                string block1 = match.Groups[1].Value;
                article.Magic = getMatch1(block1_magic, block1);
                article.Thumbnail = getMatch1(block1_thumbnail, block1);

                string block2 = match.Groups[2].Value;
                article.Title = replaceEntity(getMatch1(block2_title, block2));
                article.OriginalTitle = article.Title;
                article.Artists = new string[] { artist_legalize(getMatch1(block2_artist, block2)) }; // get only first artist

                string block3 = match.Groups[3].Value;
                article.Series = new string[] { series_legalize(getMatch1(block3_series, block3)) };
                article.Types = getMatch1(block3_type, block3);
                article.Language = getMatch1(block3_language, block3);
                article.DateTime = DateTime.Parse(getMatch1(block3_type, block3));

                Regex regex_tags = new Regex(block3_tags, RegexOptions.Multiline);
                Match match_tags = regex_tags.Match(block3);
                List<string> tags = new List<string>();
                while (match_tags.Success)
                {
                    tags.Add(match_tags.Groups[1].Value);
                    match_tags = match_tags.NextMatch();
                }
                article.Tags = tags.ToArray();

                result.Add(article);
                match = match.NextMatch();
            }

            return result;
        }
    }
}