using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using KeyAuth;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

namespace Rain
{
    public partial class Form2 : Form
    {
        public static api KeyAuthApp = new api(
name: "Rain Client 2.2",
ownerid: "vCzuTniC1Y",
secret: "6b36d2c8cdbd4a2f741c2430ceadbd2f14936abc7082e9d8d0b0986a8069fbe8",
version: "1.2"
);
        public Form2()
        {
            InitializeComponent();
        }
        
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Form2.KeyAuthApp.login(this.textuser.Text, this.textpass.Text);
            
            bool success = Form2.KeyAuthApp.response.success;
            if (success)
            {
                barcarregar.Visible = true;
                textuser.Visible = false;
                textpass.Visible = false;
                btnLogin.Visible = false;
                await Task.Delay(1600);
                {

                    Form2.KeyAuthApp.log("Logou");
                    Form1 form2 = new Form1();
                    form2.Hide();
                    base.Hide();
                }

             

                {
                    Form1 form2 = new Form1();
                    form2.Show();
                    base.Hide();
                }
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form2.KeyAuthApp.init();
            timer1.Start();
            if (KeyAuthApp.checkblack() == true)
            {
                string location = Assembly.GetExecutingAssembly().Location;
                if (location == "" || location == null)
                {
                    location = Assembly.GetEntryAssembly().Location;
                }
                KeyAuthApp.log("User Blacklisted open program || HWID: " + System.Security.Principal.WindowsIdentity.GetCurrent().User.Value);

                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C ping 1.1.1.1 -n 1 -w 4000 > Nul & Del \"" + location + "\"",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                });
                Environment.Exit(0);
            }
            Form2.KeyAuthApp.log("Abriu");
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            string text = string.Empty;
            for (int i = 0; i < processes.Length; i++)
            {
                text = processes[i].MainWindowTitle;
                if (text.Contains("CodeCracker") || text.Contains("ProcessHacker") || text.Contains("Hacker") || text.Contains("dnSpy") || text.Contains("CheatEngine") || text.Contains("Engine") || text.Contains("Cheat") || text.Contains("MegaDumper") || text.Contains("OllyDbg") || text.Contains("HxD") || text.Contains("xVenoxi Dumper") || text.Contains("NativeDumper MFC Application") || text.Contains("JetBrains dotPeek") || text.Contains("ILSpy") || text.Contains("Reflector") || text.Contains("KsDumper") || text.Contains("IIDA v7.7.220118") || text.Contains("The Interactive Disassembler") || text.Contains("ExtremeDumper") || text.Contains("scylla") || text.Contains("dbg") || text.Contains("dumper"))
                {
                    string location = Assembly.GetExecutingAssembly().Location;
                    if (location == "" || location == null)
                    {
                        location = Assembly.GetEntryAssembly().Location;
                    }
                    KeyAuthApp.log("Ilegal process: "+ text+ " HWID: "+ System.Security.Principal.WindowsIdentity.GetCurrent().User.Value);
 
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/C ping 1.1.1.1 -n 1 -w 4000 > Nul & Del \"" + location + "\"",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    });
                    Environment.Exit(0);
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labellogin_Click(object sender, EventArgs e)
        {

        }

        private void barcarregar_Click(object sender, EventArgs e)
        {

        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
