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
    public partial class Aim : UserControl
    {
        public Aim()
        {
            InitializeComponent();
        }

        private void Aim_Load(object sender, EventArgs e)
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

        private void AimNeckAtivar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("leak", "leak");
        }

        private void AimNeckdesativar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("leak", "leak");
        }

        private void AimfovAtivar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("AE 47 01 3F", "80 7B E1 FF FF FF FF FF");
        }

        private void AimfovDesativar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("80 7B E1 FF FF FF FF FF", "AE 47 01 3F");
        }

        private void AimbotAtivar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("leak", "leak");
        }

        private void precisaoativar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41", "00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45", "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41");
        }

        private void norecoilativar_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("leak", "leak");
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("leak", "leak");
        }

        private void PSPS2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("leak", "leak");
        }
        public static bool fakelag;
        public static string pathi;
        private void guna2Button3_Click(object sender, EventArgs e)
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            fakelag = false;
        }

        private void PID_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            {
                PSPS2.Text = "Conectando...";
                PSPS2.ForeColor = Color.Orange;
                Apply_Changes_InMemory("62 6f 6e 65 5f 48 69 70 73", "62 6f 6e 65 5f 48 65 61 64");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("LEAK BY SLASH", "LEAK BY SLASH");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            PSPS2.Text = "Conectando...";
            PSPS2.ForeColor = Color.Orange;
            Apply_Changes_InMemory("LEAK BY SLASH", "LEAK BY SLASH");
        }

    }
    
}
