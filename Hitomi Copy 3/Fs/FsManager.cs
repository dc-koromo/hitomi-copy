/* Copyright (C) 2018. Hitomi Parser Developers */

using Etier.IconHelper;
using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        List<Tuple<string, string, HitomiMetadata?>> metadatas = new List<Tuple<string, string, HitomiMetadata?>>();
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
    }
}
