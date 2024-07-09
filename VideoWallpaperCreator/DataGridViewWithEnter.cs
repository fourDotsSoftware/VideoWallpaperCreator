using System;
using System.Collections.Generic;

using System.Text;

using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public class DataGridViewTextBoxColumnWithEnter : DataGridViewColumn
    {
        public DataGridViewTextBoxColumnWithEnter()            
        {
            this.CellTemplate = new CustomDataGridViewTextBoxCell();
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
        }
    }

    public class CustomDataGridViewTextBoxCell : DataGridViewTextBoxCell
    {
        public CustomDataGridViewTextBoxCell()           
        {
           
        }

        public override Type EditType
        {
            get
            {
                return typeof(CustomDataGridViewTextBoxEditingControl);
            }
        }
    }

    public class CustomDataGridViewTextBoxEditingControl:DataGridViewTextBoxEditingControl
    {
        public CustomDataGridViewTextBoxEditingControl()            
        {

        }

        public override bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            if (keyData == Keys.Enter)
            {
                return true;
            }
            else
            {
                return base.EditingControlWantsInputKey(keyData, dataGridViewWantsInputKey);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.AppendText(Environment.NewLine);               
            }
            
            base.OnKeyDown(e);
            
        }
    }
}
