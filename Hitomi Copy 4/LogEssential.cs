/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using System;

namespace Hitomi_Copy_4.Log
{
    public class LogEssential
    {
        private static readonly Lazy<LogEssential> instance = new Lazy<LogEssential>(() => new LogEssential());
        public static LogEssential Instance => instance.Value;
    }
}
