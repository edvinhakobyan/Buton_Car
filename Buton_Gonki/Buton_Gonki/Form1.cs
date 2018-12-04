using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Buton_Gonki
{
    public delegate void help(Button x);
    public partial class Form1 : Form
    {
        Thread thread1;
        Random random = new Random();
        My_But[] but_arr;
        help h;
             

        public Form1()
        {
            InitializeComponent();
            h = new help(Motion);
            but_arr = new My_But[] { button1, button2, button3, button4, button5, button6 };
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            if (thread1 == null)
            {
                thread1 = new Thread(Mov1);
                thread1.IsBackground = true;
                thread1.Start();
            }
            else
            {
                thread1.Resume();
                return;
            }
            
        }

        void Motion(Button b)
        {
            b.Location = new Point(b.Location.X + random.Next(2), b.Location.Y);
            Lider();
        }


        void Mov1()
        {
            while (true)
            {
                Invoke(h, button1);
                Invoke(h, button2);
                Invoke(h, button3);
                Invoke(h, button4);
                Invoke(h, button5);
                Invoke(h, button6);
                Thread.Sleep(5);
            }
        }

        private void Lider()
        {
            for (int i = 0; i < but_arr.Length; i++)
            {
                if (but_arr[i].Location.X >= (Size.Width - but_arr[i].Size.Width- 20))
                {
                    but_arr[i].BackColor = Color.Yellow;
                    Pouse_Click(but_arr[i],new EventArgs());
                }
            }
        }
        private void Pouse_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Suspend();
                Start.Enabled = true;
            }
            Start.Enabled = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Pouse_Click(sender, e);
            Reset();
        }

        private void Reset()
        {
            button1.Location = new Point(15,button1.Location.Y);
            button2.Location = new Point(15,button2.Location.Y);
            button3.Location = new Point(15,button3.Location.Y);
            button4.Location = new Point(15,button4.Location.Y);
            button5.Location = new Point(15,button5.Location.Y);
            button6.Location = new Point(15,button6.Location.Y);

            for (int i = 0; i < but_arr.Length; i++)
            {
                but_arr[i].BackColor = Color.Coral;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
