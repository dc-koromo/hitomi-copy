/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Package
{
    public partial class PackageElement : UserControl
    {
        PackageElementModel pem;

        public PackageElement(PackageElementModel pem)
        {
            InitializeComponent();

            Size = new Size(1096, 119);
            textBox1.BackColor = Color.White;
            this.pem = pem;
        }
        
        bool Expand = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Expand == false)
                Size = new Size(1096, 430);
            else
                Size = new Size(1096, 119);
            button1.Text = Expand ? "+" : "-";
            Expand = !Expand;
        }

        Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();
        Dictionary<string, List<string>> artists = new Dictionary<string, List<string>>();
        
        private void PackageElement_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(pem.ImageLink);
            label1.Text = pem.Name;
            textBox1.Text = pem.Description;
            label2.Text = $"작성자 : {pem.Nickname} ({pem.LatestUpdate.ToShortDateString()})";

            AddToListGroups(listView1, pem.Artists);
        }
        
        private void AddToListGroups(ListView lv, List<Tuple<string, string>> contents)
        {
            ListViewGroup lvg = new ListViewGroup("미분류");
            groups.Add("미분류", lvg);
            artists.Add("미분류", new List<string>());
            foreach (var content in contents)
                if (!groups.ContainsKey(content.Item1 ?? "미분류"))
                {
                    ListViewGroup lvgt = new ListViewGroup(content.Item1 ?? "미분류");
                    groups.Add(content.Item1, lvgt);
                    artists.Add(content.Item1, new List<string>());
                    lv.Groups.Add(lvgt);
                }
            lv.Groups.Add(lvg);
            for (int i = 0; i < contents.Count; i++)
            {
                int index = contents.Count - i - 1;
                lv.Items.Add(new ListViewItem(new string[] {
                    contents[index].Item2
                }, groups[contents[index].Item1 ?? "미분류"]));
                artists[contents[index].Item1 ?? "미분류"].Add(contents[index].Item2);
            }
        }

        private async void listView1_MouseDoubleClickAsync(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (var iw in info.Where(iw => iw != null))
                    iw.Dispose();
                info = null;
                info = new InfoWrapper[4];
                LogEssential.Instance.PushLog(() => $"Successful disposed! [RecommendControl] {artist}");
                artist = listView1.SelectedItems[0].SubItems[0].Text.Replace('_', ' ');
                pb1.Image = null;
                pb2.Image = null;
                pb3.Image = null;
                pb4.Image = null;
                await LoadThumbnailAsync();
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }

        #region 작가 이미지 처리

        InfoWrapper[] info = new InfoWrapper[4];
        bool closed = false;
        string artist;

        private void OnDispose(object sender, EventArgs e)
        {
            foreach (var iw in info.Where(iw => iw != null))
                iw.Dispose();
            LogEssential.Instance.PushLog(() => $"Successful disposed! [RecommendControl] {artist}");
            closed = true;
        }
        
        private async Task LoadThumbnailAsync()
        {
            List<string> titles = new List<string>();
            List<string> magics = new List<string>();

            for (int i = 0, j = 0; i < 5 && j < HitomiData.Instance.metadata_collection.Count; j++)
            {
                if (HitomiData.Instance.metadata_collection[j].Artists != null &&
                   (HitomiData.Instance.metadata_collection[j].Language == HitomiSetting.Instance.GetModel().Language || HitomiSetting.Instance.GetModel().Language == "ALL") &&
                    HitomiData.Instance.metadata_collection[j].Artists.Contains(artist))
                {
                    string ttitle = HitomiData.Instance.metadata_collection[j].Name.Split('|')[0];
                    if (titles.Count > 0 && !titles.TrueForAll((title) => StringAlgorithms.get_diff(ttitle, title) > HitomiSetting.Instance.GetModel().TextMatchingAccuracy)) continue;

                    titles.Add(ttitle);
                    magics.Add(HitomiData.Instance.metadata_collection[j].ID.ToString());
                    i++;
                }
            }

            if (HitomiSetting.Instance.GetModel().DetailedLog)
            {
                LogEssential.Instance.PushLog(() => $"This images will be loaded. [RecommendControl]");
                LogEssential.Instance.PushLog(magics);
            }

            for (int i = 0; i < magics.Count; i++)
            {
                _ = Task.Factory.StartNew(x => {
                    int ix = (int)x;
                    try { AddMetadataToPanel(ix, magics[ix]); } catch { }
                }, i);
            }
        }

        private void RemoveEvent(PictureBox pb, string event_name)
        {
            FieldInfo f1 = typeof(Control).GetField(event_name,
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(pb);
            PropertyInfo pi = pb.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(pb, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void AddMetadataToPanel(int i, string id)
        {
            string thumbnail = HitomiCore.GetThumbnailAddress(id);

            string temp = Path.GetTempFileName();
            WebClient wc = new WebClient();
            wc.Headers["Accept-Encoding"] = "application/x-gzip";
            wc.Encoding = Encoding.UTF8;
            wc.DownloadFile(new Uri(HitomiDef.HitomiThumbnail + thumbnail), temp);

            Image img;
            using (FileStream fs = new FileStream(temp, FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose))
            {
                img = Image.FromStream(fs);
            }
            if (closed)
            {
                img.Dispose();
                LogEssential.Instance.PushLog(() => $"Unexpected Disposed! {HitomiDef.HitomiThumbnail + thumbnail} {temp} {i} {id}");
                return;
            }
            info[i] = new InfoWrapper(img.Clone() as Image);

            PictureBox[] pbs = { pb1, pb2, pb3, pb4 };
            RemoveEvent(pbs[i], "EventMouseEnter");
            RemoveEvent(pbs[i], "EventMouseMove");
            RemoveEvent(pbs[i], "EventMouseLeave");
            pbs[i].MouseEnter += info[i].Picture_MouseEnter;
            pbs[i].MouseMove += info[i].Picture_MouseMove;
            pbs[i].MouseLeave += info[i].Picture_MouseLeave;

            if (pbs[i].InvokeRequired)
                pbs[i].Invoke(new Action(() => { pbs[i].Image = img; }));
            else
                pbs[i].Image = img;

            LogEssential.Instance.PushLog(() => $"Load successful! {HitomiDef.HitomiThumbnail + thumbnail} {temp} {i} {id}");
        }

        #endregion

        private void 작가추천목록에서보기VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in pem.Artists)
            {
                string artist = item.Item2.Replace('_', ' ');
                (Application.OpenForms[0] as frmMain).AddRecommendArtist(artist);
            }
            (Application.OpenForms[0] as frmMain).RecommendFocus();
        }

        private void bDetail_Click(object sender, EventArgs e)
        {
            (new frmArtistInfo(artist)).Show();
        }
    }
}
