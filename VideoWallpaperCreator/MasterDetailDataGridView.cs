using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;

namespace FreeFLACToMP3Converter4dots
{
    public class MasterDetailDataGridView : DataGridView
    {
        public List<bool> RowHasDetailTable = new List<bool>();
       
        public DataGridView PrototypeDetailGridView=null;

        public List<DataGridView> DetailDataGridView=new List<DataGridView>();

        public MasterDetailDataGridView()
            : base()
        {
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            
            if (this.Columns.Count > 0)
            {
                this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                for (int k = 1; k < this.Columns.Count; k++)
                {
                    this.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                }
            }

          }
        public MasterDetailDataGridView(MasterDetailDataGridView detailDataGridView)
            : this()
        {
            
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            /*
            for (int k = 0; k < e.RowCount; k++)
            {
                RowHasDetailTable.Insert(e.RowIndex + k, false);

                DataGridView dgdetail = new DataGridView();
                dgdetail.DefaultCellStyle = PrototypeDetailGridView.DefaultCellStyle;

                for (int j = 0; j < PrototypeDetailGridView.Columns.Count; j++)
                {
                    dgdetail.Columns.Add((DataGridViewColumn)PrototypeDetailGridView.Columns[j].Clone());
                }

                dgdetail.ColumnHeadersVisible = false;
                dgdetail.Visible = false;
                dgdetail.Parent = this;
                dgdetail.Left = 10;

               
                 DetailDataGridView.Insert(e.RowIndex + k, dgdetail);
               
            }
             */

            base.OnRowsAdded(e);

            //this.Rows[e.RowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                        
        }

        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            /*
            for (int k = 0; k < e.RowCount; k++)
            {
                RowHasDetailTable.RemoveAt(e.RowIndex);
                DetailDataGridView.RemoveAt(e.RowIndex);
            }
            */

            base.OnRowsRemoved(e);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {            
        
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.Handled = true;

                e.PaintBackground(e.ClipBounds, this.Rows[e.RowIndex].Cells[0].Selected);
              //  e.PaintContent(e.ClipBounds);

                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style);
                cellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = cellStyle;

                DataRowView drv = (DataRowView)this.Rows[e.RowIndex].DataBoundItem;
                DataRow dr = drv.Row;
                                
                bool is_parent=false;
                bool child_rows_visible=false;

                int rind=frmMain.Instance.dt.Rows.IndexOf(dr);

                int ipar = (int)dr["cParentId"];

                if (rind<frmMain.Instance.dt.Rows.Count-1 && ipar==-1)
                {
                    is_parent=((int)(frmMain.Instance.dt.Rows[rind+1]["cParentId"])==(int)dr["cClipId"]);
                    child_rows_visible=(bool)(frmMain.Instance.dt.Rows[rind+1]["cShow"]);

                }

                bool is_child=((int)dr["cParentId"]!=-1);

                bool is_last_child = false;

                if (is_child && e.RowIndex < (this.Rows.Count - 1))
                {
                    DataRowView drv2 = (DataRowView)this.Rows[e.RowIndex + 1].DataBoundItem;
                    DataRow dr2 = drv2.Row;

                    is_last_child = (dr["cParentId"].ToString() != dr2["cParentId"].ToString());
                }
                else if (is_child && e.RowIndex==(this.Rows.Count-1))
                {
                    is_last_child = true;
                }
             //1   base.OnCellPainting(e);

