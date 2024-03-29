﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ECHO
{

    public partial class Form1 : Form
    {
        // ZMIENIĆ NA TYPY POBIERANE I ZWRACANE
        delegate int GenerujEcho(byte[] tablica, int dlugosc_tablicy, int index, byte[] tablica_kopia, int width, int stride);


        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        //obrazek jako tablica bajtowa z headerem
        byte[] wartoscirgb;

        //adres pierwszej linijki
        IntPtr wskaznik;
        int bytes;
        Bitmap wczytany;
        System.Drawing.Imaging.BitmapData bmpData;
        Rectangle rect;

        public Form1()
        {
            InitializeComponent();
        }


        private void wybierz_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                //wczytywanie obrazka
                wczytany = new Bitmap(openFileDialog1.FileName);
                if (wczytany.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    obraz.Load(openFileDialog1.FileName);//zostaje;
                    rect = new Rectangle(0, 0, wczytany.Width, wczytany.Height); //(0,0) lokalizacja

                    bmpData =
                        //LockBits Blokuje pamięć systemową Bitmapy.
                        wczytany.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        wczytany.PixelFormat);

                    //adres pierwszej linijki
                    wskaznik = bmpData.Scan0;

                    bytes = Math.Abs(bmpData.Stride) * wczytany.Height;
                    wartoscirgb = new byte[bytes];

                    //Kopiujemy do tablicy
                    System.Runtime.InteropServices.Marshal.Copy(wskaznik, wartoscirgb, 0, bytes);

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
                        long poczatek;
                        long koniec;

                        var kopia_wartoscirgb = wartoscirgb;
                        this.status.Text = "w trakcie";
                        this.status.Refresh();
                        /*
                        for (int m = 1; m <= 64; m++)
                        {
                            watki.Value = m;
                        */

                        if (watki.Value > 1)//czemu?
                            {


                                int modulo = wartoscirgb.Length % Decimal.ToInt32(watki.Value);
                                int iloraz = wartoscirgb.Length / Decimal.ToInt32(watki.Value);

                                int[] poczatki_przedzialow = new int[Decimal.ToInt32(watki.Value)];
                                int[] dlugosci_przedzialow = new int[Decimal.ToInt32(watki.Value)];

                                Thread[] zadania = new Thread[Decimal.ToInt32(watki.Value)];

                                poczatki_przedzialow[0] = 0;
                                dlugosci_przedzialow[0] = iloraz;

                                for (int i = 1; i < watki.Value; i++)
                                {
                                    poczatki_przedzialow[i] = poczatki_przedzialow[i - 1] + dlugosci_przedzialow[i - 1];
                                    dlugosci_przedzialow[i] = iloraz + (i <= modulo ? 1 : 0);
                                }

                                int stride = bmpData.Stride;
                                int ostatnia_kolumna = bmpData.Width * 3;

                                poczatek = Stopwatch.GetTimestamp();
                                
                                    for (int i = 0; i < watki.Value; i++)
                                    {
                                       int j = i; //wyscig
                                                   //Thread tmp = new Thread(() => fun(wartoscirgb, dlugosci_przedzialow[j], poczatki_przedzialow[j], kopia_wartoscirgb, width, dlugosc, stride, gen));
                                        Thread tmp = new Thread(() => gen(wartoscirgb, dlugosci_przedzialow[j], poczatki_przedzialow[j], kopia_wartoscirgb, ostatnia_kolumna, stride));
                                        zadania[j] = tmp;
                                        tmp.Start();

                                        //Thread.Sleep(1);
                                    }

                                    foreach (var task in zadania)
                                    {
                                        task.Join();
                                    }
                                    koniec = Stopwatch.GetTimestamp();
                                    
                            }
                            else
                            {
                                poczatek = Stopwatch.GetTimestamp();
                                
                                gen(wartoscirgb, wartoscirgb.Length, 0, kopia_wartoscirgb, bmpData.Width*3, bmpData.Stride);
                                koniec = Stopwatch.GetTimestamp();
                                
                            }

                            System.Runtime.InteropServices.Marshal.Copy(wartoscirgb, 0, wskaznik, bytes);
                            
                            obraz.Image = wczytany;

                            czaswykonania.Text = (koniec - poczatek /*sw.ElapsedMilliseconds*/).ToString() + " tiknięć";

                        /* 
                            using (StreamWriter writetext = File.AppendText("wyniki.txt"))
                            {
                                writetext.WriteLine((koniec - poczatek sw.ElapsedMilliseconds).ToString());
                            }
                        }; */


                        status.Text = "zatrzymane";
                        this.status.Refresh();
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

        private void watki_ValueChanged(object sender, EventArgs e)
        {

        }

        private void czaswykonania_Click(object sender, EventArgs e)
        {

        }

        private void opisczaswykonania_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (obraz != null && obraz.Image != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Obraz .bmp|*.bmp";
                saveFileDialog1.Title = "Zapisz jako .bmp";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    obraz.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void status_Click(object sender, EventArgs e)
        {

        }
    }
}
