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
    public partial class Visual : UserControl
    {
        public Visual()
        {
            InitializeComponent();
        }

        private void Visual_Load(object sender, EventArgs e)
        {

        }

        #region Func
        public Mem MemLib = new Mem();
        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        private async void Apply_Changes_InMemory(string SEARCH, string REPLACE)
        {
            bool shh = Process.GetProcessesByName("HD-Player").Length == 0 && Process.GetProcessesByName("LdVBoxHeadless").Length == 0 && Process.GetProcessesByName("AndroidProcess").Length == 0 && Process.GetProcessesByName("ProjectTitan").Length == 0 && Process.GetProcessesByName("Nox").Length == 0 && Process.GetProcessesByName("aow_exe").Length == 0 && Process.GetProcessesByName("MEmuHeadless").Length == 0;
            if (shh)
            {
                PSPS2.Text = "Falha ao conectar";
                PSPS2.ForeColor = Color.DarkRed;
                return;
            }
            else if (Process.GetProcessesByName("HD-Player").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("HD-Player") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));
                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(SEARCH, writable: true);
                    string u = "0x" + best.FirstOrDefault().ToString("X");

                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", REPLACE, "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!"; ;
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("LdVBoxHeadless").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("LdVBoxHeadless") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + best.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!";
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }

            else if (Process.GetProcessesByName("AndroidProcess").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("AndroidProcess") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + best.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!";
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("ProjectTitan").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("ProjectTitan") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + best.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!";
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("MEmuHeadless").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("MEmuHeadless") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + best.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!";
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("Nox").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("Nox") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + best.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!";
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }
            else if (Process.GetProcessesByName("aow_exe").Length != 0)
            {
                var intPtr = IntPtr.Zero;
                uint num = 0U;
                var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
                if ((int)intPtr2 > 0)
                {
                    ProcessEntry32 processEntry = default;
                    processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                    int num2 = Process32First(intPtr2, ref processEntry);
                    while (num2 == 1)
                    {
                        var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                        Marshal.StructureToPtr(processEntry, intPtr3, true);
                        ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                        Marshal.FreeHGlobal(intPtr3);
                        if (processEntry2.szExeFile.Contains("aow_exe") && processEntry2.cntThreads > num)
                        {
                            num = processEntry2.cntThreads;
                            intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                        }

                        num2 = Process32Next(intPtr2, ref processEntry);
                    }
                    PID.Text = Convert.ToString(intPtr);
                    MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                    int i2 = 22000000;
                    IEnumerable<long> best = await MemLib.AoBScan(0L, 0x00007fffffffffff, (SEARCH), true, true, "");
                    string u = "0x" + best.FirstOrDefault().ToString("X");
                    Mem.MemoryProtection memoryProtection;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                    if (best.Count() != 0)
                    {
                        for (int i = 0; i < best.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(best.ElementAt(i).ToString("X"), "bytes", (REPLACE), "");
                        }
                        PSPS2.Text = "Aplicado!";
                        PSPS2.ForeColor = Color.DarkGreen;
                        Console.Beep(500, 300);
                    }
                    else
                    {
                        PSPS2.Text = "Erro ao aplicar!";
                        PSPS2.ForeColor = Color.DarkRed;
                    }
                    Mem.MemoryProtection memoryProtection2;
                    MemLib.ChangeProtection(u, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
                }
            }

        }

        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("00 00 80 3F CF F7 AD 34", "33 33 34 43 CF F7 AD 34");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("33 33 34 43 CF F7 AD 34", "00 00 80 3F CF F7 AD 34");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("00 00 80 3F 21 13 17 BE DE A0 76 BF", "EC 11 8C 43 21 13 17 BE DE A0 76 BF");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("EC 11 8C 43 21 13 17 BE DE A0 76 BF", "00 00 80 3F 21 13 17 BE DE A0 76 BF");
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("96 00 00 00 00 00 B0 40 00 00 80 3F 00 00 40 3F", "96 00 00 00 00 00 B8 40 00 00 00 00 00 00 00 00");
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("96 00 00 00 00 00 B8 40 00 00 00 00 00 00 00 00", "96 00 00 00 00 00 B0 40 00 00 80 3F 00 00 40 3F");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("0A 00 A0 E3 ?? ?? ?? EB 00 50 A0 E1 90 00 9F E5", "00 F0 20 E3");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("DB 0F 49 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE 00 10 00 E3 41 3A 30 EE 80 1F 4B E3 01 0A 30 EE 2C 10 80 E5 50 00 C0 F2", "00 00 A0 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("00 00 A0 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE", "DB 0F 49 40 10 2A 00 EE 00 10 80 E5 10 3A 01 EE 14 10 80 E5 00 2A 30 EE 00 10 00 E3 41 3A 30 EE 80 1F 4B E3 01 0A 30 EE 2C 10 80 E5 50 00 C0 F2");
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("0A D7 23 3C BD 37 86 35 00", "0A D7 23 3C 00 00 80 BF 00 20 A0 E3");
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("0A D7 23 3C 00 00 80 BF 00 20 A0 E3", "0A D7 23 3C BD 37 86 35 00");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void PSPS2_Click(object sender, EventArgs e)
        {

        }
        public static bool fakelag;
        public static string pathi;
        private void guna2Button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Executable|*.exe";
            openFileDialog1.Title = "Selecione o arquivo principal do seu emulador ex: HD-Player.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strfilename = openFileDialog1.FileName;
                pathi = strfilename;
                fakelag = true;
            }
            else if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                fakelag = false;
            }
            else if (openFileDialog1.ShowDialog() == DialogResult.Abort)
            {
                fakelag = false;
            }
        }

        public static async void CauseLag(int second)
        {
            ProcessStartInfo AddRuleIn = new ProcessStartInfo("cmd.exe", "/c netsh advfirewall firewall add rule name=\"UCLagSwitch\" dir=in action=block program=\"" + pathi + "\" enable=yes");
            ProcessStartInfo AddRuleOut = new ProcessStartInfo("cmd.exe", "/c netsh advfirewall firewall add rule name=\"UCLagSwitch\" dir=out action=block program=\"" + pathi + "\" enable=yes");
            ProcessStartInfo DeleteRule = new ProcessStartInfo("cmd.exe", "/c netsh advfirewall firewall delete rule name=\"UCLagSwitch\" program=\"" + pathi + "\"");
            AddRuleIn.WindowStyle = ProcessWindowStyle.Hidden;
            AddRuleOut.WindowStyle = ProcessWindowStyle.Hidden;
            DeleteRule.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(AddRuleIn);
            Process.Start(AddRuleOut);
            Console.Beep();
            await Task.Delay(second);
            Process.Start(DeleteRule);
        }


        private void guna2Button10_Click(object sender, EventArgs e)
        {
            fakelag = false;
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("69 00 6E 00 67 00 61 00 6D 00 65 00 2F 00 63 00 61 00 70 00 73 00 75 00 6C 00 65 00 68 00 75 00 6D 00 61 00 6E 00 73 00 6E 00 69 00 70 00 65 00 72 00 63 00 6F 00 6C 00 6C 00 69 00 64 00 65 00 72 00", "65 00 66 00 66 00 65 00 63 00 74 00 73 00 2F 00 62 00 72 00 5F 00 61 00 69 00 72 00 64 00 72 00 6F 00 70 00 6C 00 69 00 67 00 68 00 74 00 6C 00 65 00 76 00 65 00 6C 00 31 00 00 00 00 00 00 00 00 00");
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("69 00 6E 00 67 00 61 00 6D 00 65 00 2F 00 63 00 61 00 70 00 73 00 75 00 6C 00 65 00 68 00 75 00 6D 00 61 00 6E 00 73 00 6E 00 69 00 70 00 65 00 72 00 63 00 6F 00 6C 00 6C 00 69 00 64 00 65 00 72 00", "65 00 66 00 66 00 65 00 63 00 74 00 73 00 2F 00 62 00 72 00 5F 00 61 00 69 00 72 00 64 00 72 00 6F 00 70 00 6C 00 69 00 67 00 68 00 74 00 6C 00 65 00 76 00 65 00 6C 00 31 00 00 00 00 00 00 00 00 00");
        }
    }
}
