using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MECS.Chapter2.Item16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += OnTick;
            timer1.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            Action action = () =>
            {
                label1.Text = DateTime.Now.ToLongTimeString();
                Console.WriteLine(DateTime.Now.ToLongTimeString()); 
            };
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
