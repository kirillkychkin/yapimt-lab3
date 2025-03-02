namespace yapimt_lab3
{
    public partial class lexer : Form
    {
        public lexer()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string getAboutText()
        {
            return "Программа разработана в 2025 году в рамках каурса 'Языки программирования и методы трансляции' в качестве третьей лабораторной работы." + Environment.NewLine + Environment.NewLine + "Программа создана для лексического анализа кода программ на C#";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getAboutText());
        }
    }
}
