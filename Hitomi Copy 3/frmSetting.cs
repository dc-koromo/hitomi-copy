/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_2;
using System;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            tgWI.Checked = HitomiSetting.Instance.GetModel().WaitInfinite;
            tbWT.Text = HitomiSetting.Instance.GetModel().WaitTimeout.ToString();
            tgSJ.Checked = HitomiSetting.Instance.GetModel().SaveJson;
            tbRPS.Text = HitomiSetting.Instance.GetModel().RecommendPerScroll.ToString();
            tbTMA.Text = HitomiSetting.Instance.GetModel().TextMatchingAccuracy.ToString();
            tbMTS.Text = HitomiSetting.Instance.GetModel().MaximumThumbnailShow.ToString();
            tgRNM.Checked = HitomiSetting.Instance.GetModel().RecommendNMultipleWithLength;
            tgRL.Checked = HitomiSetting.Instance.GetModel().RecommendLanguageALL;
            tgRA.Checked = HitomiSetting.Instance.GetModel().ReplaceArtistsWithTitle;
            tgUL.Checked = HitomiSetting.Instance.GetModel().UsingLog;
            tgDSR.Checked = HitomiSetting.Instance.GetModel().DetailedSearchResult;
            tgEXH.Checked = HitomiSetting.Instance.GetModel().UsingExHentaiBaseOpener;
            tgXA.Checked = HitomiSetting.Instance.GetModel().UsingXiAanlysis;
            tgAS.Checked = HitomiSetting.Instance.GetModel().AutoSync;
            tbLPM.Text = HitomiSetting.Instance.GetModel().LoadPreviewMaximum.ToString();
            tgSPC.Checked = HitomiSetting.Instance.GetModel().ShowPageCount;
            tbACSC.Text = HitomiSetting.Instance.GetModel().AutoCompleteShowCount.ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            int tmp;
            if (!int.TryParse(tbWT.Text, out tmp))
            {
                MessageBox.Show( "Wait Timeout은 숫자여야 합니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(tbRPS.Text, out tmp))
            {
                MessageBox.Show("Recommend Per Scroll은 숫자여야 합니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(tbTMA.Text, out tmp))
            {
                MessageBox.Show("Text Matching Accuracy는 숫자여야 합니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(tbLPM.Text, out tmp))
            {
                MessageBox.Show("Load Preview Maximum는 숫자여야 합니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(tbACSC.Text, out tmp))
            {
                MessageBox.Show("AutoComplete Show Count는 숫자여야 합니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HitomiSetting.Instance.GetModel().WaitInfinite = tgWI.Checked;
            HitomiSetting.Instance.GetModel().WaitTimeout = Convert.ToInt32(tbWT.Text);
            HitomiSetting.Instance.GetModel().SaveJson = tgSJ.Checked;
            HitomiSetting.Instance.GetModel().RecommendPerScroll = Convert.ToInt32(tbRPS.Text);
            HitomiSetting.Instance.GetModel().TextMatchingAccuracy = Convert.ToInt32(tbTMA.Text);
            HitomiSetting.Instance.GetModel().MaximumThumbnailShow = Convert.ToInt32(tbMTS.Text);
            HitomiSetting.Instance.GetModel().RecommendNMultipleWithLength = tgRNM.Checked;
            HitomiSetting.Instance.GetModel().RecommendLanguageALL = tgRL.Checked;
            HitomiSetting.Instance.GetModel().ReplaceArtistsWithTitle = tgRA.Checked;
            HitomiSetting.Instance.GetModel().UsingLog = tgUL.Checked;
            HitomiSetting.Instance.GetModel().DetailedSearchResult = tgDSR.Checked;
            HitomiSetting.Instance.GetModel().UsingExHentaiBaseOpener = tgEXH.Checked;
            HitomiSetting.Instance.GetModel().UsingXiAanlysis = tgXA.Checked;
            HitomiSetting.Instance.GetModel().AutoSync = tgAS.Checked;
            HitomiSetting.Instance.GetModel().LoadPreviewMaximum = Convert.ToInt32(tbLPM.Text);
            HitomiSetting.Instance.GetModel().ShowPageCount = tgSPC.Checked;
            HitomiSetting.Instance.GetModel().AutoCompleteShowCount = Convert.ToInt32(tbACSC.Text);
            HitomiSetting.Instance.Save();
            Close();
        }

        private void tgWI_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "파일 다운로드시 응답이 없을 경우 무제한 기다릴 것의 여부를 설정합니다.";
        }

        private void tbWT_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "무제한 기다리지 않는다면 몇 ms기다릴지 설정합니다.";
        }

        private void tgSJ_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "Article를 다운로드할 때 마다 폴더에 .json파일을 생성합니다.";
        }

        private void tbRPS_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "작가추천에서 스크롤할 때마다 몇 개의 추천목록을 보여줄지 설정합니다.";
        }

        private void tbTMA_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "작가추천에서 중복된 Article를 표시하지않도록 설정하는 고유값입니다.";
        }

        private void tbMTS_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "표시할 수 있는 검색 결과의 최대 개수입니다.";
        }

        private void tgRNM_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "작가추천 목록 생성시 해당 작가의 Article 수를 곱하지 않습니다. 이 설정은 단순한 작가추천 결과를 제공합니다.";
        }

        private void tgRL_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "작가추천시 모든 언어를 기반으로 목록을 생성합니다.";
        }

        private void tgRA_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "{Aritsts}를 단어의 첫 글자 대문자로하여 치환합니다.";
        }

        private void tgUL_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "모든 진행상황을 기록합니다. 런타임 변수 수정 시스템 기능을 실험적으로 제공합니다.";
        }

        private void tgDSR_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "검색결과가 자세하게 표시됩니다.";
        }

        private void tgEXH_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "검색결과에서 '히토미으로 열기'가 아닌 '익헨으로 열기'가 기본으로 설정됩니다.";
        }

        private void tgXA_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "단순 회귀 방법을 이용해 작가 추천 목록을 작성합니다. 이 기능을 사용하려면 Recommend NMultiple With Length 옵션을 켜세요.";
        }
        
        private void tgAS_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "프로그램 시작시 데이터 동기화를 실행합니다. 이 옵션을 켜면 데이터를 저장하지 않습니다.";
        }

        private void tbLPM_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "미리보기에서 보여줄 최대 이미지 수를 설정합니다.";
        }

        private void tgSPC_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "Detailed Result에서 작품의 페이지 수를 보여줍니다.";
        }

        private void tbACSC_MouseEnter(object sender, EventArgs e)
        {
            tbInfo.Text = "검색시 표시되는 자동완성 검색어의 최대 개수를 설정합니다.";
        }

        private void MouseLeave_Event(object sender, EventArgs e)
        {
            tbInfo.Text = "";
        }
    }
}
