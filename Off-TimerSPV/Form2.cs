using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Off_TimerSPV
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public Form2()
        {
            InitializeComponent();
        }

        

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sF2Info = new ProcessStartInfo("https://vk.com/SPV_Studio");
            Process.Start(sF2Info);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/Pavel-Snegirev/Off_TimerPc");
            Process.Start(sInfo);
        }

       

       

        

       

        

       
    }
}
