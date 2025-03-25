using System;
using System.Collections.Generic;
namespace yapimt_lab3
{
    public partial class lexer : Form
    {
        private LexicalAnalyzer analyzer;
        public lexer()
        {
            InitializeComponent();

            identifiersTable = new Dictionary<string, (string, int)>();
            numericConstantsTable = new Dictionary<string, (string, int)>();
            stringConstantsTable = new Dictionary<string, (string, int)>();

            analyzer = new LexicalAnalyzer();
        }
        private Dictionary<string, (string type, int number)> identifiersTable;
        private Dictionary<string, (string type, int number)> numericConstantsTable;
        private Dictionary<string, (string type, int number)> stringConstantsTable;

        private List<KeyValuePair<string, int>> lexemSequence;

        private Dictionary<string, int> identifiersList;
        private Dictionary<string, int> numericConstantsList;
        private Dictionary<string, int> stringConstantsList;
        private Dictionary<string, int> keywordsList;
        private Dictionary<string, int> operatorsList;
        private Dictionary<string, int> specSymbolsList;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string getAboutText()
        {
            return "��������� ����������� � 2025 ���� � ������ ����� '����� ���������������� � ������ ����������' � �������� ������� ������������ ������." + Environment.NewLine + Environment.NewLine + "��������� ������� ��� ������������ ������� ���� �������� �� C#";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getAboutText());
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            lexemSequence = new List<KeyValuePair<string, int>>();
            identifiersTable = new Dictionary<string, (string, int)>();
            numericConstantsTable = new Dictionary<string, (string, int)>();
            stringConstantsTable = new Dictionary<string, (string, int)>();
            string textToAnalyze  = codeTextBox.Text;
            analyzer.Analyze(
                textToAnalyze, 
                ref lexemSequence, 
                ref identifiersTable, 
                ref numericConstantsTable, 
                ref stringConstantsTable, 
                ref identifiersList, 
                ref numericConstantsList, 
                ref stringConstantsList, 
                ref keywordsList, 
                ref operatorsList, 
                ref specSymbolsList
                );
            string keywordsOut = "";

            foreach (KeyValuePair<string, int> entry in lexemSequence)
            {
                // �������� � ������ ������
                keywordsOut += $"type: {entry.Key} number:  {entry.Value.ToString()} {Environment.NewLine}";
            }
            MessageBox.Show("������! ���������� ��������� �� ������� ��������� �������");
            textSequence.Text = keywordsOut;
        }
    }
}
