/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Windows.Forms;

namespace Hitomi_Copy_3.MM
{
    public class MMUpdateChecker
    {
        private static readonly Lazy<MMUpdateChecker> instance = new Lazy<MMUpdateChecker>(() => new MMUpdateChecker());
        public static MMUpdateChecker Instance => instance.Value;

        private void ShowMarumaruManager()
        {
            Application.OpenForms[0].Post(() => (new frmMarumaru()).Show());
        }
    }
}
