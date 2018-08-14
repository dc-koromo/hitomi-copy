/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using System;
using System.Globalization;

namespace Hitomi_Copy_4.Log
{
    public class LogEssential
    {
        private static readonly Lazy<LogEssential> instance = new Lazy<LogEssential>(() => new LogEssential());
        public static LogEssential Instance => instance.Value;

        public void PushLog(Func<string> str)
        {
            if (Settings.Instance.GetModel().UsingLog)
            {
                CultureInfo en = new CultureInfo("en-US");
                //my_log.PushString($"[{DateTime.Now.ToString(en)}] {str()}");
            }
        }

        public void PushLog(object obj)
        {
            if (Settings.Instance.GetModel().UsingLog)
            {
                PushLog(() => obj.ToString());
                //my_log.PushString(SerializeObject(obj));
            }
        }

    }
}
