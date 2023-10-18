using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
        public Form1()
        {
            InitializeComponent();
        }


        private void wybierz_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                obraz.Load(openFileDialog1.FileName);
            }
        }


        private void start_Click_1(object sender, EventArgs e)
        {
            string dllChoice;
            if (asmdll.Checked)
            {
                dllChoice = "ECHOasm.dll";
            }
            else
            {
                dllChoice = "ECHOc.dll";
            }
            var dllHandle = LoadLibrary(dllChoice);
            if (dllHandle != IntPtr.Zero)
            {
                var procAddress = GetProcAddress(dllHandle, "GenerujEcho");

                if (procAddress != IntPtr.Zero)
                {
                    GenerujEcho filterImage = (GenerujEcho)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(GenerujEcho));
                    int result = filterImage(3, 4);
                    MessageBox.Show($"3 * 4 = {result}");
                }
                else
                {
                    MessageBox.Show("Nie znaleziono funkcji");
                }
                FreeLibrary(dllHandle);
            }
            else
            {
                MessageBox.Show("Nie znaleziono biblioteki");
            }
        }
    }
}
