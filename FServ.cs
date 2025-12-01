using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab13_Sklad_main_HOI
{
    public partial class FServ : Form
    {
        public FServ()
        {
            InitializeComponent();
            FServTB.Text = Form1.GlStringParameter;
        }

        private void FServBOk_Click(object sender, EventArgs e)
        {
            Form1.GlStringParameter = FServTB.Text;
            Close();
        }
    }
}
