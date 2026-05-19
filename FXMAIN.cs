using Guna.UI2.WinForms;
using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DiscordRPC;
using External;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using FXX;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using K4os.Compression.LZ4.Internal;
using Mem = Memory.Mem;

namespace CLIPA_X_CHEAT
{
    public partial class FXMAIN : Form
    {
        private List<Snowflake> snowflakes = new List<Snowflake>();
        private Random rand = new Random();
        private Timer timer;
        
        public FXMAIN()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += new EventHandler(particles_Tick);
            timer.Start();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void particles_Tick(object sender, EventArgs e)
        {
            // Update UI logic
        }

        Mem m = new Mem();

        private void FXMAIN_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.6;
            Particles.Setup(this, 60, Color.Green, 90, Color.Green);
        }

        private void EXITBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            RPC.rpctimestamp = Timestamps.Now;
            RPC.InitializeRPC();
        }

        private void guna2ToggleSwitch8_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void guna2ToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void guna2ToggleSwitch8_CheckedChanged_2(object sender, EventArgs e)
        {
        }

        public static bool Streaming;
        
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        private void guna2ToggleSwitch8_CheckedChanged_3(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch8.Checked)
            {
                base.ShowInTaskbar = false;
                FXMAIN.Streaming = true;
                FXMAIN.SetWindowDisplayAffinity(base.Handle, 17U);
            }
            else
            {
                base.ShowInTaskbar = true;
                FXMAIN.Streaming = false;
                FXMAIN.SetWindowDisplayAffinity(base.Handle, 0U);
            }
        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    label3.ForeColor = colorDialog.Color;
                    label5.ForeColor = colorDialog.Color;
                    label4.ForeColor = colorDialog.Color;
                    label2.ForeColor = colorDialog.Color;
                    label1.ForeColor = colorDialog.Color;
                    label46.ForeColor = colorDialog.Color;
                    label88.ForeColor = colorDialog.Color;
                    label30.ForeColor = colorDialog.Color;
                    label31.ForeColor = colorDialog.Color;
                    label15.ForeColor = colorDialog.Color;
                    label98.ForeColor = colorDialog.Color;
                    Status.ForeColor = colorDialog.Color;
                    guna2BorderlessForm1.ShadowColor = colorDialog.Color;
                    guna2Panel1.BorderColor = colorDialog.Color;
                    this.Refresh();
                }
            }
        }

        // ✅ FIXED: Safe memory read/write with error handling
        private async void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                m.OpenProcess(proc);

                var result = await m.AoBScan("");
                if (result.Any())
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 Enderecoleitura = CurrentAddress + 140;
                        Int64 EndercoEscrita = CurrentAddress + 90;

                        try
                        {
                            var Read = m.ReadMemory<int>(Enderecoleitura.ToString("X"));
                            string valueToWrite = Read.ToString().Trim();

                            if (int.TryParse(valueToWrite, out int parsedValue))
                            {
                                m.WriteMemory(EndercoEscrita.ToString("X"), "int", valueToWrite);
                                Status.Text = "Aimbot Exeternal Done ✓";
                            }
                            else
                            {
                                Status.Text = "Invalid memory value";
                            }
                        }
                        catch (FormatException fex)
                        {
                            Status.Text = "Format Error: Invalid value format";
                        }
                    }
                }
                else
                {
                    Status.Text = "Aimbot Exeternal Error - Pattern not found";
                }
            }
            catch (Exception ex)
            {
                Status.Text = "Error: " + ex.Message;
                MessageBox.Show("Error in guna2ToggleSwitch5: " + ex.Message);
            }
        }

        // ✅ FIXED: Safe memory read/write
        private async void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                m.OpenProcess(proc);

                var result = await m.AoBScan("00 00 00 00 00 00 A5 43 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);
                if (result.Any())
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 Enderecoleitura = CurrentAddress + 44;
                        Int64 EndercoEscrita = CurrentAddress + 40;

                        try
                        {
                            var Read = m.ReadMemory<int>(Enderecoleitura.ToString("X"));
                            string valueToWrite = Read.ToString().Trim();

                            if (int.TryParse(valueToWrite, out int parsedValue))
                            {
                                m.WriteMemory(EndercoEscrita.ToString("X"), "int", valueToWrite);
                                guna2PictureBox2.Text = "Aimbot Exeternal Done ✓";
                            }
                        }
                        catch (FormatException fex)
                        {
                            guna2PictureBox2.Text = "Format Error";
                        }
                    }
                }
                else
                {
                    guna2PictureBox2.Text = "Aimbot Exeternal Error";
                }
            }
            catch (Exception ex)
            {
                guna2PictureBox2.Text = "Error: " + ex.Message;
            }
        }

        private async void logo_Click(object sender, EventArgs e)
        {
            try
            {
                string search = " 00 ? ? ? 3F 00 00 80 3E 00 00 00 00 05 00 00 00 00 00 80 3F";
                string replace = "00 EC 51 B8 3D 8F C2 F5 3C";
                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    logo.Text = "Emulador no encontrado";
                    Console.Beep(2000, 400);
                }
                else
                {
                    m.OpenProcess("HD-Player");
                    logo.Text = "Success..";

                    IEnumerable<long> wl = await m.AoBScan(search, writable: true);
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            m.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k == true)
                    {
                        logo.Text = "Aimbot AWM - Activated!";
                        Console.Beep(400, 300);
                    }
                    else
                    {
                        logo.Text = "No se aplicó";
                        Console.Beep(2000, 400);
                    }
                }
            }
            catch (Exception ex)
            {
                logo.Text = "Error: " + ex.Message;
            }
        }

        private async void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string search = "a0 e1 00 10 a0 e3 6a 14 01 eb 00 00 00 ea 00 60 a0 e3";
                string replace = "a0 e1 00 10 a0 e3 6a 14 01 eb 00 00 00 ea 00 60 a0 00";
                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    Status.Text = "Emulador no encontrado";
                    Console.Beep(2000, 400);
                }
                else
                {
                    m.OpenProcess("HD-Player");
                    Status.Text = "Waiting";

                    IEnumerable<long> wl = await m.AoBScan(search, writable: true);
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            m.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    Status.Text = k ? "Sniper fix delay active" : "Error";
                    Console.Beep(k ? 400 : 2000, 300);
                }
            }
            catch (Exception ex)
            {
                Status.Text = "Error: " + ex.Message;
            }
        }

        private async void magic_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                m.OpenProcess(proc);

                var result = await m.AoBScan("00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);
                if (result.Any())
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 Enderecoleitura = CurrentAddress + 92L;
                        Int64 EndercoEscrita = CurrentAddress + 40L;

                        try
                        {
                            var Read = m.ReadMemory<int>(Enderecoleitura.ToString("X"));
                            string valueToWrite = Read.ToString().Trim();

                            if (int.TryParse(valueToWrite, out int parsedValue))
                            {
                                m.WriteMemory(EndercoEscrita.ToString("X"), "int", valueToWrite);
                                Status.Text = "Aimbot V2 Done ✓";
                            }
                        }
                        catch (FormatException fex)
                        {
                            Status.Text = "Aimbot V2 - Format Error";
                        }
                    }
                }
                else
                {
                    Status.Text = "Aimbot V2 Error - Pattern not found";
                }
            }
            catch (Exception ex)
            {
                Status.Text = "Error: " + ex.Message;
            }
        }

        private WebClient webclient = new WebClient();

        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (guna2ToggleSwitch1.Checked)
                {
                    string search = "3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F ?? ?? ?? 3F ?? ?? ?? 3F 00 00 80 3F 00 00 00 00 ?? ?? ?? 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00";
                    string replace = "3F 00 00 80 3E EC 51 B8 3D";
                    bool k = false;

                    if (Process.GetProcessesByName("HD-Player").Length == 0)
                    {
                        Status.Text = "HD-Player not found";
                    }
                    else
                    {
                        m.OpenProcess("HD-Player");
                        IEnumerable<long> wl = await m.AoBScan(search, writable: true);

                        if (wl.Count() != 0)
                        {
                            for (int i = 0; i < wl.Count(); i++)
                            {
                                m.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                            }
                            k = true;
                        }

                        Status.Text = k ? "Sniper Switch Active ✓" : "Application failed - try again!";
                        Console.Beep(k ? 250 : 2000, 300);
                    }
                }
            }
            catch (Exception ex)
            {
                Status.Text = "Error: " + ex.Message;
            }
        }

        private async void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (guna2ToggleSwitch6.Checked)
                {
                    string search = "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 13 40";
                    string replace = "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 19 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 13 40";
                    bool k = false;

                    if (Process.GetProcessesByName("HD-Player").Length == 0)
                    {
                        Status.Text = "HD-Player not found";
                    }
                    else
                    {
                        m.OpenProcess("HD-Player");
                        IEnumerable<long> wl = await m.AoBScan(search, writable: true);

                        if (wl.Count() != 0)
                        {
                            for (int i = 0; i < wl.Count(); i++)
                            {
                                m.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                            }
                            k = true;
                        }

                        Status.Text = k ? "Activating Success! ✓" : "Application failed - try again!";
                        Console.Beep(k ? 250 : 2000, 300);
                    }
                }
            }
            catch (Exception ex)
            {
                Status.Text = "Error: " + ex.Message;
            }
        }

        // Helper method for safe memory operations
        private bool SafeMemoryWrite(string addressHex, string type, string value)
        {
            try
            {
                string trimmedValue = value.Trim();
                
                switch (type.ToLower())
                {
                    case "int":
                        if (int.TryParse(trimmedValue, out int intVal))
                        {
                            m.WriteMemory(addressHex, type, trimmedValue);
                            return true;
                        }
                        break;
                    case "long":
                        if (long.TryParse(trimmedValue, out long longVal))
                        {
                            m.WriteMemory(addressHex, type, trimmedValue);
                            return true;
                        }
                        break;
                    case "bytes":
                        m.WriteMemory(addressHex, type, trimmedValue);
                        return true;
                    default:
                        m.WriteMemory(addressHex, type, trimmedValue);
                        return true;
                }
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void Youhan(string resourceName, string outputPath)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (manifestResourceStream == null)
                {
                    throw new ArgumentException("Resource '" + resourceName + "' not found.");
                }
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] array = new byte[manifestResourceStream.Length];
                    manifestResourceStream.Read(array, 0, array.Length);
                    fileStream.Write(array, 0, array.Length);
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        const uint PROCESS_CREATE_THREAD = 0x2;
        const uint PROCESS_QUERY_INFORMATION = 0x400;
        const uint PROCESS_VM_OPERATION = 0x8;
        const uint PROCESS_VM_WRITE = 0x20;
        const uint PROCESS_VM_READ = 0x10;
        const uint MEM_COMMIT = 0x1000;
        const uint PAGE_READWRITE = 4;

        private void guna2ToggleSwitch7_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                string processName = "HD-Player";
                string dllResourceName = "CLIPA_X_CHEAT.Properties.CLIPAcheat.dll";
                string tempDllPath = Path.Combine(Path.GetTempPath(), "YOUHAN_MENU.dll");
                Youhan(dllResourceName, tempDllPath);

                Process[] targetProcesses = Process.GetProcessesByName(processName);
                if (targetProcesses.Length == 0)
                {
                    MessageBox.Show("Process not found!");
                }
                else
                {
                    Process targetProcess = targetProcesses[0];
                    IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)tempDllPath.Length, MEM_COMMIT, PAGE_READWRITE);
                    IntPtr bytesWritten;
                    WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(tempDllPath), (uint)tempDllPath.Length, out bytesWritten);
                    CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                    Console.Beep(500, 300);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public class Snowflake
        {
            private static Random rand = new Random();
            public float X { get; private set; }
            public float Y { get; private set; }
            private float Speed;
            private float Size;

            private static readonly Font snowflakeFont = new Font("Arial", 16);
            private static readonly Brush snowflakeBrush = new SolidBrush(Color.Green);

            public Snowflake(Random random, int formWidth)
            {
                X = random.Next(formWidth);
                Y = 0;
                Speed = (float)(random.NextDouble() * 30 + 2);
                Size = (float)(random.NextDouble() * 30 + 2);
            }

            public void Update()
            {
                Y += Speed;
            }

            public void Draw(Graphics g)
            {
                string snowflakeChar = "🕸";
                g.DrawString(snowflakeChar, snowflakeFont, snowflakeBrush, X, Y);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var snowflake in snowflakes)
            {
                snowflake.Draw(g);
            }
        }

        private void particles_Tick_1(object sender, EventArgs e)
        {
            Particles._Instance.Invalidate();
            Particles.MoveCircles(Particles._Particles);

            if (snowflakes.Count < 10)
            {
                snowflakes.Add(new Snowflake(rand, this.ClientSize.Width));
            }

            foreach (var snowflake in snowflakes)
            {
                snowflake.Update();
            }

            snowflakes.RemoveAll(s => s.Y > this.ClientSize.Height);
            this.Invalidate();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label46_Click(object sender, EventArgs e)
        {
        }

        private void label25_Click(object sender, EventArgs e)
        {
        }

        private async void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                try
                {
                    string search = "8D E5 08 60 8D E5 82 00 8D E8 10 17 02 E3 3C FF 2F E1";
                    string replace = "8D E5 08 60 8D E5 82 00 8D E8 10 17 02 E3 00 F0 20 E3";
                    bool k = false;

                    if (Process.GetProcessesByName("HD-Player").Length == 0)
                    {
                        Status.Text = "HD-Player not found";
                    }
                    else
                    {
                        m.OpenProcess("HD-Player");
                        IEnumerable<long> wl = await m.AoBScan(search, writable: true);

                        if (wl.Count() != 0)
                        {
                            for (int i = 0; i < wl.Count(); i++)
                            {
                                m.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                            }
                            k = true;
                        }

                        guna2ToggleSwitch1.Text = k ? "Activating Success! ✓" : "Application failed - try again!";
                    }
                }
                catch (Exception ex)
                {
                    Status.Text = "Error: " + ex.Message;
                }
            }
        }

        private async void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                m.OpenProcess(proc);

                var result = await m.AoBScan("FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43");
                if (result.Any())
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 Enderecoleitura = CurrentAddress + 0xFA;
                        Int64 EndercoEscrita = CurrentAddress + 0x35A;

                        var Read = m.ReadMemory<int>(Enderecoleitura.ToString("X"));
                        string valueToWrite = Read.ToString().Trim();

                        if (SafeMemoryWrite(EndercoEscrita.ToString("X"), "int", valueToWrite))
                        {
                            Status.Text = "Aimbot Exeternal Done ✓";
                        }
                        else
                        {
                            Status.Text = "Invalid value: " + valueToWrite;
                        }
                    }
                }
                else
                {
                    Status.Text = "Aimbot Exeternal Error - Pattern not found";
                }
            }
            catch (Exception ex)
            {
                Status.Text = "Error: " + ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void Status_Click(object sender, EventArgs e)
        {
        }

        private void label27_Click(object sender, EventArgs e)
        {
        }

        private void label26_Click(object sender, EventArgs e)
        {
        }

        private void label98_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label89_Click(object sender, EventArgs e)
        {
        }

        // Placeholder methods for remaining event handlers (to be implemented)
        private async void guna2ToggleSwitch11_CheckedChanged(object sender, EventArgs e) { }
        private async void guna2Button1_Click(object sender, EventArgs e) { }
        private async void guna2ToggleSwitch12_CheckedChanged(object sender, EventArgs e) { }
        private async void guna2Button2_Click(object sender, EventArgs e) { }
        private async void guna2ToggleSwitch10_CheckedChanged_1(object sender, EventArgs e) { }
        private async void guna2Button1_Click_1(object sender, EventArgs e) { }
        private async void guna2ToggleSwitch10_CheckedChanged_2(object sender, EventArgs e) { }
        private async void guna2ToggleSwitch11_CheckedChanged_1(object sender, EventArgs e) { }
        private async void guna2Button1_Click_2(object sender, EventArgs e) { }
        private async void guna2TileButton1_Click(object sender, EventArgs e) { }
        private async void guna2Button2_Click_1(object sender, EventArgs e) { }
        private async void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e) { }
        private async void guna2Button3_Click(object sender, EventArgs e) { }
        private async void guna2Button4_Click(object sender, EventArgs e) { }
        private async void guna2ToggleSwitch14_CheckedChanged(object sender, EventArgs e) { }
    }
}
