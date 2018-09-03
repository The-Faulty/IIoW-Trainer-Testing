using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Net;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            WebClient web = new WebClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        public Mem m = new Mem();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Started");
            bool isOpened = false;
            bool hasOpened = false;

            while (true)
            {

                int procID = m.getProcIDFromName("IIslands of War");

                double curM = 0;

                if (procID > 0)
                {
                    m.OpenProcess(procID);

                    isOpened = m.OpenProcess(procID);
                    hasOpened = m.OpenProcess(procID);

                }
                else
                {
                    isOpened = false;
                }

                if (isOpened)
                {
                    label1.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = "Connected";
                    });
                }
                if (!isOpened && hasOpened)
                {
                    label1.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = "Disconnected";
                    });
                }

                Task.Delay(500);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempting to import money.");

            string num = "";

            m.writeMemory("IIslands Of War.exe+0049941C,0x60,0x10,0x118,0xA0", "double", num);
            if (m.writeMemory("IIslands Of War.exe+0049941C,0x60,0x10,0x118,0xA0", "double", num))
            {
                label2.Text = ("Money Write Was Successful");
                Console.WriteLine("Money successfully imported.");
            }
            else
            {
                label2.Text = ("Money Write Was Unsuccessful");
                Console.WriteLine("Money was unable to be imported.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempting to import sand.");

            string num = "";

            m.writeMemory("IIslands Of War.exe+003E72A0,0x20,0x44,0x4,0x0", "double", num);
            if (m.writeMemory("IIslands Of War.exe+003E72A0,0x20,0x44,0x4,0x0", "double", num))
            {
                label2.Text = ("Sand Import Was Successful");
                Console.WriteLine("Sand successfully imported.");
            }
            else
            {
                label2.Text = ("Sand Import Was Unsuccessful");
                Console.WriteLine("Sand was unable to be imported.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
