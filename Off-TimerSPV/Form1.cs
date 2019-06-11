using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Off_TimerSPV
{
    public partial class Form1 : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        DateTime nShutdownTime;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 500, 500));
        }

        int i = 0;
        int min = 0;
      

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            min = trackBar1.Value;

            
            if (min == 1)
            {
                i = 15;
                
            }
            if (min == 2)
            {
                i = 30;
               
            }
            if (min == 3)
            {
                i = 45;
                

            }
            if (min == 4)
            {
                i = 60;
               

            }
           


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form2 spravka = new Form2();
            this.Visible = true;
            spravka.Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now < nShutdownTime)
            {
                TimeSpan ts = nShutdownTime - DateTime.Now;
                label2.Text = ts.Minutes + " : " + ts.Seconds;








            }
            else
            {


                Process.Start("shutdown.exe", "/s /t 0");

                timer1.Stop();
                Close();

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            nShutdownTime = DateTime.Now.AddMinutes(i);
            if (min >0) timer1.Start();
            else
            {
                
                    Form3 fr3 = new Form3();
                    this.Visible = true;
                    fr3.Show();
                
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            i = 0;
            timer1.Stop();
            
            label2.Text = "00 : 00";
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://vk.com/SPV_Studio");
            Process.Start(sInfo);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Changes the isMouseDown field so that the form does
            // not move unless the user is pressing the left mouse button.
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

       
    }
}
