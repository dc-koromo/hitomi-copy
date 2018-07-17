/* Copyright (C) 2018. Hitomi Parser Developers */

using System;

namespace Hitomi_Copy_4
{
    public class LogEssential
    {
        private static readonly Lazy<LogEssential> instance = new Lazy<LogEssential>(() => new LogEssential());
        public static LogEssential Instance => instance.Value;
    }
}
