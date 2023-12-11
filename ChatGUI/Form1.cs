using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatGUI
{
    public partial class main : Form
    {
        private Process procclient;

        private bool run_server = false;

        private StreamWriter myStreamWriter;
        private StreamReader myStreamReader;
        private StreamReader myStreamError;

        public main()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (message.Text.Length > 0)
                Send(message.Text);
        }





        private void button2_Click(object sender, EventArgs e)
        {
            chat.Clear();
            RunClient();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Tick();
        }

        public void UpdateGUI()
        {
            new Thread(() =>
            {
                while (!procclient.HasExited)
                {
                    string text = myStreamReader.ReadLine();
                    if (!procclient.HasExited && text != "\f")
                    {
                        this.Invoke((Action)(() =>
                        {
                            chat.AppendText(Environment.NewLine + text);
                        }));
                    }
                    //textBox2.AppendText(text);
                    Console.WriteLine(text);
                    Thread.Sleep(10);
                }
            }).Start();
        }

        public void Tick()
        {
            if (!procclient.HasExited)
            {
                myStreamWriter.WriteLine("\f");
            }
        }


        public void Send(string text)
        {
            new Thread(() =>
            {
                myStreamWriter.WriteLine(text);
                if (text == "/close" && run_server)
                {
                    procclient.Kill();
                    run_server = false;
                    return;
                }
            }).Start();
        }

        public void RunClient()
        {
            new Thread(() =>
            {
                procclient = new Process();
                procclient.StartInfo.FileName = "C:\\Windows\\py.exe";
                procclient.StartInfo.Arguments = "\"" + Application.StartupPath + "\\chatclient.py\"";
                procclient.StartInfo.UseShellExecute = false;

                procclient.StartInfo.RedirectStandardOutput = true;
                procclient.StartInfo.RedirectStandardInput = true;
                procclient.StartInfo.RedirectStandardError = true;
                procclient.StartInfo.CreateNoWindow = true;
                procclient.EnableRaisingEvents = true;
                procclient.Start();
                UpdateGUI();
                myStreamReader = procclient.StandardOutput;
                myStreamWriter = procclient.StandardInput;
                myStreamError = procclient.StandardError;

                myStreamWriter.AutoFlush = true;

                procclient.WaitForExit();
            }).Start();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void server_Click(object sender, EventArgs e)
        {
            chat.Clear();
            run_server = true;
            RunServer();
            timer1.Enabled = true;
        }

        public void RunServer()
        {
            new Thread(() =>
            {
                procclient = new Process();
                procclient.StartInfo.FileName = "C:\\Windows\\py.exe";
                procclient.StartInfo.Arguments = "\"" + Application.StartupPath + "\\chatserv.py\"";
                procclient.StartInfo.UseShellExecute = false;

                procclient.StartInfo.RedirectStandardOutput = true;
                procclient.StartInfo.RedirectStandardInput = true;
                procclient.StartInfo.RedirectStandardError = true;
                procclient.StartInfo.CreateNoWindow = true;
                procclient.EnableRaisingEvents = true;
                procclient.Start();
                UpdateGUI();
                myStreamReader = procclient.StandardOutput;
                myStreamWriter = procclient.StandardInput;
                myStreamError = procclient.StandardError;

                myStreamWriter.AutoFlush = true;

                procclient.WaitForExit();
                timer1.Enabled = false;
            }).Start();
        }

        private void message_KeyDown(object sender, KeyEventArgs e)
        {
            if (message.Text.Length > 0 && e.KeyCode == Keys.Enter)
                Send(message.Text);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Send("/close");
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!procclient.HasExited)
            {
                Send("/close");
            }
        }
    }
}
