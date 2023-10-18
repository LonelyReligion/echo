using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ECHO
{

    public partial class Form1 : Form
    {
        // ZMIENIĆ NA TYPY POBIERANE I ZWRACANE
        delegate int GenerujEcho(int a, int b);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        //obrazek jako tablica bajtowa
        public byte[] data;
        public Form1()
        {
            InitializeComponent();
        }


        private void wybierz_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                obraz.Load(openFileDialog1.FileName);

                //wczytywanie obrazka
                var wczytany = new Bitmap(openFileDialog1.FileName);
                using (MemoryStream ms = new MemoryStream())
                {
                    wczytany.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = ms.ToArray();
                }

            }
            
        }


        private void start_Click_1(object sender, EventArgs e)
        {
            string wybordll;
            if (asmdll.Checked)
            {
                wybordll = "ECHOasm.dll";
            }
            else
            {
                wybordll = "ECHOc.dll";
            }
            var uchwytdll = LoadLibrary(wybordll);
            if (uchwytdll != IntPtr.Zero)
            {
                var procAddress = GetProcAddress(uchwytdll, "GenerujEcho");

                if (procAddress != IntPtr.Zero)
                {
                    GenerujEcho gen = (GenerujEcho)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(GenerujEcho));
                    status.Text = gen(1, 2).ToString();

                }
                else
                {
                    status.Text = "Nie znaleziono funkcji";
                }
                FreeLibrary(uchwytdll);
            }
            else
            {
                status.Text = "Nie znaleziono biblioteki";
            }
        }

        private void watki_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
