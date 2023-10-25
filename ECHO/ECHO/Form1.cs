using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
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
        private static readonly object klucz = new Object();


        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        //obrazek jako tablica bajtowa z headerem
        byte[] wartoscirgb;

        public Form1()
        {
            InitializeComponent();
        }


        private void wybierz_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                //wczytywanie obrazka
                var wczytany = new Bitmap(openFileDialog1.FileName);
                if (wczytany.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    obraz.Load(openFileDialog1.FileName);//zostaje;
                    Rectangle rect = new Rectangle(0, 0, wczytany.Width, wczytany.Height); //(0,0) lokalizacja

                    System.Drawing.Imaging.BitmapData bmpData =
                        //LockBits Blokuje pamięć systemową Bitmapy.
                        wczytany.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        wczytany.PixelFormat);

                    //adres pierwszej linijki
                    IntPtr wskaznik = bmpData.Scan0;

                    int bytes = Math.Abs(bmpData.Stride) * wczytany.Height;
                    wartoscirgb = new byte[bytes];

                    //Kopiujemy do tablicy
                    System.Runtime.InteropServices.Marshal.Copy(wskaznik, wartoscirgb, 0, bytes);
                    status.Text = wartoscirgb[0].ToString(); //uzywam do sprawdzenia czy pozbylismy sie headera - tak! przy bialej .bmp jest 256

                    // Odblokowuje 
                    wczytany.UnlockBits(bmpData);
                }
                else
                {
                    MessageBox.Show("Wczytaj 24 - bitową bitmapę i spróbuj ponownie.");
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
                    if (wartoscirgb?.Length > 0)
                    {
                        GenerujEcho gen = (GenerujEcho)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(GenerujEcho));
                        string wynik = "";

                        Thread[] zadania = new Thread[Decimal.ToInt32(watki.Value)];
                        if (watki.Value > 1)//czemu?
                        {
                            for (int i = 0; i < watki.Value; i++)
                            {
                                int j = i; //wyscig
                                Thread tmp = new Thread(() => fcja(j, ref wynik, gen));
                                zadania[j] = tmp;
                                tmp.Start();
                            }
                        }
                        else
                        {
                            wynik = gen(1, 2).ToString();
                        }

                        for (int i = 1; i < watki.Value; i++)
                        {
                            int j = i; //wyscig
                            zadania[j].Join();
                        }
                        status.Text = wynik;
                    }
                    else {
                        MessageBox.Show("Aby skorzystać z tej funkcji musisz wgrać bitmapę.");
                    }
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

        //ref jest konieczne, aby zmiana była zapisywana na zewnątrz
        private void fcja(int i, ref string wynik, GenerujEcho gen) {
            lock (klucz) { //lock zapobiega utracie danych podczas jednoczesnego dostępu do zmiennej wynik
                wynik += gen(i, 2).ToString(); 
            };
        }
        private void watki_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
