using System.Runtime.InteropServices;

namespace echo_ja
{

    public partial class ECHO : Form
    {
        delegate int multiplication(int a, int b);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        public ECHO()
        {
            InitializeComponent();
        }

        private void czas_wykonania_Click(object sender, EventArgs e)
        {

        }

        private void wybor_obrazu_Click(object sender, EventArgs e)
        {
            if (okno_plikow.ShowDialog() == DialogResult.OK) {
                ramka.Load(okno_plikow.FileName);
            };
        }

        private void start_Click(object sender, EventArgs e)
        {
            IntPtr pDll = LoadLibrary(@"echo_dll_c.dll");
            IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "multiplication");
            multiplication mul = (multiplication)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(multiplication));

            logging.Text = "C: [jesli wyswietlam 32 wynik jest poprawny] " + mul(2, 16).ToString();
        }

        private void ramka_Click(object sender, EventArgs e)
        {

        }
    }
}