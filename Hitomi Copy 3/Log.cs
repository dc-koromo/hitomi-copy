﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using Hitomi_Copy_2.Analysis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Hitomi_Copy_3
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public void PushString(string str)
        {
            if (textBox1.InvokeRequired)
            {
                Invoke(new Action<string>(PushString), new object[] { str }); return;
            }
            textBox1.SuspendLayout();
            textBox1.AppendText(str + "\r\n");
            textBox1.ResumeLayout();
        }


        bool force_close = false;
        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !force_close)
            {
                e.Cancel = true;
                LogEssential.Instance.PushLog(() => "Don't do that. I'm serious.");
            }
        }

        private void Log_Load(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("log.log", textBox1.Text);
            MessageBox.Show("Save complete!", "Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void save_log()
        {
            File.WriteAllText("log.log", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HitomiSetting.Instance.GetModel().UsingLog = false;
            HitomiSetting.Instance.Save();
            force_close = true;
            MessageBox.Show("Setting.json의 UsingLog 항목을 true로 바꾸면 로그를 다시 사용할 수 있습니다.");
            Close();
        }

        List<string> cmd_stack = new List<string>();
        int stack_pointer = 0;
        const BindingFlags default_bf = BindingFlags.NonPublic |
                         BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        private void GetAllFields(Type t, BindingFlags flags)
        {
            if (t == null)
                return;
            
            t.GetFields(flags).ToList().ForEach(x => PushString(x.Name.PadRight(25) + $"[{x.FieldType.ToString()}]"));
            GetAllFields(t.BaseType, flags);
        }

        private void enum_recursion(object obj, string[] bb, int ptr)
        {
            if (bb.Length == ptr)
            {
                GetAllFields(obj.GetType(), default_bf);
                return;
            }
            enum_recursion(obj.GetType().GetField(bb[ptr], default_bf).GetValue(obj), bb, ptr + 1);
        }

        private void enum_recursion(object obj, string[] bb, int ptr, BindingFlags option)
        {
            if (bb.Length == ptr)
            {
                obj.GetType().GetFields(option)
                        .ToList().ForEach(x => PushString(x.Name.PadRight(25) + $"[{x.FieldType.ToString()}]"));
                //GetAllFields(obj.GetType(), option);
                return;
            }
            enum_recursion(obj.GetType().GetField(bb[ptr], default_bf).GetValue(obj), bb, ptr + 1, option);
        }

        private object get_recursion(object obj, string[] bb, int ptr)
        {
            if (bb.Length == ptr)
            {
                return obj;
            }
            return get_recursion(obj.GetType().GetField(bb[ptr], default_bf).GetValue(obj), bb, ptr + 1);
        }

        private void set_recurion(object obj, string[] bb, int ptr)
        {
            if (bb.Length - 2 == ptr)
            {
                obj.GetType().GetField(bb[ptr]).SetValue(obj,
                    Convert.ChangeType(bb[ptr + 1], obj.GetType().GetField(bb[ptr], default_bf).GetValue(obj).GetType()));
                return;
            }   
            set_recurion(obj.GetType().GetField(bb[ptr]).GetValue(obj), bb, ptr + 1);
        }
        
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                textBox2.Text = textBox2.Text.Trim();

                PushString("dc-koromo@hitomi-copy$ " + textBox2.Text);
                string cmd = textBox2.Text.Trim().Split(' ')[0];

                if (cmd == "enum" || cmd == "enumi" || cmd == "enumx")
                {
                    if (textBox2.Text.Trim().Split(' ').Length == 1)
                    {
                        foreach (var f in Application.OpenForms)
                        {
                            PushString(f.GetType().Name);
                        }
                    }
                    else
                    {
                        try
                        {
                            string frm_name = textBox2.Text.Trim().Split(' ')[1];
                            if (cmd == "enum")
                                enum_recursion(Application.OpenForms[frm_name], textBox2.Text.Trim().Split(' '), 2, BindingFlags.Instance | BindingFlags.Public);
                            else if (cmd == "enumi")
                                enum_recursion(Application.OpenForms[frm_name], textBox2.Text.Trim().Split(' '), 2, default_bf);
                            else if (cmd == "enumx")
                                enum_recursion(Application.OpenForms[frm_name], textBox2.Text.Trim().Split(' '), 2);
                        }
                        catch (Exception ex)
                        {
                            PushString(ex.Message);
                        }
                    }
                }
                else if (cmd == "get")
                {
                    string[] split = textBox2.Text.Trim().Split(' ');
                    if (split.Length >= 3)
                    {
                        string frm = split[1];
                        string var = split[2];

                        try
                        {
                            PushString(LogEssential.SerializeObject(get_recursion(Application.OpenForms[frm], split, 2)));
                        }
                        catch (Exception ex)
                        {
                            PushString(ex.Message);
                        }
                    }
                    else if (split.Length >= 2 && split[1] == "hitomi_analysis")
                    {
                        PushString(string.Join("\r\n", HitomiAnalysis.Instance.Rank.Select(p => $"{p.Item1} ({p.Item2})")));
                        PushString($"Artist Counts : {HitomiAnalysis.Instance.Rank.Count}");
                    }
                    else
                    {
                        PushString("using 'get (Form) (Variable1) [Variable2] ...'");
                    }
                }
                else if (cmd == "set")
                {
                    string[] split = textBox2.Text.Trim().Split(' ');
                    if (split.Length >= 4)
                    {
                        string frm = split[1];
                        string var = split[2];
                        string val = split[3];

                        try
                        {
                            set_recurion(Application.OpenForms[frm], split, 2);
                        }
                        catch (Exception ex)
                        {
                            PushString(ex.Message);
                        }
                    }
                    else
                    {
                        PushString("using 'set (Form) (Variable1) [Variable2] ... [Value]'");
                    }
                }
                else if (cmd == "ra")
                {
                    string[] split = textBox2.Text.Trim().Split(' ');
                    if (split.Length > 1)
                    {
                        if (split[1] == "ulist")
                        {
                            PushString("User History");
                            HitomiAnalysisArtist user;
                            user = new HitomiAnalysisArtist(HitomiLog.Instance.GetEnumerator());
                            foreach (var pair in user.GetDictionary())
                            {
                                PushString($"{pair.Key} ({pair.Value})");
                            }
                        }
                        else if (split[1] == "list")
                        {
                            PushString("User Custom History");
                            if (HitomiAnalysis.Instance.CustomAnalysis != null)
                            {
                                HitomiAnalysis.Instance.CustomAnalysis.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                                PushString(string.Join("\r\n", HitomiAnalysis.Instance.CustomAnalysis.Select(x => $"{x.Item1} ({x.Item2})")));
                            }
                        }
                        else if (split[1] == "clear")
                        {
                            HitomiAnalysis.Instance.CustomAnalysis.Clear();
                        }
                        else if (split[1] == "update")
                        {
                            HitomiAnalysis.Instance.Update();
                            (Application.OpenForms[0] as frmMain).UpdateNewStatistics();
                        }
                        else if (split[1] == "on")
                        {
                            HitomiAnalysis.Instance.UserDefined = true;
                        }
                        else if (split[1] == "off")
                        {
                            HitomiAnalysis.Instance.UserDefined = false;
                        }
                        else if (split[1] == "+")
                        {
                            if (split.Length >= 4)
                            {
                                try
                                {
                                    string tag = Regex.Replace(split[2], "_", " ");
                                    int val = Convert.ToInt32(split[3]);

                                    bool found = false;
                                    found = HitomiData.Instance.tagdata_collection.female.Any(x => x.Tag == tag);
                                    if (found == false) found = HitomiData.Instance.tagdata_collection.male.Any(x => x.Tag == tag);
                                    if (found == false) found = HitomiData.Instance.tagdata_collection.tag.Any(x => x.Tag == tag);

                                    if (!found)
                                    {
                                        PushString($"'{tag}' is not found.");
                                        string similar = "";
                                        int diff = int.MaxValue;
                                        HitomiData.Instance.tagdata_collection.female.ForEach(x => { int diff_t = StringAlgorithms.get_diff(tag, x.Tag); if (diff_t < diff) { diff = diff_t; similar = x.Tag; } });
                                        HitomiData.Instance.tagdata_collection.male.ForEach(x => { int diff_t = StringAlgorithms.get_diff(tag, x.Tag); if (diff_t < diff) { diff = diff_t; similar = x.Tag; } });
                                        HitomiData.Instance.tagdata_collection.tag.ForEach(x => { int diff_t = StringAlgorithms.get_diff(tag, x.Tag); if (diff_t < diff) { diff = diff_t; similar = x.Tag; } });
                                        PushString($"Are you looking for '{similar}'?");
                                        return;
                                    }

                                    if (HitomiAnalysis.Instance.CustomAnalysis.Any(x => x.Item1 == tag))
                                    {
                                        for (int i = 0; i < HitomiAnalysis.Instance.CustomAnalysis.Count; i++)
                                            if (HitomiAnalysis.Instance.CustomAnalysis[i].Item1 == tag)
                                                HitomiAnalysis.Instance.CustomAnalysis[i] = new Tuple<string, int>(tag, val);
                                    }
                                    else
                                        HitomiAnalysis.Instance.CustomAnalysis.Add(new Tuple<string, int>(tag, val));
                                    
                                }
                                catch (Exception ex)
                                {
                                    PushString(ex.Message);
                                }
                            }
                            else if (split.Length == 3)
                            {
                                string tag = Regex.Replace(split[2], "_", " ");
                                List<Tuple<string, int>> diff = new List<Tuple<string, int>>();
                                HitomiData.Instance.tagdata_collection.female.ForEach(x => diff.Add(new Tuple<string, int>(x.Tag, StringAlgorithms.get_diff(tag, x.Tag))));
                                HitomiData.Instance.tagdata_collection.male.ForEach(x => diff.Add(new Tuple<string, int>(x.Tag, StringAlgorithms.get_diff(tag, x.Tag))));
                                HitomiData.Instance.tagdata_collection.tag.ForEach(x => diff.Add(new Tuple<string, int>(x.Tag, StringAlgorithms.get_diff(tag, x.Tag))));
                                diff.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                                for (int i = 5; i >= 0; i--)
                                    PushString(diff[i].Item1);
                            }
                            else
                            {
                                PushString("'+' command need 2 more parameters.");
                            }
                        }
                        else if (split[1] == "+a")
                        {
                            if (split.Length >= 3)
                            {
                                try
                                {
                                    string artist = Regex.Replace(split[2], "_", " ");
                                    
                                    bool found = false;
                                    found = HitomiData.Instance.tagdata_collection.artist.Any(x => x.Tag == artist);
                                    
                                    if (!found)
                                    {
                                        PushString($"'{artist}' is not found.");
                                        string similar = "";
                                        int diff = int.MaxValue;
                                        HitomiData.Instance.tagdata_collection.artist.ForEach(x => { int diff_t = StringAlgorithms.get_diff(artist, x.Tag); if (diff_t < diff) { diff = diff_t; similar = x.Tag; } });
                                        PushString($"Are you looking for '{similar}'?");
                                        return;
                                    }

                                    foreach (var data in HitomiData.Instance.metadata_collection)
                                    {
                                        if (data.Artists != null && data.Tags != null && data.Artists.Contains(artist))
                                        {
                                            foreach (var tag in data.Tags)
                                            {
                                                if (HitomiAnalysis.Instance.CustomAnalysis.Any(x => x.Item1 == tag))
                                                {
                                                    for (int i = 0; i < HitomiAnalysis.Instance.CustomAnalysis.Count; i++)
                                                        if (HitomiAnalysis.Instance.CustomAnalysis[i].Item1 == tag)
                                                            HitomiAnalysis.Instance.CustomAnalysis[i] = new Tuple<string, int>(tag, HitomiAnalysis.Instance.CustomAnalysis[i].Item2 + 1);
                                                }
                                                else
                                                    HitomiAnalysis.Instance.CustomAnalysis.Add(new Tuple<string, int>(tag, 1));
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    PushString(ex.Message);
                                }
                            }
                            else
                            {
                                PushString("'+a' command need 1 more parameters.");
                            }
                        }
                    }
                    else
                    {
                        PushString("using 'ra (option) [tag] [count] ...'");
                        PushString("  (option): ulist, list, clear, update, on, off, +, +a");
                    }
                }
                else if (cmd == "help")
                {
                    PushString("Realtime Variable Update System");
                    PushString("Copyright (C) 2018. Hitomi Parser Developers");
                    PushString("");
                    PushString("enum [Form] [Variable1] [Variable2] ... : Enumerate form or class members.");
                    PushString("enumi [Form] [Variable1] [Variable2] ... : Enumerate form or class members with private members.");
                    PushString("enumx [Form] [Variable1] [Variable2] ... : Enumerate all class members without static.");
                    PushString("get (Form|hitomi_analysis) (Variable1) [Variable2] ... : Get value.");
                    PushString("set (Form) (Variable1) [Variable2] ... [Value] : Set value.");
                    PushString("fucs : Frequently Used Command Snippet");
                    PushString("ra (option) [var1] [var2] ... : Recommend artists tools.");
                }
                else if (cmd == "fucs")
                {
                    PushString("get frmMain latest_load_count");
                    PushString("   - get Recommend scroll status");
                    PushString("set frmMain latest_load_count 100");
                    PushString("   - set Recommend scroll status to 100");
                }
                else
                {
                    PushString("Command not found. Try 'help' command.");
                }

                cmd_stack.Insert(0, textBox2.Text + " ");
                textBox2.Text = "";
                stack_pointer = 0;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (stack_pointer >= cmd_stack.Count)
                    stack_pointer = cmd_stack.Count - 1;
                if (stack_pointer >= 0)
                {
                    textBox2.Text = cmd_stack[stack_pointer];
                    Application.DoEvents();
                    textBox2.Focus();
                    textBox2.SelectionStart = Math.Max(0, textBox2.Text.Length * 10);
                    textBox2.SelectionLength = 0;
                    textBox2.Focus();
                }
                stack_pointer++;
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBox2.SelectionStart = Math.Max(0, textBox2.Text.Length - 1);
                textBox2.SelectionLength = 0;
            }
        }
    }

    public class LogEssential
    {
        private static readonly Lazy<LogEssential> instance = new Lazy<LogEssential>(() => new LogEssential());
        public static LogEssential Instance => instance.Value;
        Log my_log;

        public void Initialize()
        {
            if (HitomiSetting.Instance.GetModel().UsingLog)
            {
                my_log = new Log();
                my_log.Show();
                my_log.PushString($"Hitomi Copy {UpdateManager.Version}");
                my_log.PushString("Copyright (C) 2018. Hitomi Parser Developers");
                my_log.PushString("E -Mail: koromo.software@gmail.com");
                my_log.PushString("Source-code : https://github.com/dc-koromo/hitomi-downloader-2");
                my_log.PushString("");
                PushLog(() => "Hello!");
                PushLog(() => "Current Setting");
                PushLog(HitomiSetting.Instance.GetModel());
            }
        }

        public void SaveLog()
        {
            my_log.save_log();
        }

        public void PushLog(Func<string> str)
        {
            if (HitomiSetting.Instance.GetModel().UsingLog)
            {
                CultureInfo en = new CultureInfo("en-US");
                my_log.PushString($"[{DateTime.Now.ToString(en)}] {str()}");
            }
        }

        public void PushLog(object obj)
        {
            if (HitomiSetting.Instance.GetModel().UsingLog)
            {
                PushLog(() => obj.ToString());
                my_log.PushString(SerializeObject(obj));
            }
        }

        public static string SerializeObject(object toSerialize)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, toSerialize);
                    return textWriter.ToString();
                }
            }
            catch
            {
                try
                {
                    return JsonConvert.SerializeObject(toSerialize, Formatting.Indented, new JsonSerializerSettings
                    {
                        //ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });
                }
                catch (Exception e)
                {
                    Instance.PushLog(() => $"[Error] {e.Message}");
                    return toSerialize.ToString();
                }
            }
        }
    }
}
