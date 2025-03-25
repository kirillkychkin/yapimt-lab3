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
        private Dictionary<string, (string type, int number)> keywordsTable;
        private Dictionary<string, (string type, int number)> operatorsTable;
        private Dictionary<string, (string type, int number)> specialSymbolsTable;
        private Dictionary<string, (string type, int number)> identifiersTable;
        private Dictionary<string, (string type, int number)> numericConstantsTable;
        private Dictionary<string, (string type, int number)> stringConstantsTable;

        private List<KeyValuePair<string, int>> lexemSequence;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string getAboutText()
        {
            return "Программа разработана в 2025 году в рамках курса 'Языки программирования и методы трансляции' в качестве третьей лабораторной работы." + Environment.NewLine + Environment.NewLine + "Программа создана для лексического анализа кода программ на C#";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getAboutText());
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            lexemSequence = new List<KeyValuePair<string, int>>();
            keywordsTable = new Dictionary<string, (string, int)>();
            operatorsTable = new Dictionary<string, (string, int)>();
            specialSymbolsTable = new Dictionary<string, (string, int)>();
            identifiersTable = new Dictionary<string, (string, int)>();
            numericConstantsTable = new Dictionary<string, (string, int)>();
            stringConstantsTable = new Dictionary<string, (string, int)>();
            string textToAnalyze  = codeTextBox.Text;
            analyzer.Analyze(textToAnalyze, ref lexemSequence, ref keywordsTable, ref operatorsTable, ref specialSymbolsTable, ref identifiersTable, ref numericConstantsTable, ref stringConstantsTable);
            string keywordsOut = "";

            foreach (KeyValuePair<string, int> entry in lexemSequence)
            {
                keywordsOut += $"{entry.Key} met {entry.Value.ToString()} times {Environment.NewLine}";
            }
            MessageBox.Show(keywordsOut);
        }
    }
}
