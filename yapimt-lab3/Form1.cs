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
            return "��������� ����������� � 2025 ���� � ������ ������ '����� ���������������� � ������ ����������' � �������� ������� ������������ ������." + Environment.NewLine + Environment.NewLine + "��������� ������� ��� ������������ ������� ���� �������� �� C#";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getAboutText());
        }
    }
}
