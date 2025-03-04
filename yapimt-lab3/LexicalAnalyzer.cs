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

        private Dictionary<string, (string type, int number)> keywordsTable;
        private Dictionary<string, (string type, int number)> operatorsTable;
        private Dictionary<string, (string type, int number)> specialSymbolsTable;
        private Dictionary<string, (string type, int number)> identifiersTable;
        private Dictionary<string, (string type, int number)> numericConstantsTable;
        private Dictionary<string, (string type, int number)> stringConstantsTable;

        public LexicalAnalyzer(string input)
        {
            this.input = input;
            this.position = 0;
            this.Buf = "";

            // Инициализация таблиц
            keywordsTable = new Dictionary<string, (string, int)>
        {
            {"int", ("keyword", 1)},
            {"float", ("keyword", 2)},
            {"if", ("keyword", 3)},
            {"else", ("keyword", 4)},
            
        };

            operatorsTable = new Dictionary<string, (string, int)>
        {
            {"+", ("operator", 1)},
            {"-", ("operator", 2)},
            {"*", ("operator", 3)},
            {"/", ("operator", 4)},
            {"==", ("operator", 5)},
            {"!=", ("operator", 6)},
            
        };

            specialSymbolsTable = new Dictionary<string, (string, int)>
        {
            {";", ("special", 1)},
            {",", ("special", 2)},
            {"(", ("special", 3)},
            {")", ("special", 4)},
            {"{", ("special", 5)},
            {"}", ("special", 6)},
            
        };

            identifiersTable = new Dictionary<string, (string, int)>();
            numericConstantsTable = new Dictionary<string, (string, int)>();
            stringConstantsTable = new Dictionary<string, (string, int)>();
        }

        public void Analyze()
        {
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
                    ProcessIdentifierOrKeyword();
                }
                else if (char.IsDigit(currentChar))
                {
                    ProcessNumericConstant();
                }
                else if (currentChar == '"')
                {
                    ProcessStringConstant();
                }
                else if (operatorsTable.ContainsKey(currentChar.ToString()) || specialSymbolsTable.ContainsKey(currentChar.ToString()))
                {
                    ProcessOperatorOrSpecialSymbol();
                }
                else
                {
                    position++;
                }
            }
        }

        private void ProcessIdentifierOrKeyword()
        {
            Buf = "";
            while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
            {
                Pbuf(input[position]);
                position++;
            }

            if (keywordsTable.ContainsKey(Buf))
            {
                var (type, number) = keywordsTable[Buf];
                Console.WriteLine($"Keyword: {Buf}, Type: {type}, Number: {number}");
            }
            else
            {
                var (type, number) = Buf_Ident();
                Console.WriteLine($"Identifier: {Buf}, Type: {type}, Number: {number}");
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
            Console.WriteLine($"Numeric Constant: {Buf}, Type: {type}, Number: {number}");
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
            Console.WriteLine($"String Constant: {Buf}, Type: {type}, Number: {number}");
        }

        private void ProcessOperatorOrSpecialSymbol()
        {
            Buf = input[position].ToString();
            position++;

            if (operatorsTable.ContainsKey(Buf))
            {
                var (type, number) = operatorsTable[Buf];
                Console.WriteLine($"Operator: {Buf}, Type: {type}, Number: {number}");
            }
            else if (specialSymbolsTable.ContainsKey(Buf))
            {
                var (type, number) = specialSymbolsTable[Buf];
                Console.WriteLine($"Special Symbol: {Buf}, Type: {type}, Number: {number}");
            }
        }

        private void Pbuf(char c)
        {
            Buf += c;
        }

        private (string type, int number) Buf_Key()
        {
            if (keywordsTable.ContainsKey(Buf))
            {
                return keywordsTable[Buf];
            }
            return (null, -1);
        }

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
