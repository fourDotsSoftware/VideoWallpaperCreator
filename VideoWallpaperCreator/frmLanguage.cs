using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VideoWallpaperCreator
{
    public partial class frmLanguage : CustomForm
    {
        public static List<string> LangCodes = new List<string>();
        public static List<string> LangDesc = new List<string>();
        public static List<Image> LangImg = new List<Image>();               

        public static string SelectedLanguageCode = "";

        public static string LangURL = Module.ProductWebpageURL + "lang/";
        
        public static string RegKeyName = Module.ApplicationName;

        public frmLanguage()
        {
            InitializeComponent();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            /*
            if (!DownloadLanguage(LangCodes[cmbLanguage.SelectedIndex]))
            {
                SelectedLanguageCode = "en-US";
            }
            */

            SelectedLanguageCode = LangCodes[cmbLanguage.SelectedIndex];
            this.DialogResult = DialogResult.OK;
        }

        public static bool DownloadLanguage(string langcode,string lastversion,string languagesdownloaded,bool resetlangdown)
        {
            try
            {
                string dllfile = System.IO.Path.Combine(Application.StartupPath,  langcode +
                    "\\" + System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".resources.dll");

                //Module.ShowMessage(dllfile);

               // Module.ShowMessage("lastversion="+lastversion);

               // Module.ShowMessage("languagesdownloaded=" + languagesdownloaded);

                if (!frmLanguage.LangURL.EndsWith("/"))
                {
                    frmLanguage.LangURL = frmLanguage.LangURL + "/";
                }

                string downurl = frmLanguage.LangURL + langcode + "/"+System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".resources.dll";

                bool lang_has_been_downloaded = false;

                if (lastversion == Module.ApplicationTitle)
                {
                    if (languagesdownloaded.IndexOf(langcode + "|")>=0)
                    {
                        lang_has_been_downloaded = true;
                    }
                }
                
               // Module.ShowMessage(System.IO.File.Exists(dllfile).ToString());

                if (!System.IO.File.Exists(dllfile) || !lang_has_been_downloaded)
                {                    
                    System.Diagnostics.Process pr = new System.Diagnostics.Process();
                    pr.StartInfo.FileName = Application.StartupPath + "\\4dotsAdminActions.exe";
                    pr.StartInfo.Arguments = "\"" + downurl + "\" \"" + dllfile + "\"" + " \"" + RegKeyName + "\" \"" + langcode + "\" \"" + Module.ApplicationTitle + "\" \""+resetlangdown.ToString()+"\"";
                    pr.Start();

                    System.Threading.Thread.Sleep(300);

                    while (!pr.HasExited)
                    {
                        Application.DoEvents();
                    }

                    if (pr.ExitCode != 0)
                    {
                        Module.ShowMessage("Error Could not change Language !");
                        return false;
                    }

                    //Properties.Settings.Default.LanguagesDownloaded += langcode + "|";
                    //Properties.Settings.Default.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SetLanguages()
        {
            LangCodes.Add("en-US");
            LangCodes.Add("de-DE");
            LangCodes.Add("fr-FR");
            LangCodes.Add("es-ES");
            LangCodes.Add("pt-PT");            
            LangCodes.Add("it-IT");
            LangCodes.Add("zh-CHS");
            LangCodes.Add("ja-JP");
            LangCodes.Add("ru-RU");

            LangCodes.Add("zh-CHT");
            LangCodes.Add("nl-NL");
            LangCodes.Add("fi-FI");
            LangCodes.Add("da-DK");

            LangCodes.Add("nn-NO");
            LangCodes.Add("sv-SE");
            LangCodes.Add("el-GR");
            LangCodes.Add("ar-SA");
            LangCodes.Add("cs-CZ");
            LangCodes.Add("he-IL");
            LangCodes.Add("hu-HU");
            LangCodes.Add("is-IS");
            LangCodes.Add("ko-KR");
            LangCodes.Add("pl-PL");
            LangCodes.Add("ro-RO");
            LangCodes.Add("hr-HR");
            LangCodes.Add("sk-SK");
            LangCodes.Add("th-TH");
            LangCodes.Add("tr-TR");
            LangCodes.Add("id-ID");
            LangCodes.Add("uk-UA");
            LangCodes.Add("be-BY");
            LangCodes.Add("sl-SI");
            LangCodes.Add("et-EE");
            LangCodes.Add("lv-LV");
            LangCodes.Add("lt-LT");
            LangCodes.Add("fa-IR");
            LangCodes.Add("vi-VN");
            LangCodes.Add("ka-GE");
            LangCodes.Add("hi-IN");

            //------------

            LangCodes.Add("sr-Cyrl-RS");
            LangCodes.Add("ga-IE");
            LangCodes.Add("bg-BG");
            LangCodes.Add("sq-AL");
            LangCodes.Add("sw-KE");
            LangCodes.Add("af-ZA");
            LangCodes.Add("fil-PH");
            LangCodes.Add("ur-PK");                                  

            LangDesc.Add("English");
            LangDesc.Add("Deutsch");
            LangDesc.Add("Français");
            LangDesc.Add("Español");
            LangDesc.Add("Português");
            LangDesc.Add("Italiano");
            LangDesc.Add("中文");
            LangDesc.Add("日本の");
            LangDesc.Add("Pусский");

            LangDesc.Add("中國傳統");//Chinese Traditional
            LangDesc.Add("Nederlands");
            LangDesc.Add("Suomi");
            LangDesc.Add("Dansk");

            LangDesc.Add("Norske");
            LangDesc.Add("Svenskt");
            LangDesc.Add("Ελληνικά");
            LangDesc.Add("العربية");
            LangDesc.Add("český");
            LangDesc.Add("עברית");
            LangDesc.Add("Magyar");
            LangDesc.Add("Íslenska");
            LangDesc.Add("한국인");
            LangDesc.Add("Polski");
            LangDesc.Add("Român");
            LangDesc.Add("Hrvatski");
            LangDesc.Add("Slovenských");
            LangDesc.Add("คนไทย");
            LangDesc.Add("Türk");
            LangDesc.Add("Indonesia");
            LangDesc.Add("Yкраїнець");
            LangDesc.Add("беларускай");
            LangDesc.Add("Slovenski");
            LangDesc.Add("Eestlane");
            LangDesc.Add("Latvietis");
            LangDesc.Add("Lietuvis");
            LangDesc.Add("فارسی");
            LangDesc.Add("Việt");
            LangDesc.Add("საქართველოს");
            LangDesc.Add("हिंदी");
            //------------
            LangDesc.Add("Cрпски");//serbian
            LangDesc.Add("Irish");
            LangDesc.Add("български");//Bulgarian
            LangDesc.Add("Albanian");//Albanian
            LangDesc.Add("Swahili");
            LangDesc.Add("Afrikaans");
            LangDesc.Add("Filipino");                        
            LangDesc.Add("اردو");//urdu
            
            LangImg.Add((Image)ResFlags.flag_great_britain);
            LangImg.Add((Image)ResFlags.flag_germany);
            LangImg.Add((Image)ResFlags.flag_france);
            LangImg.Add((Image)ResFlags.flag_spain);
            LangImg.Add((Image)ResFlags.flag_portugal);
            LangImg.Add((Image)ResFlags.flag_italy);
            LangImg.Add((Image)ResFlags.flag_china);
            LangImg.Add((Image)ResFlags.flag_japan);
            LangImg.Add((Image)ResFlags.flag_russia);

            LangImg.Add((Image)ResFlags.flag_taiwan);
            LangImg.Add((Image)ResFlags.flag_netherlands);
            LangImg.Add((Image)ResFlags.flag_finland);
            LangImg.Add((Image)ResFlags.flag_denmark);
            LangImg.Add((Image)ResFlags.flag_norway);
            LangImg.Add((Image)ResFlags.flag_sweden);
            LangImg.Add((Image)ResFlags.flag_greece);
            LangImg.Add((Image)ResFlags.flag_saudi_arabia);
            LangImg.Add((Image)ResFlags.flag_czech_republic);
            LangImg.Add((Image)ResFlags.flag_israel);
            LangImg.Add((Image)ResFlags.flag_hungary);
            LangImg.Add((Image)ResFlags.flag_iceland);
            LangImg.Add((Image)ResFlags.flag_south_korea);
            LangImg.Add((Image)ResFlags.flag_poland);
            LangImg.Add((Image)ResFlags.flag_romania);
            LangImg.Add((Image)ResFlags.flag_croatia);
            LangImg.Add((Image)ResFlags.flag_slovenia);
            LangImg.Add((Image)ResFlags.flag_thailand);
            LangImg.Add((Image)ResFlags.flag_turkey);
            LangImg.Add((Image)ResFlags.flag_indonesia);
            LangImg.Add((Image)ResFlags.flag_ukraine);
            LangImg.Add((Image)ResFlags.flag_belarus);
            LangImg.Add((Image)ResFlags.flag_slovenia);
            LangImg.Add((Image)ResFlags.flag_estonia);
            LangImg.Add((Image)ResFlags.flag_latvia);
            LangImg.Add((Image)ResFlags.flag_lithuania);
            LangImg.Add((Image)ResFlags.flag_iran);
            LangImg.Add((Image)ResFlags.flag_vietnam);
            LangImg.Add((Image)ResFlags.flag_georgia);
            LangImg.Add((Image)ResFlags.flag_india);

            //------------
            LangImg.Add((Image)ResFlags.flag_serbia_montenegro);
            LangImg.Add((Image)ResFlags.flag_ireland);
            LangImg.Add((Image)ResFlags.flag_bulgaria);
            LangImg.Add((Image)ResFlags.flag_albania);
            LangImg.Add((Image)ResFlags.flag_kenya);
            LangImg.Add((Image)ResFlags.flag_south_africa);
            LangImg.Add((Image)ResFlags.flag_philippines);
            LangImg.Add((Image)ResFlags.flag_pakistan);

            
        }

        private void frmLanguage_Load(object sender, EventArgs e)
        {
            //chinese,dutch,finish,danish,japan,norway,russia,sweden
            /*
            cmbLanguage.Items.AddRange(new string[] { "English", "Deutsch", "Français", "Español", "Português",
            "Italiano", "中文", "Nederlands", "Suomi", "Dansk", "日本の", "Norske", "Pусский", "Svenskt",
            "Ελληνικά",
            "العربية","český","עברית","Magyar","Íslenska","한국인","Polski","Român","Hrvatski","Slovenských",
            "คนไทย","Türk","Indonesia","Yкраїнець","беларускай","Slovenski","Eestlane","Latvietis",
                "Lietuvis","فارسی","Việt","საქართველოს","हिंदी"
            
            });
            */

            

            cmbLanguage.ImageList = new ImageList();

            for (int k = 0; k < LangImg.Count; k++)
            {
                cmbLanguage.ImageList.Images.Add(LangImg[k]);
                cmbLanguage.Items.Add(new ComboBoxExItem(LangDesc[k],k));
            }
            
            cmbLanguage.SelectedIndex = 0;
        }

        public static void SetLanguage()
        {
            
            string lang = Properties.Settings.Default.Language;
            
            bool setlang = false;

            string lastversion = "";
            string languagesdownloaded = "";
            bool resetlangdown = false;

            RegistryKey keym = null;

            RegistryKey keym2 = null;

            

            try
            {
                keym = Registry.LocalMachine;
                
                keym2 = Registry.LocalMachine;

                keym = keym.OpenSubKey("Software\\softpcapps Software", false);
                                
                if (keym == null)
                {
                    keym = Registry.LocalMachine.CreateSubKey("SOFTWARE\\softpcapps Software");
                }

                
                keym2 = keym.OpenSubKey(frmLanguage.RegKeyName,false);

                if (keym2 == null)
                {
                    keym2 = keym.CreateSubKey(frmLanguage.RegKeyName);
                }
                                
                keym = keym2;
                            
                lastversion = keym.GetValue("LastVersion", "").ToString();
                languagesdownloaded = keym.GetValue("LanguagesDownloaded", "").ToString();
                                

            }
            catch 
            {
                setlang = true;
            }
            finally
            {
                if (keym != null)
                {
                    keym.Close();
                }

                if (keym2 != null)
                {
                    keym2.Close();
                }
            }

            
            if (lastversion != Module.ApplicationTitle && Properties.Settings.Default.Language!="en-US")
            {
                languagesdownloaded = "";
                resetlangdown = true;
                lastversion = Module.ApplicationTitle;
                
                setlang = true;
            }
                        

            if (Properties.Settings.Default.Language == string.Empty)
            {
                
                frmLanguage fl = new frmLanguage();
                fl.ShowDialog();
                Properties.Settings.Default.Language = frmLanguage.SelectedLanguageCode;
                lang = frmLanguage.SelectedLanguageCode;
                setlang = true;

                Properties.Settings.Default.Save();
            }

            Module.SelectedLanguage = lang;

            if (lang != "en-US")
            {
                if (!frmLanguage.DownloadLanguage(lang,lastversion,languagesdownloaded,resetlangdown))
                {
                    lang = "en-US";
                    Properties.Settings.Default.Language = "en-US";
                }
            }

            if (lang == "en-US")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    System.Globalization.CultureInfo.InvariantCulture;

                //Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            }
            else
            {
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new
                    System.Globalization.CultureInfo(lang);

                    //Application.CurrentCulture = new System.Globalization.CultureInfo(lang);
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                }
            }

            /*
            if (setlang)
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey key2 = Registry.CurrentUser;

                try
                {
                    key = key.OpenSubKey("Software\\softpcapps Software", true);

                    if (key == null)
                    {
                        key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\softpcapps Software");
                    }

                    key2 = key.OpenSubKey(RegKeyName, true);

                    if (key2 == null)
                    {
                        key2 = key.CreateSubKey(RegKeyName);
                    }

                    key = key2;

                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
                }
                catch (Exception exr)
                {
                    Module.ShowError(exr);
                }
                finally
                {
                    key.Close();
                    key2.Close();
                }
            }
            */
        }

    }
}



