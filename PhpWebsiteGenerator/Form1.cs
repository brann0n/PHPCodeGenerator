using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhpWebsiteGenerator
{
    public partial class Form1 : Form
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;


        public Form1()
        {
            InitializeComponent();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        const int CS_NOCLOSE = 0x200;

        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_NOCLOSE;
        //        return cp;
        //    }
        //}

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void VolumeUp(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }

        public void VolumeDown(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //play the fucking dingdong shit every 250 ms
            SystemSounds.Hand.Play();
            //MoveCursor();
           // DoMouseClick();
        }

        public void MoveCursor()
        {
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
            Cursor.Position = new Point(width / 2, height / 2);
        }

        public void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            VolumeDown(50);
            VolumeUp(50);
        }
    }
}
