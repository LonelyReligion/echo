namespace echo_ja
{
    public partial class ECHO : Form
    {
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
    }
}