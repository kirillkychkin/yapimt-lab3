using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapimt_lab3
{
    using System;
    using System.Collections.Generic;

    public class LexicalAnalyzer
    {
        private string input;
        private int position;
        private string Buf;

        private Dictionary<string,int> keywordsTable;
        private Dictionary<string, (string type, int number)> operatorsTable;
        private Dictionary<string, (string type, int number)> specialSymbolsTable;
        private Dictionary<string, (string type, int number)> identifiersTable;
        private Dictionary<string, (string type, int number)> numericConstantsTable;
        private Dictionary<string, (string type, int number)> stringConstantsTable;

        public LexicalAnalyzer()
        {
            this.position = 0;
            this.Buf = "";
        }

        public void Analyze(string _input, ref Dictionary<string, int> _keywordsTable, ref Dictionary<string, (string type, int number)> _operatorsTable, ref Dictionary<string, (string type, int number)> _specialSymbolsTable, ref Dictionary<string, (string type, int number)> _identifiersTable, ref Dictionary<string, (string type, int number)> _numericConstantsTable, ref Dictionary<string, (string type, int number)> _stringConstantsTable)

        {
            this.input = _input;
            keywordsTable = _keywordsTable;
            operatorsTable = _operatorsTable;
            specialSymbolsTable = _specialSymbolsTable;
            identifiersTable = _identifiersTable;
            numericConstantsTable = _numericConstantsTable;
            stringConstantsTable = _stringConstantsTable;
            while (position < input.Length)
            {
                char currentChar = input[position];

                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }

                if (char.IsLetter(currentChar))
                {
                    ProcessIdentifierOrKeyword(ref _keywordsTable);
                }
                else if (char.IsDigit(currentChar))
                {
                    ProcessNumericConstant();
                }
                else if (currentChar == '"')
                {
                    ProcessStringConstant();
                }
                else if (internalLexems.staticOperatorsTable.ContainsKey(currentChar.ToString()) || internalLexems.staticSpecialSymbolsTable.ContainsKey(currentChar.ToString()))
                {
                    ProcessOperatorOrSpecialSymbol();
                }
                else
                {
                    position++;
                }
            }
        }

        private void ProcessIdentifierOrKeyword(ref Dictionary<string, int> keywordsTable)
        {
            Buf = "";
            while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
            {
                Pbuf(input[position]);
                position++;
            }

            if (internalLexems.staticKeywordsTable.ContainsKey(Buf))
            {
                if(!keywordsTable.ContainsKey(Buf))
                {
                    var (type, number) = internalLexems.staticKeywordsTable[Buf];
                    keywordsTable[Buf] = 1;
                }
                else
                {
                    keywordsTable[Buf] += 1;
                }
                //MessageBox.Show($"Keyword: {Buf}, Type: {type}, Number: {number}");
            }
            else
            {
                var (type, number) = Buf_Ident();
                //MessageBox.Show($"Identifier: {Buf}, Type: {type}, Number: {number}");
            }
        }

        private void ProcessNumericConstant()
        {
            Buf = "";
            while (position < input.Length && char.IsDigit(input[position]))
            {
                Pbuf(input[position]);
                position++;
            }

            var (type, number) = Buf_Num();
            //MessageBox.Show($"Numeric Constant: {Buf}, Type: {type}, Number: {number}");
        }

        private void ProcessStringConstant()
        {
            Buf = "";
            position++; // Пропустить открывающую кавычку
            while (position < input.Length && input[position] != '"')
            {
                Pbuf(input[position]);
                position++;
            }
            position++; // Пропустить закрывающую кавычку

            var (type, number) = Buf_Str();
            //MessageBox.Show($"String Constant: {Buf}, Type: {type}, Number: {number}");
        }

        private void ProcessOperatorOrSpecialSymbol()
        {
            Buf = input[position].ToString();
            position++;

            if (internalLexems.staticOperatorsTable.ContainsKey(Buf))
            {
                var (type, number) = internalLexems.staticOperatorsTable[Buf];
                //MessageBox.Show($"Operator: {Buf}, Type: {type}, Number: {number}");
            }
            else if (internalLexems.staticSpecialSymbolsTable.ContainsKey(Buf))
            {
                var (type, number) = internalLexems.staticSpecialSymbolsTable[Buf];
                //MessageBox.Show($"Special Symbol: {Buf}, Type: {type}, Number: {number}");
            }
        }

        private void Pbuf(char c)
        {
            Buf += c;
        }

        //private (string type, int number) Buf_Key()
        //{
        //    if (keywordsTable.ContainsKey(Buf))
        //    {
        //        return keywordsTable[Buf];
        //    }
        //    return (null, -1);
        //}

        private (string type, int number) Buf_Ident()
        {
            if (!identifiersTable.ContainsKey(Buf))
            {
                identifiersTable[Buf] = ("identifier", identifiersTable.Count + 1);
            }
            return identifiersTable[Buf];
        }

        private (string type, int number) Buf_Num()
        {
            if (!numericConstantsTable.ContainsKey(Buf))
            {
                numericConstantsTable[Buf] = ("numeric", numericConstantsTable.Count + 1);
            }
            return numericConstantsTable[Buf];
        }

        private (string type, int number) Buf_Str()
        {
            if (!stringConstantsTable.ContainsKey(Buf))
            {
                stringConstantsTable[Buf] = ("string", stringConstantsTable.Count + 1);
            }
            return stringConstantsTable[Buf];
        }
    }
}
