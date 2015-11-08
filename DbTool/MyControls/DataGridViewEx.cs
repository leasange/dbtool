using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbTool.MyControls
{
    public partial class DataGridViewEx : DataGridView
    {
        public DataGridViewEx()
        {
            InitializeComponent();
        }

        private void DataGridViewEx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            this.RowHeadersWidth - 4,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                this.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
