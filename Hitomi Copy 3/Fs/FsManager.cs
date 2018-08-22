/* Copyright (C) 2018. Hitomi Parser Developers */

using Etier.IconHelper;
using hitomi.Parser;
using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Fs
{
    public partial class FsManager : Form
    {
        ImageList smallImageList = new ImageList();
        ImageList largeImageList = new ImageList();
        IconListManager iconListManager;
        FileIndexor fi;

        public FsManager()
        {
            InitializeComponent();

            smallImageList.ColorDepth = ColorDepth.Depth32Bit;
            largeImageList.ColorDepth = ColorDepth.Depth32Bit;

            smallImageList.ImageSize = new System.Drawing.Size(16, 16);
            largeImageList.ImageSize = new System.Drawing.Size(32, 32);

            smallImageList.Images.Add(FileIcon.FolderIcon.GetFolderIcon(
                FileIcon.FolderIcon.IconSize.Small,
                FileIcon.FolderIcon.FolderType.Closed));

            iconListManager = new IconListManager(smallImageList, largeImageList);

            PathTree.ImageList = smallImageList;
        }

        private void FsManager_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(AvailableList);

            string[] splits = HitomiSetting.Instance.GetModel().Path.Split('\\');
            string path = "";
            for (int i = 0; i < splits.Length; i++)
            {
                if (!(splits[i].Contains("{") && splits[i].Contains("}")))
                    path += splits[i] + "\\";
                else
                    break;
            }
            tbPath.Text = path;
            textBox2.BackColor = Color.White;
        }

        #region 파일 시스템 리스팅

        private async void bOpen_ClickAsync(object sender, EventArgs e)
        {
            fi = null;
            fi = new FileIndexor();
            PathTree.Nodes.Clear();
            AvailableList.Items.Clear();

            LogEssential.Instance.PushLog(() => $"[Fs Manager] Open directory '{tbPath.Text}'");
            await fi.ListingDirectoryAsync(tbPath.Text);
            LogEssential.Instance.PushLog(() => $"[Fs Manager] Complete open! DirCount={fi.Count}");

            listing(fi);
        }

        private void listing(FileIndexor fi)
        {
            FileIndexorNode node = fi.GetRootNode();
            foreach (FileIndexorNode n in node.Nodes)
            {
                make_node(PathTree.Nodes, Path.GetFileName(n.Path.Remove(n.Path.Length - 1)));
                make_tree(n, PathTree.Nodes[PathTree.Nodes.Count - 1]);
            }
            foreach (FileInfo f in new DirectoryInfo(node.Path).GetFiles())
                make_node(PathTree.Nodes, f.Name);
        }

        private void make_tree(FileIndexorNode fn, TreeNode tn)
        {
            foreach (FileIndexorNode n in fn.Nodes)
            {
                make_node(tn.Nodes, Path.GetFileName(n.Path.Remove(n.Path.Length - 1)));
                make_tree(n, tn.Nodes[tn.Nodes.Count - 1]);
            }
            foreach (FileInfo f in new DirectoryInfo(fn.Path).GetFiles())
                make_node(tn.Nodes, f.Name);
        }

        private void make_node(TreeNodeCollection tnc, string path)
        {
            TreeNode tn = new TreeNode(path);
            tnc.Add(tn);
            string fullpath = Path.Combine(tbPath.Text, tn.FullPath);
            if (File.Exists(fullpath)) {
                int index = iconListManager.AddFileIcon(fullpath);
                tn.ImageIndex = index;
                tn.SelectedImageIndex = index;
            } else {
                tn.ImageIndex = 0;
            }
        }

        #endregion

        #region 규칙 적용 및 추출

        List<Tuple<string, string, HitomiMetadata?>> metadatas = new List<Tuple<string, string, HitomiMetadata?>>();
        Dictionary<string, int> artist_rank_dic;
        int visit_count = 0;
        int available_count = 0;

        private void bApply_Click(object sender, EventArgs e)
        {
            var regexs = tbRule.Text.Split(',').ToList().Select(x => new Regex(x.Trim())).ToList();
            metadatas.Clear();
            visit_count = 0;
            available_count = 0;
            foreach (var node in PathTree.Nodes.OfType<TreeNode>())
                RecursiveVisit(node, regexs);
            LogEssential.Instance.PushLog(() => $"[Fs Manager] Apply! visit_count={visit_count}, available_count={available_count}");

            List<ListViewItem> lvil = new List<ListViewItem>();
            for (int i = 0; i < metadatas.Count; i++)
            {
                if (tgAVF.Checked == false && !metadatas[i].Item3.HasValue) continue;
                lvil.Add(new ListViewItem(new string[]
                {
                    (i+1).ToString(),
                    metadatas[i].Item1,
                    metadatas[i].Item2,
                    metadatas[i].Item3.HasValue.ToString()
                }));
            }
            AvailableList.Items.Clear();
            AvailableList.Items.AddRange(lvil.ToArray());

            //////////////////////////////////////////////////

            Dictionary<string, int> artist_count = new Dictionary<string, int>();
            foreach (var md in metadatas)
            {
                if (md.Item3.HasValue && md.Item3.Value.Artists != null)
                    foreach (var artist in md.Item3.Value.Artists)
                        if (artist_count.ContainsKey(artist))
                            artist_count[artist] += 1;
                        else
                            artist_count.Add(artist, 1);
                if (tgAEG.Checked && md.Item3.HasValue && md.Item3.Value.Groups != null)
                    foreach (var group in md.Item3.Value.Groups)
                    {
                        string tmp = "group:" + group;
                        if (artist_count.ContainsKey(tmp))
                            artist_count[tmp] += 1;
                        else
                            artist_count.Add(tmp, 1);
                    }
            }

            var artist_rank = artist_count.ToList();
            artist_rank.Sort((a, b) => b.Value.CompareTo(a.Value));

            artist_rank_dic = new Dictionary<string, int>();

            lvil.Clear();
            for (int i = 0; i < artist_rank.Count; i++)
            {
                lvil.Add(new ListViewItem(new string[]
                {
                    (i+1).ToString(),
                    artist_rank[i].Key,
                    artist_rank[i].Value.ToString()
                }));
                artist_rank_dic.Add(artist_rank[i].Key, i);
            }
            lvArtistPriority.Items.Clear();
            lvArtistPriority.Items.AddRange(lvil.ToArray());
        }

        private void RecursiveVisit(TreeNode node, List<Regex> regex)
        {
            string match = "";
            if (regex.Any(x => {
                if (!x.Match(node.Text).Success) return false;
                match = x.Match(node.Text).Groups[1].Value;
                return true;
                }))
            {
                metadatas.Add(new Tuple<string, string, HitomiMetadata?>(node.FullPath, match, HitomiCommon.GetMetadataFromMagic(match)));
                available_count += 1;
            }

            visit_count += 1;

            foreach (var cnode in node.Nodes.OfType<TreeNode>())
                RecursiveVisit(cnode, regex);
        }

        #endregion

        private void PathTree_DoubleClick(object sender, EventArgs e)
        {
            if (PathTree.SelectedNode != null && PathTree.SelectedNode.Nodes.Count == 0)
            {
                string path = PathTree.SelectedNode.FullPath.Replace('\\', '/');
                Process.Start(Path.Combine(tbPath.Text, PathTree.SelectedNode.FullPath));
            }
        }

        private void AvailableList_DoubleClick(object sender, EventArgs e)
        {
            if (AvailableList.SelectedItems.Count > 0)
            {
                Process.Start(Path.Combine(tbPath.Text, AvailableList.SelectedItems[0].SubItems[1].Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => AddPanel());
        }

        private void AddPanel()
        {
            int count = 0;
            foreach (var md in metadatas)
            {
                if (!md.Item3.HasValue) continue;
                count++;
                if (count == 100) return;
                string path = Path.Combine(tbPath.Text, md.Item1);

                IPicElement pe;
                pe = new PicElement(this);
                HitomiArticle article = HitomiCommon.MetadataToArticle(md.Item3.Value);

                pe.Article = article;
                pe.Label = article.Title;

                using (var zip = ZipFile.Open(path, ZipArchiveMode.Read))
                {
                    string tmp = Path.GetTempFileName();
                    zip.Entries[0].ExtractToFile(tmp, true);
                    pe.SetImageFromAddress(tmp, 150, 200);
                }

                pe.Font = this.Font;

                this.Post(() => ImagePanel.Controls.Add(pe as Control));
            }
        }

        private void lvArtistPriority_DoubleClick(object sender, EventArgs e)
        {
            if (lvArtistPriority.SelectedItems.Count > 0)
            {
                string token = lvArtistPriority.SelectedItems[0].SubItems[1].Text;
                bool group = false;
                if (token.StartsWith("group:"))
                {
                    group = true;
                    token = token.Substring("group:".Length);
                }

                if (group == false)
                    (new frmArtistInfo(this, token)).Show();
                else
                    (new frmGroupInfo(this, token)).Show();
            }
        }

        #region 재배치 도구

        private string MakeDownloadDirectory(string artists, HitomiMetadata metadata, string extension)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            string title = metadata.Name ?? "";
            string type = metadata.Type ?? "";
            string series = "";
            if (HitomiSetting.Instance.GetModel().ReplaceArtistsWithTitle)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                artists = textInfo.ToTitleCase(artists);
            }
            if (metadata.Parodies != null) series = metadata.Parodies[0];
            if (title != null)
                foreach (char c in invalid) title = title.Replace(c.ToString(), "");
            if (artists != null)
                foreach (char c in invalid) artists = artists.Replace(c.ToString(), "");
            if (series != null)
                foreach (char c in invalid) series = series.Replace(c.ToString(), "");
            if (artists.StartsWith("group:"))
                artists = artists.Substring("group:".Length);

            string path = tbDownloadPath.Text;
            path = Regex.Replace(path, "{Title}", title, RegexOptions.IgnoreCase);
            path = Regex.Replace(path, "{Artists}", artists, RegexOptions.IgnoreCase);
            path = Regex.Replace(path, "{Id}", metadata.ID.ToString(), RegexOptions.IgnoreCase);
            path = Regex.Replace(path, "{Type}", type, RegexOptions.IgnoreCase);
            path = Regex.Replace(path, "{Date}", DateTime.Now.ToString(), RegexOptions.IgnoreCase);
            path = Regex.Replace(path, "{Series}", series, RegexOptions.IgnoreCase);
            path += extension;
            return path;
        }

        private void bReplaceTest_Click(object sender, EventArgs e)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            
            foreach (var md in metadatas)
            {
                if (!md.Item3.HasValue) continue;
                string extension = Path.GetExtension(md.Item1);
                if (md.Item3.Value.Artists == null && md.Item3.Value.Groups == null)
                {
                    result.Add(new Tuple<string, string>(md.Item1, MakeDownloadDirectory("", md.Item3.Value, extension)));
                    continue;
                }

                List<string> artist_group = new List<string>();
                if (md.Item3.Value.Artists != null)
                    foreach (var artist in md.Item3.Value.Artists)
                        artist_group.Add(artist);
                if (tgAEG.Checked == true && md.Item3.Value.Groups != null)
                    foreach (var group in md.Item3.Value.Groups)
                        artist_group.Add("group:" + group);

                int top_rank = 0;
                for (int i = 1; i < artist_group.Count; i++)
                {
                    if (artist_rank_dic[artist_group[top_rank]] > artist_rank_dic[artist_group[i]])
                        top_rank = i;
                }

                result.Add(new Tuple<string, string>(md.Item1, MakeDownloadDirectory(artist_group[top_rank], md.Item3.Value, extension)));
            }
            
            List<ListViewItem> lvil = new List<ListViewItem>();
            for (int i = 0; i < result.Count; i++)
            {
                bool err = false;
                if (File.Exists(result[i].Item2)) err = true;
                else if (Directory.Exists(result[i].Item2)) err = true;
                lvil.Add(new ListViewItem(new string[]
                {
                    (i+1).ToString(),
                    result[i].Item1,
                    result[i].Item2,
                    (err ? "Already exists" : "")
                }));
                if (err)
                {
                    lvil[i].BackColor = Color.Orange;
                    lvil[i].ForeColor = Color.White;
                }
            }
            lvReplacerTestResult.Items.Clear();
            lvReplacerTestResult.Items.AddRange(lvil.ToArray());
        }

        #endregion
    }
}
