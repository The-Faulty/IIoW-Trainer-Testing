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
        bool isOpened = false;

        bool sand = false;
        bool silt = false;
        bool dirt = false;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            WebClient web = new WebClient();
            moneyPanel.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        public Mem m = new Mem();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Started");
            isOpened = false;
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

        private void moneyHackBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempting to import money.");

            string num = textBox1.Text;

            if (isOpened == true)
            {
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
            else
            {
                MessageBox.Show("Please make sure the game is connected before using the trainer.");
            }
        }

        private void blockHackBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempting to import sand.");

            string num = textBox2.Text;

            if (isOpened == true)
            {
                if (sand == true)
                {
                    if (m.writeMemory("IIslands Of War.exe+003E72A0,0x20,0x44,0x4,0x0", "double", num))
                    {
                        Console.WriteLine(num + " Sand was successfully imported.");
                    }
                    else
                    {
                        Console.WriteLine("Sand import was unsuccessful.");
                    }
                }
                else if (silt == true)
                {
                    if (m.writeMemory("IIslands Of War.exe+003E72A0,0x20,0x44,0x4,0x10", "double", num))
                    {
                        Console.WriteLine(num + " Silt successfully imported.");
                    }
                    else
                    {
                        Console.WriteLine("Silt import was unsuccsessful.");
                    }
                }
                else if (dirt == true)
                {
                    if (m.writeMemory("IIslands Of War.exe+003E72A0,0x20,0x44,0x4,0x20", "double", num))
                    {
                        Console.WriteLine(num + " Silt successfully imported.");
                    }
                    else
                    {
                        Console.WriteLine("Silt import was unsuccsessful.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure the game is connected before using the trainer.");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void moneyBtn_Click(object sender, EventArgs e)
        {
            moneyPanel.BringToFront();
        }

        private void blockBtn_Click(object sender, EventArgs e)
        {
            blockPanel.BringToFront();
        }

        private void sandBtn_Click(object sender, EventArgs e)
        {
            if (sand == false)
            {
                sand = true;
                sandBtn.BackColor = Color.CadetBlue;
            }
            else
            {
                sand = false;
                sandBtn.BackColor = Color.PowderBlue;
            }
        }

        private void siltBtn_Click(object sender, EventArgs e)
        {
            if (silt == false)
            {
                silt = true;
                siltBtn.BackColor = Color.CadetBlue;
            }
            else
            {
                silt = false;
                siltBtn.BackColor = Color.PowderBlue;
            }
        }

        private void dirtBtn_Click(object sender, EventArgs e)
        {
            if (dirt == false)
            {
                dirt = true;
                dirtBtn.BackColor = Color.CadetBlue;
            }
            else
            {
                dirt = false;
                dirtBtn.BackColor = Color.PowderBlue;
            }
        }
    }
}
