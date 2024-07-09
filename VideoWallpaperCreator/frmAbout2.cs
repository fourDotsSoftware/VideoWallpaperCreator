using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class frmAbout2 : CustomForm
    {
        public static string lblf = "";

        // license email
        public static string LDT = "";

        public frmAbout2()
        {
            InitializeComponent();
        }
                     
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Module.ApplicationTitle + "\n\n" +
            "Developed by Alexander Triantafyllou\n" +
            "Copyright © 2020 - softpcapps Software\n";

            ullProductWebpage.Text = Module.ProductWebpageURL;

            btnRegister.Visible = false;
            btnBuy.Visible = false;

            /*//3
            if (frmAbout2.LDT == string.Empty)
            {
                lblRegistered.Text = TranslateHelper.Translate("Trial Version - Unlicensed");
            }
            else
            {
                lblRegistered.Text = TranslateHelper.Translate("Business Version - Licensed");
            }

            lblLicenseKey.Text = frmAbout2.LDT;

            if (frmAbout2.LDT != string.Empty)
            {
                btnRegister.Visible = false;
                btnBuy.Visible = false;
            }
            */
            /*
            if (!SettingsHelper.RenMove && !frmPurchase.RenMove)
            {
                if (frmAbout2.LDT == string.Empty)
                {
                    lblRegistered.Text = TranslateHelper.Translate("Trial Version - Unlicensed");
                }
                else
                {
                    lblRegistered.Text = TranslateHelper.Translate("Business Version - Licensed");
                }
                
                lblLicenseKey.Text = frmAbout2.LDT;

                if (frmAbout2.LDT != string.Empty)
                {
                    btnRegister.Visible = false;
                    btnBuy.Visible = false;
                }
            }
            else
            {
                lblRegistered.Text = TranslateHelper.Translate("Trial Version - Unlicensed");
            }*/
        }
                
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/support/");
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
        }
    }
}