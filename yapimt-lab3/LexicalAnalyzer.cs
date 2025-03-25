using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapimt_lab3
{
    using System;
    using System.Collections.Generic;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class LexicalAnalyzer
    {
        private string input;
        private int position;
        private string Buf;

        public LexicalAnalyzer()
        {
            this.position = 0;
            this.Buf = "";
        }

        public void Analyze(string _input, ref List<KeyValuePair<string, int>> lexemSequence, ref Dictionary<string, (string type, int number)> identifiersTable, ref Dictionary<string, (string type, int number)> numericConstantsTable, ref Dictionary<string, (string type, int number)> stringConstantsTable)

        {
            this.input = _input;

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
                    ProcessIdentifierOrKeyword(ref lexemSequence, ref identifiersTable);
                }
                else if (char.IsDigit(currentChar))
                {
                    ProcessNumericConstant(ref numericConstantsTable);
                }
                else if (currentChar == '"')
                {
                    ProcessStringConstant(ref stringConstantsTable);
                }
                else if (internalLexems.staticOperatorsTable.ContainsKey(currentChar.ToString()) || internalLexems.staticSpecialSymbolsTable.ContainsKey(currentChar.ToString()))
                {
                    ProcessOperatorOrSpecialSymbol(ref lexemSequence);
                }
                else
                {
                    position++;
                }
            }
        }

        private void ProcessIdentifierOrKeyword(ref List<KeyValuePair<string, int>> lexemSequence, ref Dictionary<string, (string, int)> identifiersTable)
        {
            Buf = "";
            while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
            {
                Pbuf(input[position]);
                position++;
            }

            if (internalLexems.staticKeywordsTable.ContainsKey(Buf))
            {
                //if(!keywordsTable.ContainsKey(Buf))
                //{
                //    var (type, number) = internalLexems.staticKeywordsTable[Buf];
                //    keywordsTable[Buf] = 1;
                //}
                //else
                //{
                //    keywordsTable[Buf] += 1;
                //}
                //MessageBox.Show($"Keyword: {Buf}, Type: {type}, Number: {number}");
                var (type, number) = Buf_Key();
                KeyValuePair<string, int> nextKeyword = new KeyValuePair<string, int>(type, number);
                lexemSequence.Add(nextKeyword);
                //MessageBox.Show($"Keyword: {Buf}, Type: {type}, Number: {number}");

            }
            else
            {
                var (type, number) = Buf_Ident(ref identifiersTable); 
                KeyValuePair<string, int> nextIdentifier = new KeyValuePair<string, int>(type, number);
                lexemSequence.Add(nextIdentifier);
                //MessageBox.Show($"Identifier: {Buf}, Type: {type}, Number: {number}");
            }
        }

        private void ProcessNumericConstant(ref Dictionary<string, (string, int)> numericConstantsTable)
        {
            Buf = "";
            while (position < input.Length && char.IsDigit(input[position]))
            {
                Pbuf(input[position]);
                position++;
            }

            var (type, number) = Buf_Num(ref numericConstantsTable);
            //MessageBox.Show($"Numeric Constant: {Buf}, Type: {type}, Number: {number}");
        }

        private void ProcessStringConstant(ref Dictionary<string, (string, int)> stringConstantsTable)
        {
            Buf = "";
            position++; // Пропустить открывающую кавычку
            while (position < input.Length && input[position] != '"')
            {
                Pbuf(input[position]);
                position++;
            }
            position++; // Пропустить закрывающую кавычку

            var (type, number) = Buf_Str(ref stringConstantsTable);
            //MessageBox.Show($"String Constant: {Buf}, Type: {type}, Number: {number}");
        }

        private void ProcessOperatorOrSpecialSymbol(ref List<KeyValuePair<string, int>> lexemSequence)
        {
            Buf = input[position].ToString();
            position++;

            if (internalLexems.staticOperatorsTable.ContainsKey(Buf))
            {
                var (type, number) = internalLexems.staticOperatorsTable[Buf];
                //MessageBox.Show($"Operator: {Buf}, Type: {type}, Number: {number}");
                KeyValuePair<string, int> nextOperator = new KeyValuePair<string, int>(type, number);
                lexemSequence.Add(nextOperator);
            }
            else if (internalLexems.staticSpecialSymbolsTable.ContainsKey(Buf))
            {
                var (type, number) = internalLexems.staticSpecialSymbolsTable[Buf];
                //MessageBox.Show($"Special Symbol: {Buf}, Type: {type}, Number: {number}");
                KeyValuePair<string, int> nextSymbol = new KeyValuePair<string, int>(type, number);
                lexemSequence.Add(nextSymbol);
            }
        }

        private void Pbuf(char c)
        {
            Buf += c;
        }

        private (string type, int number) Buf_Key()
        {
            if (internalLexems.staticKeywordsTable.ContainsKey(Buf))
            {
                return internalLexems.staticKeywordsTable[Buf];
            }
            return (null, -1);
        }

        private (string type, int number) Buf_Ident(ref Dictionary<string, (string, int)> identifiersTable)
        {
            if (!identifiersTable.ContainsKey(Buf))
            {
                identifiersTable[Buf] = ("identifier", identifiersTable.Count + 1);
            }
            return identifiersTable[Buf];
        }

        private (string type, int number) Buf_Num(ref Dictionary<string, (string, int)> numericConstantsTable)
        {
            if (!numericConstantsTable.ContainsKey(Buf))
            {
                numericConstantsTable[Buf] = ("numeric", numericConstantsTable.Count + 1);
            }
            return numericConstantsTable[Buf];
        }

        private (string type, int number) Buf_Str(ref Dictionary<string, (string, int)> stringConstantsTable)
        {
            if (!stringConstantsTable.ContainsKey(Buf))
            {
                stringConstantsTable[Buf] = ("string", stringConstantsTable.Count + 1);
            }
            return stringConstantsTable[Buf];
        }
    }
}
