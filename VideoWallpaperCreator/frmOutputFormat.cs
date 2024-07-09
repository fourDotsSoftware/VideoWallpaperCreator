using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VideoWallpaperCreator
{
    public partial class frmOutputFormat : VideoWallpaperCreator.CustomForm
    {
        private List<SelectedCategoryProfile> SelectedCategoryProfileNames = new List<SelectedCategoryProfile>();

        public string Extension = "";
        public string FFMpegParameters = "";
        public OutputFormatResult OutputFormatResult = null;

        private bool ForBatchJoin = false;

        public frmOutputFormat(bool for_batch_join)
        {
            InitializeComponent();

            ForBatchJoin = for_batch_join;

            if (ForBatchJoin)
            {
                this.Text = TranslateHelper.Translate("Please specify Default Output Format for Batch Joins");
            }
        }

        public frmOutputFormat():this(false)
        {

        }

        public frmOutputFormat(OutputFormatResult res)
            : this(true)
        {
            OutputFormatResult = res;
        }
        private void btnNewProfile_Click(object sender, EventArgs e)
        {
            frmProfile f = new frmProfile(true);

            if (f.ShowDialog() == DialogResult.OK)
            {
                FillProfiles(f.txtProfileName.Text.Trim(), f.cmbCategory.Text.Trim());
            }
        }

        private void FillProfiles(string selected_profile,string selected_category)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList nocats = doc.SelectNodes("//cat");

            List<string> lst = new List<string>();

            for (int k = 0; k < nocats.Count; k++)
            {
                string ncat = nocats[k].InnerText;

                if (lst.IndexOf(ncat) < 0)
                {
                    lst.Add(ncat);
                }
            }

            lst.Sort();

            lvCategory.Items.Clear();
            lvProfile.Items.Clear();

            lvCategory.Items.Add(TranslateHelper.Translate("Recent Profiles"));

            for (int k = 0; k < lst.Count; k++)
            {                
                    lvCategory.Items.Add(lst[k]);

                    if (selected_category != string.Empty && lst[k] == selected_category)
                    {
                        lvCategory.Items[lvCategory.Items.Count - 1].Selected = true;
                    }                               
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Preview Join"))
                {
                    int m=1;
                    string cattext=TranslateHelper.Translate("Preview Join");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }                               
                }
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Ultrafast"))
                {
                    int m = 2;
                    string cattext = TranslateHelper.Translate("Ultrafast");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Superfast"))
                {
                    int m = 3;
                    string cattext = TranslateHelper.Translate("Superfast");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Veryfast"))
                {
                    int m = 4;
                    string cattext = TranslateHelper.Translate("Veryfast");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            /*
             if (lst[k] == "Preview Join")
                {
                    try
                    {
                        lvCategory.Items.Insert(1, "Preview Join");

                        if (selected_category != string.Empty && lst[k] == selected_category)
                        {
                            lvCategory.Items[1].Selected = true;
                        }
                    }
                    catch { }
                }
                else if (lst[k] == "Ultrafast")
                {
                    try
                    {
                        lvCategory.Items.Insert(2, "Ultrafast");

                        if (selected_category != string.Empty && lst[k] == selected_category)
                        {
                            lvCategory.Items[2].Selected = true;
                        }
                    }
                    catch { }
                }
                else if (lst[k] == "Superfast")
                {
                    try
                    {
                        lvCategory.Items.Insert(3, "Superfast");

                        if (selected_category != string.Empty && lst[k] == selected_category)
                        {
                            lvCategory.Items[3].Selected = true;
                        }
                    }
                    catch { }
                }
                else if (lst[k] == "Veryfast")
                {
                    try
                    {
                        lvCategory.Items.Insert(4, "Veryfast");

                        if (selected_category != string.Empty && lst[k] == selected_category)
                        {
                            lvCategory.Items[4].Selected = true;
                        }
                    }
                    catch { }
                }
                else
                {
             */
            if (lvCategory.Items.Count > 0 && selected_category == string.Empty)
            {
                lvCategory.Items[0].Selected = true;
                selected_category = lvCategory.Items[0].Text;
            }

            SelectCategory(selected_category, selected_profile);

            lvCategory.Columns[0].Width = lvCategory.Width - 7;
            lvProfile.Columns[0].Width = lvProfile.Width - 7;
        }

        public static void ProfilesToText()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList nolos = doc.SelectNodes("//Profile");

            string str = "<ul>\r\n";

            for (int k = 0; k < nolos.Count; k++)
            {
                string label = nolos[k].SelectSingleNode("label").InnerText;

                str += "<li>" + label + "</li>\r\n";
            }

            str += "</ul>";

            Clipboard.Clear();
            Clipboard.SetText(str);
        }

        private void SelectCategory(string category, string profile_name)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            SelectedCategoryProfileNames = new List<SelectedCategoryProfile>();

            if (lvCategory.SelectedIndices[0] == 0) // Recent Profiles
            {
                XmlNodeList noreces = doc.SelectNodes("//RecentProfile");

                for (int m = 0; m < noreces.Count; m++)
                {
                    XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + noreces[m].InnerText + "']");

                    string label = nod.SelectSingleNode("label").InnerText;
                    
                    SelectedCategoryProfile profi = new SelectedCategoryProfile();
                    profi.Name = noreces[m].InnerText;
                    profi.Label = label;

                    SelectedCategoryProfileNames.Add(profi);
                }
            }
            else
            {
                XmlNodeList nocats = doc.SelectNodes("//cat");

                for (int k = 0; k < nocats.Count; k++)
                {
                    string ncat = nocats[k].InnerText;

                    if (ncat == category)
                    {
                        string label = nocats[k].ParentNode.SelectSingleNode("label").InnerText;
                        string name = nocats[k].ParentNode.Attributes.GetNamedItem("name").Value; ;

                        bool found = false;

                        for (int m = 0; m < SelectedCategoryProfileNames.Count; m++)
                        {
                            if (SelectedCategoryProfileNames[m].Name == name)
                            {
                                found = true;
                            }
                        }

                        if (!found)
                        {
                            SelectedCategoryProfile profi = new SelectedCategoryProfile();
                            profi.Name = nocats[k].ParentNode.Attributes.GetNamedItem("name").Value;
                            profi.Label = label;

                            SelectedCategoryProfileNames.Add(profi);
                        }
                    }
                }
            }

            SelectedCategoryProfileNames.Sort(new SelectedCategoryComparer());

            lvProfile.Items.Clear();

            for (int k = 0; k < SelectedCategoryProfileNames.Count; k++)
            {
                lvProfile.Items.Add(SelectedCategoryProfileNames[k].Label);

                if (profile_name!=string.Empty)
                {
                    if (SelectedCategoryProfileNames[k].Name == profile_name)
                    {
                        lvProfile.Items[lvProfile.Items.Count - 1].Selected = true;
                    }
                }
            }

            if (profile_name == string.Empty && lvProfile.Items.Count > 0)
            {
                lvProfile.Items[0].Selected = true;
            }
        }
        private void frmOutputFormat_Load(object sender, EventArgs e)
        {
            if (OutputFormatResult != null)
            {
                FillProfiles(OutputFormatResult.selectedProfile, OutputFormatResult.selectedProfileCategory);
            }
            else
            {
                FillProfiles(Properties.Settings.Default.SelectedProfile, Properties.Settings.Default.SelectedProfileCategory);
            }

            LoadVideoEncodingOptions();

            if (OutputFormatResult != null)
            {
                LoadOutputFormatResult();
            }
            else
            {
                LoadSettings();
            }

            if (txtOverlayImageFile.Text != string.Empty && System.IO.File.Exists(txtOverlayImageFile.Text))
            {
                Image img = Image.FromFile(txtOverlayImageFile.Text);

                if (img.Width < picOverlay.Width && img.Height < picOverlay.Height)
                {
                    picOverlay.SizeMode = PictureBoxSizeMode.Normal;
                }
                else
                {
                    picOverlay.SizeMode = PictureBoxSizeMode.Zoom;
                }

                picOverlay.Image = img;
            }

            string windir = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName;

            string fontsdir = System.IO.Path.Combine(windir, "fonts");

            string[] fontfilez = System.IO.Directory.GetFiles(fontsdir, "*.ttf");

            for (int k = 0; k < fontfilez.Length; k++)
            {
                cmbDrawTextFont.Items.Add(System.IO.Path.GetFileName(fontfilez[k]));
            }

            this.CancelButton = null;
            this.AcceptButton = null;
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedIndices.Count > 0)
            {
                SelectCategory(lvCategory.SelectedItems[0].Text, "");
                btnEditProfile.Enabled = true;
            }
            else
            {
                btnEditProfile.Enabled = false;               
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedIndices.Count == 0)
            {
                Module.ShowMessage("Please select a Profile first !");
                return;
            }


            if (chkDrawTextFrom.Checked && chkDrawTextTo.Checked)
            {
                if (txtDrawTextToTime.MSecs <= txtDrawTextFromTime.MSecs)
                {
                    Module.ShowMessage("Error. Draw Text From Time is less or equal to Draw Text To Time !");
                    return;
                }
            }

            if (chkDrawText.Checked && cmbDrawTextFont.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a Font for the Draw Text Function !");
                return;
            }

            if (chkMixAudio.Checked && !System.IO.File.Exists(txtMixAudioFile.Text))
            {
                Module.ShowMessage("Error. Mix Audio File does not exist !");
                return;
            }

            if (chkOverlay.Checked && !System.IO.File.Exists(txtOverlayImageFile.Text))
            {
                Module.ShowMessage("Error. Overlay Image File does not exist !");
                return;
            }

            if (chkMute.Checked && chkMixAudio.Checked)
            {
                Module.ShowMessage("Cannot Mute Audio and Mix Audio at the same time !");
                return;
            }

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name + "']");

            Extension = nod.SelectSingleNode("ext").InnerText;

            if (!Extension.StartsWith("."))
            {
                Extension = "." + Extension;
            }
            
            FFMpegParameters = nod.SelectSingleNode("ffmpeg_parameters").InnerText;            

            if (ForBatchJoin)
            {
                OutputFormatResult = new OutputFormatResult();

                OutputFormatResult.selectedProfile = SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name;
                OutputFormatResult.selectedProfileCategory = lvCategory.Items[lvCategory.SelectedIndices[0]].Text;
                OutputFormatResult.extension = Extension;
                OutputFormatResult.ffmpegParameters = FFMpegParameters;

                SaveOutputFormatResult();
            }
            else
            {

                Properties.Settings.Default.SelectedProfile = SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name;
                Properties.Settings.Default.SelectedProfileCategory = lvCategory.Items[lvCategory.SelectedIndices[0]].Text;

                SaveRecentProfiles(SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name);

                SaveSettings();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void SaveRecentProfiles(string profile_name)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList norece = doc.SelectNodes("//RecentProfile");

            bool found = false;

            for (int k = 0; k < norece.Count; k++)
            {
                if (norece[k].InnerText == profile_name)
                {
                    found = true;

                    XmlNode nor = (XmlNode)doc.CreateElement("RecentProfile");
                    nor.InnerText = profile_name;

                    norece[k].ParentNode.PrependChild(nor);

                    norece[k].ParentNode.RemoveChild(norece[k]);
                }

                if ((k == 11 && !found) || k>11)
                {
                    norece[k].ParentNode.RemoveChild(norece[k]);
                }
            }

            if (!found)
            {
                XmlNode nor = (XmlNode)doc.CreateElement("RecentProfile");
                nor.InnerText = profile_name;

                XmlNode noreces = doc.SelectSingleNode("//RecentProfiles");

                noreces.PrependChild(nor);
            }

            doc.Save(Module.ProfilesFile);

        }

        private void LoadRecentProfiles()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList norece = doc.SelectNodes("//RecentProfile");
            
            for (int k = 0; k < norece.Count; k++)
            {

            }
        }
        private void LoadVideoEncodingOptions()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Module.VideoOptionsFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not load Video Encoding Options File !");
                return;
            }

            XmlNodeList novos = doc.SelectNodes("//Volume");

            cmbVolume.Items.Add("");
            cmbMixVolume.Items.Add("");

            for (int k = 0; k < novos.Count; k++)
            {
                cmbVolume.Items.Add(novos[k].InnerText);
                cmbMixVolume.Items.Add(novos[k].InnerText);
            }

            XmlNodeList nochan = doc.SelectNodes("//AudioChannel");

            cmbAudioChannels.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbAudioChannels.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//VideoSize");

            cmbVideoSize.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoSize.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//AspectRatio");

            cmbVideoAspectRatio.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoAspectRatio.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//VideoBitrate");

            cmbVideoBitrate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoBitrate.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//AudioBitrate");

            cmbAudioBitrate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbAudioBitrate.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//AudioSampleRate");

            cmbSampleRate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbSampleRate.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//FrameRate");

            cmbVideoFrameRate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoFrameRate.Items.Add(nochan[k].InnerText);
            }

            cmbDrawTextX.Items.Add("");
            cmbDrawTextX.Items.Add(TranslateHelper.Translate("<Value>"));
            cmbDrawTextX.Items.Add(TranslateHelper.Translate("Left"));
            cmbDrawTextX.Items.Add(TranslateHelper.Translate("Center"));
            cmbDrawTextX.Items.Add(TranslateHelper.Translate("Right"));

            cmbDrawTextY.Items.Add("");
            cmbDrawTextY.Items.Add(TranslateHelper.Translate("<Value>"));
            cmbDrawTextY.Items.Add(TranslateHelper.Translate("Top"));
            cmbDrawTextY.Items.Add(TranslateHelper.Translate("Middle"));
            cmbDrawTextY.Items.Add(TranslateHelper.Translate("Bottom"));

            cmbOverlayX.Items.Add("");
            cmbOverlayX.Items.Add(TranslateHelper.Translate("<Value>"));
            cmbOverlayX.Items.Add(TranslateHelper.Translate("Left"));
            cmbOverlayX.Items.Add(TranslateHelper.Translate("Center"));
            cmbOverlayX.Items.Add(TranslateHelper.Translate("Right"));

            cmbOverlayY.Items.Add("");
            cmbOverlayY.Items.Add(TranslateHelper.Translate("<Value>"));
            cmbOverlayY.Items.Add(TranslateHelper.Translate("Top"));
            cmbOverlayY.Items.Add(TranslateHelper.Translate("Middle"));
            cmbOverlayY.Items.Add(TranslateHelper.Translate("Bottom"));

            cmbDrawTextScroll.Items.Add("");
            cmbDrawTextScroll.Items.Add(TranslateHelper.Translate("Left to Right"));
            cmbDrawTextScroll.Items.Add(TranslateHelper.Translate("Right to Left"));
            cmbDrawTextScroll.Items.Add(TranslateHelper.Translate("Bottom to Top"));
            cmbDrawTextScroll.Items.Add(TranslateHelper.Translate("Top to Bottom"));
            cmbDrawTextScroll.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbDrawTextScrollSpeed.Items.Add("");
            cmbDrawTextScrollSpeed.Items.Add("150");
            cmbDrawTextScrollSpeed.Items.Add("250");
            cmbDrawTextScrollSpeed.Items.Add("100");
            cmbDrawTextScrollSpeed.Items.Add("50");
            
        }

        private void LoadSettings()
        {
            cmbVideoBitrate.Text = Properties.Settings.Default.OFVideoBitrate;
            cmbVideoFrameRate.Text = Properties.Settings.Default.OFFrameRate;
            cmbVideoSize.Text = Properties.Settings.Default.OFVideoSize;
            cmbVolume.Text = Properties.Settings.Default.OFVolume;
            cmbAudioBitrate.Text = Properties.Settings.Default.OFAudioBitrate;
            cmbAudioChannels.Text = Properties.Settings.Default.OFAudioChannels;
            cmbSampleRate.Text = Properties.Settings.Default.OFSampleRate;
            cmbVideoAspectRatio.Text = Properties.Settings.Default.OFAspectRatio;

            chkTwoPass.Checked = Properties.Settings.Default.OFTwoPass;
            chkDeinterlace.Checked = Properties.Settings.Default.OFDeinterlace;

            txtFFMpeg1stPass.Text = Properties.Settings.Default.OF1stPassParameters;
            txtFFMpeg2ndPass.Text = Properties.Settings.Default.OF2ndPassParameters;
            txtFFMpegAddParameters.Text = Properties.Settings.Default.OFAdditionalParameters;

            chkNormalize.Checked = Properties.Settings.Default.OFAudioNormalize;

            chkMute.Checked = Properties.Settings.Default.OFMute;

            chkCopyMetadata.Checked = Properties.Settings.Default.OFKeepMetadata;

            chkFadeIn.Checked = Properties.Settings.Default.FadeIn;
            nudFadeIn.Value = Properties.Settings.Default.FadeInSecondsVal;

            chkFadeOut.Checked = Properties.Settings.Default.FadeOut;
            nudFadeOut.Value = Properties.Settings.Default.FadeOutSecondsVal;

            chkReplaceAudio.Checked = Properties.Settings.Default.OFReplaceAudio;
            chkMixAudio.Checked = Properties.Settings.Default.OFMixAudio;
            txtMixAudioFile.Text = Properties.Settings.Default.OFMixAudioFIle;
            cmbMixVolume.Text = Properties.Settings.Default.OFMixVolume;

            chkDrawText.Checked = Properties.Settings.Default.OFDrawText;
            chkDrawTextFrom.Checked = Properties.Settings.Default.OFDrawTextFrom;
            chkDrawTextShadow.Checked = Properties.Settings.Default.OFDrawTextShadow;
            chkDrawTextTo.Checked = Properties.Settings.Default.OFDrawTextTo;
            txtDrawTextText.Text = Properties.Settings.Default.OFDrawTextText;
            txtDrawTextFromTime.Text = Properties.Settings.Default.OFDrawTextFromTime;
            txtDrawTextToTime.Text = Properties.Settings.Default.OFDrawTextToTime;
            cmbDrawTextFont.Text = Properties.Settings.Default.OFDrawTextFont;
            btnDrawTextFontColor.BackColor = Properties.Settings.Default.OFDrawTextFontColor;
            btnDrawTextShadowColor.BackColor = Properties.Settings.Default.OFDrawTextShadowColor;
            cmbDrawTextX.Text = Properties.Settings.Default.OFDrawTextX;
            cmbDrawTextY.Text = Properties.Settings.Default.OFDrawTextY;
            nudDrawTextFontSize.Value = (decimal)Properties.Settings.Default.OFDrawTextFontSize;

            chkOverlay.Checked = Properties.Settings.Default.OFOverlay;
            txtOverlayImageFile.Text = Properties.Settings.Default.OFOverlayImageFile;
            cmbOverlayX.Text = Properties.Settings.Default.OFOverlayX;
            cmbOverlayY.Text = Properties.Settings.Default.OFOverlayY;

            cmbDrawTextScroll.SelectedIndex = Properties.Settings.Default.OFDrawTextScroll;
            cmbDrawTextScrollSpeed.Text = Properties.Settings.Default.OFDrawTextScrollSpeed;

            chkQuickJoin.Checked = Properties.Settings.Default.OFQuickJoin;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.OFVideoBitrate = cmbVideoBitrate.Text;
            Properties.Settings.Default.OFFrameRate = cmbVideoFrameRate.Text;
            Properties.Settings.Default.OFVideoSize = cmbVideoSize.Text;
            Properties.Settings.Default.OFVolume = cmbVolume.Text;
            Properties.Settings.Default.OFAudioBitrate = cmbAudioBitrate.Text;
            Properties.Settings.Default.OFAudioChannels = cmbAudioChannels.Text;
            Properties.Settings.Default.OFSampleRate = cmbSampleRate.Text;
            Properties.Settings.Default.OFAspectRatio = cmbVideoAspectRatio.Text;

            Properties.Settings.Default.OFTwoPass = chkTwoPass.Checked;
            Properties.Settings.Default.OFDeinterlace = chkDeinterlace.Checked;

            Properties.Settings.Default.OF1stPassParameters = txtFFMpeg1stPass.Text;
            Properties.Settings.Default.OF2ndPassParameters = txtFFMpeg2ndPass.Text;
            Properties.Settings.Default.OFAdditionalParameters = txtFFMpegAddParameters.Text;

            Properties.Settings.Default.OFAudioNormalize = chkNormalize.Checked;
            Properties.Settings.Default.OFMute = chkMute.Checked;

            Properties.Settings.Default.OFKeepMetadata = chkCopyMetadata.Checked;

            Properties.Settings.Default.FadeIn = chkFadeIn.Checked;
            Properties.Settings.Default.FadeInSecondsVal = nudFadeIn.Value;

            Properties.Settings.Default.FadeOut = chkFadeOut.Checked;
            Properties.Settings.Default.FadeOutSecondsVal = nudFadeOut.Value;

            Properties.Settings.Default.OFReplaceAudio = chkReplaceAudio.Checked;
            Properties.Settings.Default.OFMixAudio = chkMixAudio.Checked;
            Properties.Settings.Default.OFMixAudioFIle = txtMixAudioFile.Text;
            Properties.Settings.Default.OFMixVolume = cmbMixVolume.Text;

            Properties.Settings.Default.OFDrawText = chkDrawText.Checked;
            Properties.Settings.Default.OFDrawTextFrom = chkDrawTextFrom.Checked;
            Properties.Settings.Default.OFDrawTextShadow = chkDrawTextShadow.Checked;
            Properties.Settings.Default.OFDrawTextTo = chkDrawTextTo.Checked;

            //byte[] bytestxt = Encoding.Default.GetBytes(txtDrawTextText.Text);
            //string utf8txt = Encoding.ASCII.GetString(bytestxt);
            string utf8txt = txtDrawTextText.Text;            

            Properties.Settings.Default.OFDrawTextText = utf8txt;
            Properties.Settings.Default.OFDrawTextFromTime = txtDrawTextFromTime.Text;
            Properties.Settings.Default.OFDrawTextToTime = txtDrawTextToTime.Text;
            
            Properties.Settings.Default.OFDrawTextFont = cmbDrawTextFont.Text;
            Properties.Settings.Default.OFDrawTextFontColor = btnDrawTextFontColor.BackColor;
            Properties.Settings.Default.OFDrawTextShadowColor = btnDrawTextShadowColor.BackColor;

            Properties.Settings.Default.OFDrawTextX = cmbDrawTextX.Text;
            Properties.Settings.Default.OFDrawTextY = cmbDrawTextY.Text;
            Properties.Settings.Default.OFDrawTextFontSize = (int)nudDrawTextFontSize.Value;

            Properties.Settings.Default.OFOverlay = chkOverlay.Checked;
            Properties.Settings.Default.OFOverlayImageFile = txtOverlayImageFile.Text;
            Properties.Settings.Default.OFOverlayX = cmbOverlayX.Text;
            Properties.Settings.Default.OFOverlayY = cmbOverlayY.Text;

            Properties.Settings.Default.OFDrawTextScroll = cmbDrawTextScroll.SelectedIndex;
            Properties.Settings.Default.OFDrawTextScrollSpeed = cmbDrawTextScrollSpeed.Text.Trim();

            Properties.Settings.Default.OFQuickJoin = chkQuickJoin.Checked;
        }

        private void SaveOutputFormatResult()
        {
            OutputFormatResult.videoBitRate = cmbVideoBitrate.Text;
            OutputFormatResult.videoFrameRate = cmbVideoFrameRate.Text;
            OutputFormatResult.videoSize = cmbVideoSize.Text;
            OutputFormatResult.audioVolume = cmbVolume.Text;
            OutputFormatResult.audioBitRate = cmbAudioBitrate.Text;
            OutputFormatResult.audioChannels = cmbAudioChannels.Text;
            OutputFormatResult.audioSampleRate = cmbSampleRate.Text;
            OutputFormatResult.videoAspectRatio = cmbVideoAspectRatio.Text;

            OutputFormatResult.videoTwoPass = chkTwoPass.Checked;
            OutputFormatResult.videoDeinterlace = chkDeinterlace.Checked;

            OutputFormatResult.firstPassArgs = txtFFMpeg1stPass.Text;
            OutputFormatResult.secondPassArgs = txtFFMpeg2ndPass.Text;
            OutputFormatResult.additionalArgs = txtFFMpegAddParameters.Text;

            OutputFormatResult.audioNormalize = chkNormalize.Checked;
            OutputFormatResult.audioMute = chkMute.Checked;

            OutputFormatResult.copyMetadata = chkCopyMetadata.Checked;

            OutputFormatResult.fadeIn = chkFadeIn.Checked;
            OutputFormatResult.fadeInSeconds = nudFadeIn.Value;

            OutputFormatResult.fadeOut = chkFadeOut.Checked;
            OutputFormatResult.fadeOutSeconds = nudFadeOut.Value;

            OutputFormatResult.replaceAudio = chkReplaceAudio.Checked;
            OutputFormatResult.mixAudio = chkMixAudio.Checked;
            OutputFormatResult.mixAudioFile = txtMixAudioFile.Text;
            OutputFormatResult.mixVolume = cmbMixVolume.Text;

            OutputFormatResult.DrawTextArgs.drawText = chkDrawText.Checked;
            OutputFormatResult.DrawTextArgs.drawTextFrom = chkDrawTextFrom.Checked;
            OutputFormatResult.DrawTextArgs.drawTextShadow = chkDrawTextShadow.Checked;
            OutputFormatResult.DrawTextArgs.drawTextTo = chkDrawTextTo.Checked;
            OutputFormatResult.DrawTextArgs.drawTextText = txtDrawTextText.Text;
            OutputFormatResult.DrawTextArgs.drawTextFromTime = txtDrawTextFromTime.Text;
            OutputFormatResult.DrawTextArgs.drawTextFromTime = txtDrawTextToTime.Text;
            OutputFormatResult.DrawTextArgs.drawTextFont = cmbDrawTextFont.Text;
            OutputFormatResult.DrawTextArgs.drawTextFontColor = btnDrawTextFontColor.BackColor;
            OutputFormatResult.DrawTextArgs.drawTextShadowColor = btnDrawTextShadowColor.BackColor;

            OutputFormatResult.DrawTextArgs.drawTextX  = cmbDrawTextX.Text;
            OutputFormatResult.DrawTextArgs.drawTextY = cmbDrawTextY.Text;
            OutputFormatResult.DrawTextArgs.drawTextFontSize = (int)nudDrawTextFontSize.Value;

            OutputFormatResult.OverlayArgs.Overlay = chkOverlay.Checked;
            OutputFormatResult.OverlayArgs.OverlayImageFile = txtOverlayImageFile.Text;
            OutputFormatResult.OverlayArgs.OverlayX = cmbOverlayX.Text;
            OutputFormatResult.OverlayArgs.OverlayY = cmbOverlayY.Text;

            OutputFormatResult.DrawTextArgs.scrollText = cmbDrawTextScroll.SelectedIndex;
            OutputFormatResult.DrawTextArgs.scrollTextSpeed = cmbDrawTextScrollSpeed.Text.Trim();

            OutputFormatResult.quickJoin = chkQuickJoin.Checked;
        }

        private void LoadOutputFormatResult()
        {
            cmbVideoBitrate.Text = OutputFormatResult.videoBitRate;
            cmbVideoFrameRate.Text = OutputFormatResult.videoFrameRate;
            cmbVideoSize.Text = OutputFormatResult.videoSize;
            cmbVolume.Text = OutputFormatResult.audioVolume;
            cmbAudioBitrate.Text = OutputFormatResult.audioBitRate;
            cmbAudioChannels.Text = OutputFormatResult.audioChannels;
            cmbSampleRate.Text = OutputFormatResult.audioChannels;
            cmbVideoAspectRatio.Text = OutputFormatResult.videoAspectRatio;

            chkTwoPass.Checked = OutputFormatResult.videoTwoPass;
            chkDeinterlace.Checked = OutputFormatResult.videoDeinterlace;

            txtFFMpeg1stPass.Text = OutputFormatResult.firstPassArgs;
            txtFFMpeg2ndPass.Text = OutputFormatResult.secondPassArgs;
            txtFFMpegAddParameters.Text = OutputFormatResult.additionalArgs;

            chkNormalize.Checked = OutputFormatResult.audioNormalize;
            chkMute.Checked = OutputFormatResult.audioMute;

            chkCopyMetadata.Checked = OutputFormatResult.copyMetadata;

            chkFadeIn.Checked = OutputFormatResult.fadeIn;
            nudFadeIn.Value = OutputFormatResult.fadeInSeconds;

            chkFadeOut.Checked = OutputFormatResult.fadeOut;
            nudFadeOut.Value = OutputFormatResult.fadeOutSeconds;

            chkReplaceAudio.Checked = OutputFormatResult.replaceAudio;
            chkMixAudio.Checked = OutputFormatResult.mixAudio;
            txtMixAudioFile.Text = OutputFormatResult.mixAudioFile;
            cmbMixVolume.Text = OutputFormatResult.mixVolume;

            chkDrawText.Checked = OutputFormatResult.DrawTextArgs.drawText;
            chkDrawTextFrom.Checked = OutputFormatResult.DrawTextArgs.drawTextFrom;
            chkDrawTextShadow.Checked = OutputFormatResult.DrawTextArgs.drawTextShadow;
            chkDrawTextTo.Checked = OutputFormatResult.DrawTextArgs.drawTextTo;
            txtDrawTextText.Text = OutputFormatResult.DrawTextArgs.drawTextText;
            txtDrawTextFromTime.Text = OutputFormatResult.DrawTextArgs.drawTextFromTime;
            txtDrawTextToTime.Text = OutputFormatResult.DrawTextArgs.drawTextFromTime;
            cmbDrawTextFont.Text = OutputFormatResult.DrawTextArgs.drawTextFont;
            btnDrawTextFontColor.BackColor = OutputFormatResult.DrawTextArgs.drawTextFontColor;
            btnDrawTextShadowColor.BackColor = OutputFormatResult.DrawTextArgs.drawTextShadowColor;

            cmbDrawTextX.Text = OutputFormatResult.DrawTextArgs.drawTextX;
            cmbDrawTextY.Text = OutputFormatResult.DrawTextArgs.drawTextY;
            nudDrawTextFontSize.Value = (decimal)OutputFormatResult.DrawTextArgs.drawTextFontSize;

            chkOverlay.Checked = OutputFormatResult.OverlayArgs.Overlay;
            txtOverlayImageFile.Text = OutputFormatResult.OverlayArgs.OverlayImageFile;
            cmbOverlayX.Text = OutputFormatResult.OverlayArgs.OverlayX;
            cmbOverlayY.Text = OutputFormatResult.OverlayArgs.OverlayY;

            cmbDrawTextScroll.SelectedIndex = OutputFormatResult.DrawTextArgs.scrollText;
            cmbDrawTextScrollSpeed.Text = OutputFormatResult.DrawTextArgs.scrollTextSpeed;

            chkQuickJoin.Checked = OutputFormatResult.quickJoin;

        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedIndices.Count == 0)
            {
                Module.ShowMessage("Please select a Profile first !");
                return;
            }

            frmProfile f = new frmProfile(SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name);

            if (f.ShowDialog() == DialogResult.OK)
            {
                FillProfiles(f.txtProfileName.Text.Trim().Replace("'",""), f.cmbCategory.Text.Trim().Replace("'",""));
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            btnBrowseMixAudio.DialogResult = System.Windows.Forms.DialogResult.None;

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = Module.AudioFilesFilter;

            if (openFileDialog1.ShowDialog(btnBrowseMixAudio) == DialogResult.OK)
            {
                txtMixAudioFile.Text = openFileDialog1.FileName;
            }

            btnBrowseMixAudio.DialogResult = System.Windows.Forms.DialogResult.None;
            
        }

        private void chkReplaceAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReplaceAudio.Checked)
            {
                chkMixAudio.Checked = false;
            }
        }

        private void chkMixAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMixAudio.Checked)
            {
                chkReplaceAudio.Checked = false;
            }
        }

        private void btnDrawTextFontColor_Click(object sender, EventArgs e)
        {
            if (btnDrawTextFontColor.BackColor!=Color.Transparent)
            {
                colorDialog1.Color = btnDrawTextFontColor.BackColor;
            }

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnDrawTextFontColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnDrawTextShadowColor_Click(object sender, EventArgs e)
        {
            if (btnDrawTextShadowColor.BackColor != Color.Transparent)
            {
                colorDialog1.Color = btnDrawTextShadowColor.BackColor;
            }

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnDrawTextShadowColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnDrawTextFontBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Font Files (*.ttf)|*.ttf|All Files (*.*)|*.*";

            string windir = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName;

            string fontsdir = System.IO.Path.Combine(windir, "fonts");
            try
            {
                openFileDialog1.InitialDirectory = fontsdir;
            }
            catch { }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cmbDrawTextFont.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowseOverlay_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Image Files (*.gif;*.png;*.jpg;*.jpeg;)|*.gif;*.png;*.jpg;*.jpeg;|All Files (*.*)|*.*";
            openFileDialog1.Multiselect=false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOverlayImageFile.Text = openFileDialog1.FileName;

                try
                {
                    Image img=Image.FromFile(openFileDialog1.FileName);

                    if (img.Width < picOverlay.Width && img.Height < picOverlay.Height)
                    {
                        picOverlay.SizeMode = PictureBoxSizeMode.Normal;
                    }
                    else
                    {
                        picOverlay.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    picOverlay.Image = img;

                }
                catch {
                    picOverlay.Image = null;
                }
            }
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedIndices.Count == 0)
            {
                Module.ShowMessage("Please select a Profile first !");
                return;
            }

            if (Module.ShowQuestionDialog("Are you sure that you want to Delete this Profile ?", TranslateHelper.Translate("Delete Profile ?"))
                == DialogResult.Yes)
            {                
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(Module.ProfilesFile);
                }
                catch
                {
                    Module.ShowMessage("Error. Could not read valid Profiles File !");
                    return;
                }

                XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name + "']");

                nod.ParentNode.RemoveChild(nod);

                doc.Save(Module.ProfilesFile);

                lvCategory_SelectedIndexChanged(null, null);

            }
        }
    }

    public class OutputFormatResult
    {
        public string outputext;
        public string outputparams;
        public string firstPassArgs;
        public string secondPassArgs;
        public string additionalArgs;
        public string videoBitRate;
        public string videoFrameRate;
        public string videoSize;
        public string videoAspectRatio;
        public bool videoTwoPass;
        public bool videoDeinterlace;
        public string audioBitRate;
        public string audioSampleRate;
        public string audioChannels;
        public string audioVolume;
        public bool audioNormalize;
        public bool audioMute;
        public bool copyMetadata;
        public bool fadeIn;
        public bool fadeOut;
        public decimal fadeInSeconds;
        public decimal fadeOutSeconds;
        public string mixAudioFile = "";
        public bool mixAudio=false;
        public bool replaceAudio = false;
        public string mixVolume = "";

        public DrawTextArgs DrawTextArgs = new DrawTextArgs();
        public OverlayArgs OverlayArgs = new OverlayArgs();

        public bool quickJoin = false;

        public string selectedProfile;
        public string selectedProfileCategory;

        public string extension;
        public string ffmpegParameters;

        public OutputFormatResult()
        {

        }
    }

    public class SelectedCategoryProfile
    {
        public string Label="";
        public string Name="";

        public SelectedCategoryProfile()
        {

        }
    }

    public class SelectedCategoryComparer : IComparer<SelectedCategoryProfile>
    {
        public int Compare(SelectedCategoryProfile x, SelectedCategoryProfile y)
        {
            int icompareLabel = x.Label.CompareTo(y.Label);

            return icompareLabel;
        }
    }

    public class DrawTextArgs
    {
        public bool drawText = false;
        public string drawTextText = "";
        public string drawTextFont = "";
        public bool drawTextFrom = false;
        public bool drawTextTo = false;
        public string drawTextFromTime = "";
        public string drawTextToTime = "";
        public Color drawTextFontColor = Color.Black;
        public Color drawTextShadowColor = Color.Silver;
        public bool drawTextShadow = false;
        public string drawTextX = "";
        public string drawTextY = "";
        public int drawTextFontSize = 36;
        public int scrollText=0;
        public string scrollTextSpeed;

        public DrawTextArgs()
        {
        }
    }

    public class OverlayArgs
    {
        public bool Overlay = false;
        public string OverlayImageFile="";
        public string OverlayX = "";
        public string OverlayY = "";

        public OverlayArgs() { }        
    }
}
