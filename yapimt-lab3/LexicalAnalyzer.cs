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

        private Dictionary<string, (string type, int number)> staticKeywordsTable = new Dictionary<string, (string, int)>
        {
            {"abstract", ("keyword",1)},
            {"as", ("keyword",2)},
            {"base", ("keyword",3)},
            {"bool", ("keyword",4)},
            {"break", ("keyword",5)},
            {"byte", ("keyword",6)},
            {"case", ("keyword",7)},
            {"catch", ("keyword",8)},
            {"char", ("keyword",9)},
            {"checked", ("keyword",10)},
            {"class", ("keyword",11)},
            {"const", ("keyword",12)},
            {"continue", ("keyword",13)},
            {"decimal", ("keyword",14)},
            {"default", ("keyword",15)},
            {"delegate", ("keyword",16)},
            {"do", ("keyword",17)},
            {"double", ("keyword",18)},
            {"else", ("keyword",19)},
            {"enum", ("keyword",20)},
            {"event", ("keyword",21)},
            {"explicit", ("keyword",22)},
            {"extern", ("keyword",23)},
            {"false", ("keyword",24)},
            {"finally", ("keyword",25)},
            {"fixed", ("keyword",26)},
            {"float", ("keyword",27)},
            {"for", ("keyword",28)},
            {"foreach", ("keyword",29)},
            {"goto", ("keyword",30)},
            {"if", ("keyword",31)},
            {"implicit", ("keyword",32)},
            {"in", ("keyword",33)},
            {"int", ("keyword",34)},
            {"interface", ("keyword",35)},
            {"internal", ("keyword",36)},
            {"is", ("keyword",37)},
            {"lock", ("keyword",38)},
            {"long", ("keyword",39)},
            {"namespace", ("keyword",40)},
            {"new", ("keyword",41)},
            {"null", ("keyword",42)},
            {"object", ("keyword",43)},
            {"operator", ("keyword",44)},
            {"out", ("keyword",45)},
            {"override", ("keyword",46)},
            {"params", ("keyword",47)},
            {"private", ("keyword",48)},
            {"protected", ("keyword",49)},
            {"public", ("keyword",50)},
            {"readonly", ("keyword",51)},
            {"ref", ("keyword",52)},
            {"return", ("keyword",53)},
            {"sbyte", ("keyword",54)},
            {"sealed", ("keyword",55)},
            {"short", ("keyword",56)},
            {"sizeof", ("keyword",57)},
            {"stackalloc", ("keyword",58)},
            {"static", ("keyword",59)},
            {"string", ("keyword",60)},
            {"struct", ("keyword",61)},
            {"switch", ("keyword",62)},
            {"this", ("keyword",63)},
            {"throw", ("keyword",64)},
            {"true", ("keyword",65)},
            {"try", ("keyword",66)},
            {"typeof", ("keyword",67)},
            {"uint", ("keyword",68)},
            {"ulong", ("keyword",69)},
            {"unchecked", ("keyword",70)},
            {"unsafe", ("keyword",71)},
            {"ushort", ("keyword",72)},
            {"using", ("keyword",73)},
            {"virtual", ("keyword",74)},
            {"void", ("keyword",75)},
            {"volatile", ("keyword",76)},
            {"while", ("keyword",77)},
        };
        private Dictionary<string, (string type, int number)> staticOperatorsTable = new Dictionary<string, (string, int)>
        {
            {"+", ("operator", 1)},
            {"-", ("operator", 2)},
            {"*", ("operator", 3)},
            {"/", ("operator", 4)},
            {"==", ("operator", 5)},
            {"!=", ("operator", 6)},

        };
        private Dictionary<string, (string type, int number)> staticSpecialSymbolsTable = new Dictionary<string, (string, int)>
        {
            {";", ("special", 1)},
            {",", ("special", 2)},
            {"(", ("special", 3)},
            {")", ("special", 4)},
            {"{", ("special", 5)},
            {"}", ("special", 6)},

        };
        private Dictionary<string, (string type, int number)> keywordsTable;
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

        public void Analyze(string _input, ref Dictionary<string, (string type, int number)> _keywordsTable, ref Dictionary<string, (string type, int number)> _operatorsTable, ref Dictionary<string, (string type, int number)> _specialSymbolsTable, ref Dictionary<string, (string type, int number)> _identifiersTable, ref Dictionary<string, (string type, int number)> _numericConstantsTable, ref Dictionary<string, (string type, int number)> _stringConstantsTable)

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

            if (staticKeywordsTable.ContainsKey(Buf))
            {
                var (type, number) = keywordsTable[Buf];
                MessageBox.Show($"Keyword: {Buf}, Type: {type}, Number: {number}");
            }
            else
            {
                var (type, number) = Buf_Ident();
                MessageBox.Show($"Identifier: {Buf}, Type: {type}, Number: {number}");
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
            MessageBox.Show($"Numeric Constant: {Buf}, Type: {type}, Number: {number}");
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
            MessageBox.Show($"String Constant: {Buf}, Type: {type}, Number: {number}");
        }

        private void ProcessOperatorOrSpecialSymbol()
        {
            Buf = input[position].ToString();
            position++;

            if (staticOperatorsTable.ContainsKey(Buf))
            {
                var (type, number) = operatorsTable[Buf];
                MessageBox.Show($"Operator: {Buf}, Type: {type}, Number: {number}");
            }
            else if (staticSpecialSymbolsTable.ContainsKey(Buf))
            {
                var (type, number) = specialSymbolsTable[Buf];
                MessageBox.Show($"Special Symbol: {Buf}, Type: {type}, Number: {number}");
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
