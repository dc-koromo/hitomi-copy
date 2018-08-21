/* Copyright (C) 2018. Hitomi Parser Developers */

using Pixeez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hitomi_Copy_3.Etc
{
    /// <summary>
    /// Pixiv download support
    /// </summary>
    public class Pixiv
    {
        private static readonly Lazy<Pixiv> instance = new Lazy<Pixiv>(() => new Pixiv());
        public static Pixiv Instance => instance.Value;

        /// <summary>
        /// 히토미 카피는 외부 개발자에 의해 픽시브 아이디가 탈퇴되는 것을 방지하기 아이디/비밀번호를 노출하지 않습니다.
        /// </summary>
        public string DefaultUserId => Login.Login.Instance.GetPixivID();
        public string DefaultPassword => Login.Login.Instance.GetPixivPW();

        Tokens token => Auth.AuthorizeAsync(DefaultUserId, DefaultPassword).Result;
        
        public async Task<string> GetUserAsync(string id)
        {
            var user = await token.GetUsersAsync(Convert.ToInt32(id));
            return $"{user[0].Name} ({user[0].Account})";
        }

        public async Task<List<string>> GetDownloadUrlsAsync(string id)
        {
            var works = await token.GetUsersWorksAsync(Convert.ToInt32(id), 1, 10000000);
            return works.Select(x => x.ImageUrls.Large).ToList();
        }
    }
}
