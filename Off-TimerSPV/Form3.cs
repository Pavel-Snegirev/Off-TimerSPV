using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Off_TimerSPV
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "/s /t 0");
            Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }
    }
}
