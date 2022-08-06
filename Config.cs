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
    public partial class Config : UserControl
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
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
            
        }

       

        private void AimbotAtivar_Click(object sender, EventArgs e)
        {
            Apply_Changes_InMemory("00 50 80 E5 07 00 A0 E1 77 F9 FF EB 00 50 A0 E1 00 00 A0 E3 AD 98 A2 EB 18 00 A0 E3", "00 50 80 E5 07 00 A0 E1 77 F9 FF EB 00 F0 20 E1 00 00 A0 E3 AD 98 A2 EB 00 F0 20 E3");
            Apply_Changes_InMemory("00 00 90 E5 92 8C C2 EB 00 10 A0 E3 00 50 A0 E1 8C", "00 00 90 E5 92 8C C2 EB 00 F0 20 E3 00 50 A0 E1 8C");
        }

        private void PID_Click(object sender, EventArgs e)
        {

        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        private void infoButton_MouseHover(object sender, EventArgs e)
        {
            Tip.SetToolTip(infoButton, "Tempo restante: " + UnixTimeToDateTime(long.Parse(Form2.KeyAuthApp.user_data.subscriptions[0].expiry))) ;
        }

        private void Tip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            Tip.SetToolTip(infoButton, "Tempo restante: " + UnixTimeToDateTime(long.Parse(Form2.KeyAuthApp.user_data.subscriptions[0].expiry)));
        }
    }
}
