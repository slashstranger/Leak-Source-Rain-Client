using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Memory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Win32;
using System.Threading;

namespace Rain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Mem MemLib = new Mem();
        private void Form1_Load(object sender, EventArgs e)
        {
            Aim.fakelag = false;
            Form2.KeyAuthApp.init();
            timer1.Start();
            timer2.Start();
            Form2.KeyAuthApp.log("Entrou em cheats");
            buttonaim.Checked = true;
            label1.Text = Form2.KeyAuthApp.user_data.username;
        }

        #region timer
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetAsyncKeyState(int vKey);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        public static bool IsKeyDown(Keys key)
        {
            return Form1.KeyStates.Down == (Form1.GetKeyState(key) & Form1.KeyStates.Down);
        }

        private static Form1.KeyStates GetKeyState(Keys key)
        {
            Form1.KeyStates keyStates = Form1.KeyStates.None;
            short keyState = GetKeyState((int)key);
            if (((int)keyState & 32768) == 32768)
            {
                keyStates |= Form1.KeyStates.Down;
            }
            if ((keyState & 1) == 1)
            {
                keyStates |= Form1.KeyStates.Toggled;
            }
            return keyStates;
        }

        private enum KeyStates
        {
            None,
            Down,
            Toggled
        }
        private bool visivel = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Array values = Enum.GetValues(typeof(Keys));
            foreach (object obj in values)
            {
                if(IsKeyDown(Keys.XButton1) && Visual.fakelag == true)
                {
                    Aim.CauseLag(1700);
                    break;
                }
                if (IsKeyDown(Keys.F2) && this.visivel == true)
                {
                    visivel = false;
                    base.Hide();
                    break;
                }
                if (IsKeyDown(Keys.F2) && this.visivel == false)
                {
                 
                    this.visivel = true;
                    base.Show();
                    break;
                }
            }
        }


        #endregion

        private void buttonaim_Click(object sender, EventArgs e)
        {
            visual1.Hide();
            aim1.Show();
            config1.Hide();
            uptade();
            esquerdaseta.Visible = false;
            direitaseta.Visible = true;
         }

        private void buttonVisual_Click(object sender, EventArgs e)
        {
            visual1.Show();
            aim1.Hide();
            config1.Hide();
            uptade();
            esquerdaseta.Visible = true;
            direitaseta.Visible = true;
        }

        private void buttonsettings_Click(object sender, EventArgs e)
        {
            visual1.Hide();
            config1.Show();
            aim1.Hide();
            uptade();
            esquerdaseta.Visible = true;
            direitaseta.Visible = false;
        }

        private void aim1_Load(object sender, EventArgs e)
        {

        }

        public void uptade()
        {
            if (buttonaim.Checked)
            {
                kkktesxt.Text = "Aim";
            }
            else if (buttonVisual.Checked)
            {
                kkktesxt.Text = "Visual";
            }
            else if (buttonsettings.Checked)
            {
                kkktesxt.Text = "Settings";
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void direitaseta_Click(object sender, EventArgs e)
        {
            direita();
        }

        private void esquerdaseta_Click(object sender, EventArgs e)
        {
            esquerda();
        }
        void direita()
        {
            if (buttonaim.Checked)
            {
                esquerdaseta.Visible = true;
                direitaseta.Visible = true;
                visual1.Show();
                aim1.Hide();
                config1.Hide();

                buttonVisual.Checked = true;
                uptade();
            }
            else if (buttonVisual.Checked)
            {
                esquerdaseta.Visible = true;
                visual1.Hide();
                config1.Show();
                aim1.Hide();
                buttonVisual.Checked = false;
                buttonsettings.Checked = true;
                direitaseta.Visible = false;
                uptade();
            }
        }
        void esquerda()
        {
            if (buttonaim.Checked)
            {
                esquerdaseta.Visible = false;
            }
            else if (buttonsettings.Checked)
            {
                esquerdaseta.Visible = true;
                visual1.Show();
                aim1.Hide();
                config1.Hide();
                buttonVisual.Checked = true;
                buttonsettings.Checked = false;
                direitaseta.Visible = true;
                uptade();
            }
            else if (buttonVisual.Checked)
            {
                esquerdaseta.Visible = false;
                visual1.Hide();
                aim1.Show();
                config1.Hide();
                buttonVisual.Checked = false;
                buttonaim.Checked = true;
                direitaseta.Visible = true;
                uptade();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
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
                    Form2.KeyAuthApp.log("MAIN Ilegal process: " + text + " || HWID: " + System.Security.Principal.WindowsIdentity.GetCurrent().User.Value);

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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void versionlbl_Click(object sender, EventArgs e)
        {

        }

        private void config1_Load(object sender, EventArgs e)
        {

        }
    }
}
