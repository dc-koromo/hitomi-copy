/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_3.MM;
using MM_Downloader.MM;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmMarumaru : Form
    {
        public frmMarumaru()
        {
            InitializeComponent();
        }

        private void frmMarumaru_Load(object sender, System.EventArgs e)
        {
            foreach (var check in MMUpdate.Instance.reserve)
            {
                checkedListBox1.Items.Add(check.Item3, true);
            }
        }
        
        private void button1_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    int k = i;
                    (Application.OpenForms[0] as frmMain).Post(() => Task.Run(() => (Application.OpenForms[0] as frmMain).DownloadMMAsync(MMUpdate.Instance.reserve[k].Item1, MMUpdate.Instance.reserve[k].Item2)));
                }
            }
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            foreach (var mm in MMSetting.Instance.GetModel().Articles)
            {
                if (mm.NotFound != null && mm.NotFound.Length > 0)
                {
                    mm.NotFound = null;
                    LogEssential.Instance.PushLog(() => $"[MM Setting] Delete 404 '{mm.Title}'");
                }
            }
            MMSetting.Instance.Save();
        }
    }
}
