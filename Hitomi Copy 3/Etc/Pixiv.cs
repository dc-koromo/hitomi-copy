/* Copyright (C) 2018. Hitomi Parser Developers */

using Pixeez;
using System;

namespace Hitomi_Copy_3.Etc
{
    /// <summary>
    /// Pixiv download support
    /// </summary>
    public class Pixiv
    {
        private static readonly Lazy<Pixiv> instance = new Lazy<Pixiv>(() => new Pixiv());
        public static Pixiv Instance => instance.Value;

        public string DefaultUserId = "koromo.software@gmail.com";
        public string DefaultPassword = "kawaikoromo";

        Tokens token => Auth.AuthorizeAsync(DefaultUserId, DefaultPassword).Result;
    }
}
