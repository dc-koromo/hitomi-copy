/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class MergeJSon : Form
    {
        public MergeJSon()
        {
            InitializeComponent();
        }

        #region 히든 데이터

        List<HitomiArticle> hidden_list = new List<HitomiArticle>();

        private void TransactionHidden(string path)
        {
            try
            {
                List<HitomiArticle> hlm = JsonConvert.DeserializeObject<List<HitomiArticle>>(File.ReadAllText(path));
                hidden_list.AddRange(hlm);
                LogEssential.Instance.PushLog(() => $"'{path}'로 부터 {hlm.Count.ToString("#,#")}개가 트랜잭션됨");
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"'{path}'는 옳바른 HitomiArticle가 아닌 것 같습니다. {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var path in textBox6.Lines)
            {
                if (File.Exists(path))
                {
                    TransactionHidden(path);
                }
                else if (Directory.Exists(path))
                {
                    foreach (var file in from x in Directory.GetFiles(path) where x.EndsWith(".json") select x)
                    {
                        TransactionHidden(file);
                    }
                }
                else
                {
                    LogEssential.Instance.PushLog(() => $"'{path}'은 옳바른 파일또는 경로가 아닙니다.");
                }
            }
            LogEssential.Instance.PushLog(() => $"{hidden_list.Count.ToString("#,#")}개의 데이터가 트랜잭션됨");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), textBox5.Text)))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, hidden_list);
                }
                LogEssential.Instance.PushLog(() => $"{log_list.Count.ToString("#,#")}개의 데이터가 성공적으로 '{textBox5.Text}'로 커밋되었습니다.");
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"커밋 중 오류가 발생했습니다. {ex.Message}");
            }
        }

        #endregion

        #region 히토미 로그

        List<HitomiLogModel> log_list = new List<HitomiLogModel>();

        private void TransactionHitomiLog(string path)
        {
            try
            {
                List<HitomiLogModel> hlm = JsonConvert.DeserializeObject<List<HitomiLogModel>>(File.ReadAllText(path));
                log_list.AddRange(hlm);
                LogEssential.Instance.PushLog(() => $"'{path}'로 부터 {hlm.Count.ToString("#,#")}개가 트랜잭션됨");
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"'{path}'는 옳바른 HitomiLogModel가 아닌 것 같습니다. {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var path in textBox1.Lines)
            {
                if (File.Exists(path))
                {
                    TransactionHitomiLog(path);
                }
                else if (Directory.Exists(path))
                {
                    foreach (var file in from x in Directory.GetFiles(path) where x.EndsWith(".json") select x)
                    {
                        TransactionHitomiLog(file);
                    }
                }
                else
                {
                    LogEssential.Instance.PushLog(() => $"'{path}'은 옳바른 파일또는 경로가 아닙니다.");
                }
            }
            LogEssential.Instance.PushLog(() => $"{log_list.Count.ToString("#,#")}개의 데이터가 트랜잭션됨");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string json = JsonConvert.SerializeObject(log_list, Formatting.Indented);
                using (var fs = new StreamWriter(new FileStream(textBox2.Text, FileMode.Create, FileAccess.Write)))
                {
                    fs.Write(json);
                }
                LogEssential.Instance.PushLog(() => $"{log_list.Count.ToString("#,#")}개의 데이터가 성공적으로 '{textBox2.Text}'로 커밋되었습니다.");
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"커밋 중 오류가 발생했습니다. {ex.Message}");
            }
        }

        #endregion

        #region 히토미 메타데이터

        List<HitomiMetadata> metadatalist = new List<HitomiMetadata>();

        private void TransactionHitomiMetadata(string path)
        {
            try
            {
                List<HitomiMetadata> hlm = JsonConvert.DeserializeObject<List<HitomiMetadata>>(File.ReadAllText(path));
                metadatalist.AddRange(hlm);
                LogEssential.Instance.PushLog(() => $"'{path}'로 부터 {hlm.Count.ToString("#,#")}개가 트랜잭션됨");
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"'{path}'는 옳바른 HitomiMetadata가 아닌 것 같습니다. {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var path in textBox4.Lines)
            {
                if (File.Exists(path))
                {
                    TransactionHitomiMetadata(path);
                }
                else if (Directory.Exists(path))
                {
                    foreach (var file in from x in Directory.GetFiles(path) where x.EndsWith(".json") select x)
                    {
                        TransactionHitomiMetadata(file);
                    }
                }
                else
                {
                    LogEssential.Instance.PushLog(() => $"'{path}'은 옳바른 파일또는 경로가 아닙니다.");
                }
            }
            LogEssential.Instance.PushLog(() => $"{metadatalist.Count.ToString("#,#")}개의 데이터가 트랜잭션됨");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), textBox3.Text)))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, metadatalist);
                }
                LogEssential.Instance.PushLog(() => $"{metadatalist.Count.ToString("#,#")}개의 데이터가 성공적으로 '{textBox3.Text}'로 커밋되었습니다.");
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"커밋 중 오류가 발생했습니다. {ex.Message}");
            }
        }

        #endregion
    }
}