                //if (DetailDataGridView[e.RowIndex] != null && e.RowIndex >= 0 && RowHasDetailTable[e.RowIndex])
                //{
                if (is_parent)
                {
                    //if (!DetailDataGridView[e.RowIndex].Visible)
                    if (!child_rows_visible)
                    {
                        // draw +
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 2, 10, 10));
                        e.Graphics.DrawRectangle(System.Drawing.Pens.Black, new System.Drawing.Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 2, 10, 10));
                        e.Graphics.DrawLine(System.Drawing.Pens.Black, new System.Drawing.Point(e.CellBounds.X + 2 + 2, e.CellBounds.Y + 2 + 5), new System.Drawing.Point(e.CellBounds.X + 2 + 8, e.CellBounds.Y + 2 + 5));
                        e.Graphics.DrawLine(System.Drawing.Pens.Black, new System.Drawing.Point(e.CellBounds.X + 2 + 5, e.CellBounds.Y + 2 + 2), new System.Drawing.Point(e.CellBounds.X + 2 + 5, e.CellBounds.Y + 2 + 8));
                    }
                    else
                    {
                        // draw -
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 2, 10, 10));
                        e.Graphics.DrawRectangle(System.Drawing.Pens.Black, new System.Drawing.Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 2, 10, 10));
                        e.Graphics.DrawLine(System.Drawing.Pens.Black, new System.Drawing.Point(e.CellBounds.X + 2 + 2, e.CellBounds.Y + 2 + 5), new System.Drawing.Point(e.CellBounds.X + 2 + 8, e.CellBounds.Y + 2 + 5));
                    }
                }
                else if (is_child)
                {
                    HatchBrush bdots_v = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.Percent20, Color.Black, this.DefaultCellStyle.BackColor);
                    Pen pdots_v = new Pen(bdots_v);

                    int line_height = (int)((float)e.CellBounds.Height / (float)2);

                    if (is_last_child)
                    {
                        e.Graphics.DrawLine(pdots_v, new System.Drawing.Point(e.CellBounds.X + 2 + 5, e.CellBounds.Y), new System.Drawing.Point(e.CellBounds.X + 2 + 5, e.CellBounds.Y+line_height));
                    }
                    else
                    {
                        e.Graphics.DrawLine(pdots_v, new System.Drawing.Point(e.CellBounds.X + 2 + 5, e.CellBounds.Y), new System.Drawing.Point(e.CellBounds.X + 2 + 5, e.CellBounds.Bottom));
                    }
                    HatchBrush bdots_h = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.Percent20, Color.Black, this.DefaultCellStyle.BackColor);
                    Pen pdots_h = new Pen(bdots_h);

                    //    e.Graphics.DrawLine(pdots_h, new System.Drawing.Point(e.CellBounds.Right - line_height, e.CellBounds.Y +line_height), new System.Drawing.Point(e.CellBounds.Right, e.CellBounds.Y +line_height));
                    e.Graphics.DrawLine(pdots_h, new System.Drawing.Point(e.CellBounds.X + 2+5, e.CellBounds.Y + line_height), new System.Drawing.Point(e.CellBounds.Left + 50, e.CellBounds.Y + line_height));


                }
                else
                {                    
                    e.Handled=false;                    
                }

                if (dr["cdisabled"].ToString()!=bool.TrueString)
                {
                    e.PaintContent(e.ClipBounds);
                }
            }
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {                
                DataRowView drv = (DataRowView)this.Rows[e.RowIndex].DataBoundItem;
                DataRow dr = drv.Row;

                if (dr["cParentId"].ToString() != "-1")
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            base.OnCellFormatting(e);
        }
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 0)
            {
                DataRowView drv = (DataRowView)this.Rows[e.RowIndex].DataBoundItem;
                DataRow dr = drv.Row;

                bool is_parent = false;
                bool child_rows_visible = false;

                int rind = frmMain.Instance.dt.Rows.IndexOf(dr);

                if (rind < frmMain.Instance.dt.Rows.Count - 1 && dr["cParentId"].ToString()=="-1")
                {
                    is_parent = ((int)(frmMain.Instance.dt.Rows[rind + 1]["cParentId"]) == (int)dr["cClipId"]);
                    child_rows_visible = (bool)(frmMain.Instance.dt.Rows[rind + 1]["cShow"]);

                }

                if (is_parent)
                {
                    for (int k=0;k<frmMain.Instance.dt.Rows.Count;k++)
                    {
                        if ((int)frmMain.Instance.dt.Rows[k]["cParentId"]==(int)dr["cClipId"])
                        {
                            frmMain.Instance.dt.Rows[k]["cShow"]=!((bool)frmMain.Instance.dt.Rows[k]["cShow"]);
                        }
                    }

                    this.Invalidate();
                }
            }
            /*
            if (DetailDataGridView[e.RowIndex]!=null && e.RowIndex >= 0)
            {
                if (RowHasDetailTable[e.RowIndex])
                {
                    if (!DetailDataGridView[e.RowIndex].Visible)
                    {
                        //DataGridViewRowNotExpandedHeight = this.Rows[e.RowIndex].Height;
                        
                 //       this.Rows[e.RowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        Rectangle rect = this.GetCellDisplayRectangle(0, e.RowIndex, true);
                        DetailDataGridView[e.RowIndex].Top = rect.Y + this.Rows[e.RowIndex].Height;
                        this.Rows[e.RowIndex].Height += DetailDataGridView[e.RowIndex].Height;

                        for (int k = e.RowIndex + 1; k < this.Rows.Count; k++)
                        {
                            if (DetailDataGridView[k].Visible)
                            {
                                DetailDataGridView[k].Top +=DetailDataGridView[e.RowIndex].Height;
                            }
                        }

                        //DataGridViewLastExpandedRow = e.RowIndex;
                        DetailDataGridView[e.RowIndex].Visible = true;
                    }
                    else
                    {
                        //DataGridViewLastExpandedRow = -1;
                        this.Rows[e.RowIndex].Height -= DetailDataGridView[e.RowIndex].Height;

                        for (int k = e.RowIndex+1; k < this.Rows.Count; k++)
                        {
                            if (DetailDataGridView[k].Visible)
                            {
                                DetailDataGridView[k].Top -= DetailDataGridView[e.RowIndex].Height;
                            }
                        }
                        DetailDataGridView[e.RowIndex].Visible = false;
                    }
                }
            }
             */
        }
    }
}
