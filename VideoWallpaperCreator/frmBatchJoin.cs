using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace VideoWallpaperCreator
{
    public partial class frmBatchJoin : VideoWallpaperCreator.CustomForm
    {
        public static DataTable dt = new System.Data.DataTable("table");
        public static frmBatchJoin Instance = null;
        public OutputFormatResult DefaultOutputFormatResult = null;
        private OutputFormatResult LastOutputFormatResult = null;

        public frmBatchJoin()
        {
            InitializeComponent();

            Instance = this;

            colOutputFile.DataPropertyName = "outputfile";
            colJoinNumber.DataPropertyName = "joinnumber";
                        
            DataGridViewTextBoxColumnWithEnter dtb = new DataGridViewTextBoxColumnWithEnter();
            dgBatchJoin.Columns.Add(dtb);
            dtb.DisplayIndex = 1;
            dtb.DataPropertyName = "joinvideos";
            dtb.HeaderText = TranslateHelper.Translate("Join Videos Filepaths");
            dtb.Name = "colJoinVideos";

            DataGridViewTextBoxColumn dcr = new DataGridViewTextBoxColumn();
            dcr.DataPropertyName = "outputformatres";
            dcr.Visible = false;
            dcr.Name = "colOutputFormatRes";
            dgBatchJoin.Columns.Add(dcr);            
            
            dgBatchJoin.AutoGenerateColumns = false;
            dgBatchJoin.DataSource = dt;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                dt.Rows[k]["joinnumber"] = (k + 1).ToString();
            }
        }

        public static void SetupDataTable()
        {
            dt.Columns.Add("joinnumber", typeof(int));
            dt.Columns.Add("joinvideos");
            dt.Columns.Add("outputfile");
            dt.Columns.Add("joinargs", typeof(JoinArgs));
            dt.Columns.Add("outputformatres", typeof(OutputFormatResult));
            dt.Columns.Add("selected", typeof(bool));

            dt.TableNewRow += dt_TableNewRow;
            dt.RowDeleted += dt_RowDeleted;
            dt.RowChanged += dt_RowChanged;
        }

        static void dt_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            UpdateInfo();
        }

        static void dt_RowDeleted(object sender, System.Data.DataRowChangeEventArgs e)
        {
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                dt.Rows[k]["joinnumber"] = (k + 1).ToString();
            }

            UpdateInfo();
        }

        static void dt_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
        {
            int ind = dt.Rows.Count + 1;
            e.Row["joinnumber"] = ind;

            if (frmBatchJoin.Instance != null)
            {
                e.Row["outputformatres"] = frmBatchJoin.Instance.DefaultOutputFormatResult;
            }

            UpdateInfo();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgBatchJoin.CurrentCell != null && dgBatchJoin.SelectedRows.Count == 0)
            {
                int ind = dgBatchJoin.CurrentCell.RowIndex;

                dgBatchJoin.Rows[dgBatchJoin.CurrentCell.RowIndex].Selected = true;
                dgBatchJoin.CurrentCell = null;
                dgBatchJoin.Rows[ind].Selected = true;
            }

            if (dgBatchJoin.SelectedRows == null || dgBatchJoin.SelectedRows.Count == 0) return;

            List<DataRow> drs = new List<System.Data.DataRow>();


            for (int k = 0; k < dgBatchJoin.SelectedRows.Count; k++)
            {
                DataRowView drv = (DataRowView)dgBatchJoin.SelectedRows[k].DataBoundItem;
                drs.Add(drv.Row);
            }

            for (int k = 0; k < drs.Count; k++)
            {
                try
                {
                    dt.Rows.Remove(drs[k]);
                }
                catch { }
            }


        }

        private static void UpdateInfo()
        {
            /*
            int tdur = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                dt.Rows[k]["ind"] = k + 1;
                tdur += ((int)dt.Rows[k]["durationmsecs"]);
            }
            */

            int cnt = 0;

            if (dt.Rows.Count > 0)
            {
                cnt = (int)dt.Rows[dt.Rows.Count - 1]["joinnumber"];
            }

            if (frmBatchJoin.Instance != null)
            {
                frmBatchJoin.Instance.slblTotalVideos.Text = TranslateHelper.Translate("Total Videos") + " : " + cnt;
            }
            //slblTotalDuration.Text = TranslateHelper.Translate("Total Duration") + " : " + FFMpegArgsHelperJoin.GetStringFromTime(tdur);
        }

        private void frmBatchJoin_Load(object sender, EventArgs e)
        {
            frmOutputFormat f = new frmOutputFormat(true);

            if (f.ShowDialog() == DialogResult.Cancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                DefaultOutputFormatResult = f.OutputFormatResult;
            }

            //RecentFilesHelper.FillBatchJoinRecentFile();
            //RecentFilesHelper.FillBatchJoinRecentFolders();

            dgBatchJoin.AllowDrop = true;
            dgBatchJoin.DragDrop += dgVideo_DragDrop;
            dgBatchJoin.DragEnter += dgVideo_DragEnter;
            dgBatchJoin.DragOver += dgVideo_DragOver;
        }

        #region Import - Enter List

        private void importBatchListFromTextFileMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

                    using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName))
                    {
                        string line = null;

                        string joinvideos = "";
                        string outputfile = "";
                        bool newjoin = true;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line == string.Empty)
                            {
                                newjoin = true;

                                DataRow dr = dt.NewRow();

                                dr["joinvideos"] = joinvideos;
                                dr["outputfile"] = outputfile;

                                joinvideos = "";
                                outputfile = "";

                                dt.Rows.Add(dr);

                                continue;
                            }

                            string fullfilepath = System.IO.Path.GetFullPath(line);

                            try
                            {
                                if (newjoin)
                                {
                                    outputfile = fullfilepath;
                                    newjoin = false;
                                }
                                else
                                {
                                    joinvideos += fullfilepath + Environment.NewLine;
                                }

                            }
                            catch (Exception ex)
                            {
                                Module.ShowError("Error. Could not Add Video to list", ex);
                            }
                        }

                        if (!newjoin)
                        {
                            DataRow dr = dt.NewRow();

                            dr["joinvideos"] = joinvideos;
                            dr["outputfile"] = outputfile;

                            joinvideos = "";
                            outputfile = "";

                            dt.Rows.Add(dr);
                        }
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;
                }
            }
        }

        private void importBatchListFromCSVFileMenuItem_Click_Click(object sender, EventArgs e)
        {
            frmImportCSV f = new frmImportCSV(true);

            if (f.ShowDialog() == DialogResult.OK)
            {
                f.ImportCSVBatchJoinNew(f.txtFilepath.Text);
            }
        }

        private void importBatchListFromExcelFileMenuItem_Click_Click(object sender, EventArgs e)
        {
            frmImportExcel f = new frmImportExcel(true);

            if (f.ShowDialog() == DialogResult.OK)
            {
                f.ImportListExcelBatchJoinNew(f.txtFilepath.Text);
            }
        }

        private void enterBatchListMenuItem_Click(object sender, EventArgs e)
        {
            frmMultipleFiles f = new frmMultipleFiles(false, "");

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                using (System.IO.StringReader sr = new System.IO.StringReader(f.txtFiles.Text))
                {
                    string line = null;

                    string joinvideos = "";
                    string outputfile = "";
                    bool newjoin = true;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == string.Empty)
                        {
                            newjoin = true;

                            DataRow dr = dt.NewRow();

                            dr["joinvideos"] = joinvideos;
                            dr["outputfile"] = outputfile;

                            joinvideos = "";
                            outputfile = "";

                            dt.Rows.Add(dr);

                            continue;
                        }

                        string fullfilepath = System.IO.Path.GetFullPath(line);

                        try
                        {
                            if (newjoin)
                            {
                                outputfile = fullfilepath;
                                newjoin = false;
                            }
                            else
                            {
                                joinvideos += fullfilepath + Environment.NewLine;
                            }

                        }
                        catch (Exception ex)
                        {
                            Module.ShowError("Error. Could not Add Video to list", ex);
                        }
                    }

                    if (!newjoin)
                    {
                        DataRow dr = dt.NewRow();

                        dr["joinvideos"] = joinvideos;
                        dr["outputfile"] = outputfile;

                        joinvideos = "";
                        outputfile = "";

                        dt.Rows.Add(dr);
                    }
                }
            }
        }

        #endregion

        private void dgBatchJoin_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void dgBatchJoin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colBrowseJoinVideos.Index)            
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Multiselect = true;
                openFileDialog1.Filter = Module.OpenFilesFilter;                

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    for (int k=0;k<openFileDialog1.FileNames.Length;k++)
                    {
                        //dt.Rows[ind]["joinvideos"]+=
                        dgBatchJoin.CurrentRow.Cells["colJoinVideos"].Value +=
                            openFileDialog1.FileNames[k] + Environment.NewLine;
                        
                    }                    
                }
            }
            else if (e.ColumnIndex == colBrowseOutputFile.Index)
            {
                saveFileDialog1.FileName = "";                
                saveFileDialog1.Filter = Module.OpenFilesFilter;                

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    for (int k = 0; k < saveFileDialog1.FileNames.Length; k++)
                    {
                        dgBatchJoin.CurrentRow.Cells["colOutputFile"].Value =
                        //dt.Rows[ind]["outputfile"] +=
                            saveFileDialog1.FileNames[k] + Environment.NewLine;                        
                    }                    
                }                
            }
            else if (e.ColumnIndex == colOutputFormat.Index)
            {
                OutputFormatResult res = (OutputFormatResult)dgBatchJoin.CurrentRow.Cells["colOutputFormatRes"].Value;

                if (res != null)
                {
                    frmOutputFormat f = new frmOutputFormat(res);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        dgBatchJoin.CurrentRow.Cells["colOutputFormatRes"].Value = f.OutputFormatResult;
                    }
                }
                else
                {
                    frmOutputFormat f = new frmOutputFormat(DefaultOutputFormatResult);

                    if (f.ShowDialog() == DialogResult.OK)
                    {                        
                        dgBatchJoin.CurrentRow.Cells["colOutputFormatRes"].Value = f.OutputFormatResult;
                    }
                }

                //DataRowView drv = (DataRowView)dgBatchJoin.CurrentRow.DataBoundItem;
                //DataRow dr = (DataRow)drv.Row;
                /*
                if (dt.Rows.IndexOf(dr) >= 0)
                {
                    OutputFormatResult res = dgBatchJoin.CurrentRow.Cells["colOutputFormatRes"].Value;
                    //(OutputFormatResult)dt.Rows[dt.Rows.IndexOf(dr)]["outputformatres"];
                    frmOutputFormat f = new frmOutputFormat(res);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        //LastOutputFormatResult = f.OutputFormatResult;
                        dgBatchJoin.CurrentRow.Cells["colOutputFormatRes"].Value = f.OutputFormatResult;
                    }
                }
                else
                {                    
                    frmOutputFormat f = new frmOutputFormat(DefaultOutputFormatResult);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        //LastOutputFormatResult = f.OutputFormatResult;

                        //dt.Rows[dgBatchJoin.CurrentRow.Index]["outputformatres"] = f.OutputFormatResult;
                        dgBatchJoin.CurrentRow.Cells["colOutputFormatRes"].Value = f.OutputFormatResult;
                    }
                }*/
            }
        }

        private void dgBatchJoin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dt.Rows.Count > e.RowIndex)
                {
                    if (e.ColumnIndex == dgBatchJoin.Columns["colJoinVideos"].Index)
                    {
                        dt.Rows[dgBatchJoin.CurrentRow.Index]["joinvideos"] = dgBatchJoin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    }
                    else if (e.ColumnIndex == dgBatchJoin.Columns["colOutputFile"].Index)
                    {
                        dt.Rows[dgBatchJoin.CurrentRow.Index]["outputfile"] = dgBatchJoin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    }
                    else if (e.ColumnIndex == dgBatchJoin.Columns["colOutputFormat"].Index)
                    {
                        dt.Rows[dgBatchJoin.CurrentRow.Index]["outputformatres"] = dgBatchJoin.Rows[e.RowIndex].Cells["colOutputFormatRes"].Value;
                    }
                }
            }
            catch { }
        }

        private void tsCut_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }

        private void executeBatchJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int totaldur = 0;
            List<JoinArgs> lstj = new List<JoinArgs>();

            for (int k = 0; k < dt.Rows.Count; k++)
            {
               if (Convert.IsDBNull(dt.Rows[k]["joinvideos"])) continue;

                string str = (string)dt.Rows[k]["joinvideos"];

                string[] filez = str.Split(new string[] { Environment.NewLine}, StringSplitOptions.None);

                DataTable dtj=new System.Data.DataTable("table");
                dtj.Columns.Add("videoimg", typeof(Image));
                dtj.Columns.Add("ind", typeof(int));
                dtj.Columns.Add("durationmsecs", typeof(int));
                dtj.Columns.Add("videoinfo", typeof(FFMPEGInfo));            
                dtj.Columns.Add("selected",typeof(bool));

                for (int m = 0; m < filez.Length; m++)
                {
                    if (filez[m].Trim() == string.Empty) continue;

                    if (!System.IO.File.Exists(filez[m]))
                    {
                        Module.ShowMessage(TranslateHelper.Translate("Error ! Video File does not exist ! ") + "\r\n" + filez[m]);
                        dgBatchJoin.CurrentCell = dgBatchJoin.Rows[k].Cells["colJoinVideos"];
                        return;
                    }

                    FFMPEGInfo finfo=new FFMPEGInfo(filez[m]);

                    if (finfo.DurationMsecs!=0)
                    {
                        DataRow dr = dtj.NewRow();
                        dr["videoimg"] = null;
                        dr["durationmsecs"] = finfo.DurationMsecs;
                        dr["videoinfo"] = finfo;
                        
                        dtj.Rows.Add(dr);
                    }
                    else
                    {
                        Module.ShowMessage(TranslateHelper.Translate("Error ! Not valid Video File !")+"\r\n"+filez[m]);
                        dgBatchJoin.CurrentCell = dgBatchJoin.Rows[k].Cells["colJoinVideos"];
                        return;
                    }
                }

                string outputfile=dt.Rows[k]["outputfile"].ToString();

                if (outputfile != string.Empty && !Module.IsLegalFilename(outputfile))
                {
                    Module.ShowMessage(TranslateHelper.Translate("Error ! Output Video File does not have a valid Filename !") + "\r\n" + outputfile);
                    dgBatchJoin.CurrentCell = dgBatchJoin.Rows[k].Cells["colOutputFile"];
                    return;
                }
                else
                {

                }

                OutputFormatResult res = (OutputFormatResult)dt.Rows[k]["outputformatres"];

                if (res == null)
                {
                    res = DefaultOutputFormatResult;
                }

                string previousExpOut = frmMain.Instance.ExplicitOutputFilepath;

                frmMain.Instance.ExplicitOutputFilepath = outputfile;

                JoinArgsHelper jhelper = new JoinArgsHelper(dtj);
                JoinArgs jargs=jhelper.GetJoinArgs(res);
                totaldur += jargs.DurationMsecs;
                lstj.Add(jargs);

                frmMain.Instance.ExplicitOutputFilepath = previousExpOut;
            }

            frmMain.Instance.ExecuteBatchJoins(lstj, totaldur);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgBatchJoin.SelectAll();
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgBatchJoin.ClearSelection();
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgBatchJoin.Rows.Count; k++)
            {
                dgBatchJoin.Rows[k].Selected = !dgBatchJoin.Rows[k].Selected;
            }
        }

        private void setOutputFormatForSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgBatchJoin.SelectedRows == null || dgBatchJoin.SelectedRows.Count == 0)
            {
                Module.ShowMessage("Please Select some Rows first !");
                return;
            }

            frmOutputFormat f = new frmOutputFormat(true);

            if (f.ShowDialog() == DialogResult.OK)
            {
                for (int k = 0; k < dgBatchJoin.Rows.Count; k++)
                {
                    dgBatchJoin.Rows[k].Cells["outputformatres"].Value = f.OutputFormatResult;
                }
            }
        }

        #region Drag and Drop

        private void dgVideo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgVideo_DragOver(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dgVideo_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (System.IO.File.Exists(filez[k]))
                        {                            
                           dgBatchJoin.CurrentRow.Cells["colJoinVideos"].Value +=
                                    filez[k] + Environment.NewLine;
                            
                        }
                        else if (System.IO.Directory.Exists(filez[k]))
                        {
                            string[] dirfz = System.IO.Directory.GetFiles(filez[k], "*.*", System.IO.SearchOption.AllDirectories);

                            for (int m = 0; m < dirfz.Length; m++)
                            {
                                if (Module.IsAcceptableMediaInput(dirfz[m]))
                                {
                                    dgBatchJoin.CurrentRow.Cells["colJoinVideos"].Value +=
                                    dirfz[m] + Environment.NewLine;
                                }
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }
        }

        #endregion
    }
}
