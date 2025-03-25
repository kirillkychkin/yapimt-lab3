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

        public void Analyze(
            string _input, 
            ref List<KeyValuePair<string, int>> lexemSequence, 
            ref Dictionary<string, (string type, int number)> identifiersTable, 
            ref Dictionary<string, (string type, int number)> numericConstantsTable, 
            ref Dictionary<string, (string type, int number)> stringConstantsTable,
            ref Dictionary<string, int> identifiersList,
            ref Dictionary<string, int> numericConstantsList,
            ref Dictionary<string, int> stringConstantsList,
            ref Dictionary<string, int> keywordsList,
            ref Dictionary<string, int> operatorsList,
            ref Dictionary<string, int> specSymbolsList
            )

        {
            this.input = _input;
            // Идем до конца ввода
            while (position < input.Length)
            {
                // Первый символ лексемы
                char currentChar = input[position];

                // Пропускаем пробелы
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }
                // Если первый символ - буква, то это либо ключевое слово, либо идентификатор
                if (char.IsLetter(currentChar))
                {
                    ProcessIdentifierOrKeyword(ref lexemSequence, ref identifiersTable, ref identifiersList, ref keywordsList);
                }
                // Если первый символ - цифра, то лексема является числовой константой
                else if (char.IsDigit(currentChar))
                {
                    ProcessNumericConstant(ref lexemSequence, ref numericConstantsTable, ref numericConstantsList);
                }
                // Если первый символ - начало строки
                else if (currentChar == '"')
                {
                    ProcessStringConstant(ref lexemSequence, ref stringConstantsTable, ref stringConstantsList);
                }
                // Если есть в списке операторов или символов
                else if (internalLexems.staticOperatorsTable.ContainsKey(currentChar.ToString()) || internalLexems.staticSpecialSymbolsTable.ContainsKey(currentChar.ToString()))
                {
                    ProcessOperatorOrSpecialSymbol(ref lexemSequence, ref operatorsList, ref specSymbolsList);
                }
                // Идем дальше если не смогли определить (конец строки, табы и т.д.)
                else
                {
                    position++;
                }
            }
        }

        private void AddToList(ref Dictionary<string, int> targetList)
        {
            if (!targetList.ContainsKey(Buf))
            {
                targetList[Buf] = 1;
            }
            else
            {
                targetList[Buf] += 1;
            }
        }

        private void AddToSequence(string type, int number, ref List<KeyValuePair<string, int>> lexemSequence)
        {
            KeyValuePair<string, int> nextLexem = new KeyValuePair<string, int>(type, number);
            lexemSequence.Add(nextLexem);
        }

        private void ProcessIdentifierOrKeyword(
            ref List<KeyValuePair<string, int>> lexemSequence, 
            ref Dictionary<string, (string, int)> identifiersTable,
            ref Dictionary<string, int> identifiersList,
            ref Dictionary<string, int> keywordsList
            )
        {
            // Очистка предыдущего содержимого буфера
            Buf = "";
            // Записываем в буфер пока не дойдем до конца инпута и пока символы это цифры или буквы
            while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
            {
                Pbuf(input[position]);
                position++;
            }
            // Если есть в списке ключевых слов
            if (internalLexems.staticKeywordsTable.ContainsKey(Buf))
            {

                // Получаем тип, номер - записываем в lexemSequence
                var (type, number) = Buf_Key();
                AddToList(ref keywordsList);
                AddToSequence(type, number, ref lexemSequence);

            }
            // Если нет в списке ключевых слов
            else
            {
                // Получаем тип, номер - записываем в lexemSequence
                var (type, number) = Buf_Ident(ref identifiersTable);
                AddToList(ref identifiersList);
                AddToSequence(type, number, ref lexemSequence);
            }
        }

        private void ProcessNumericConstant(
            ref List<KeyValuePair<string, int>> lexemSequence, 
            ref Dictionary<string, (string, int)> numericConstantsTable,
            ref Dictionary<string, int> numericConstantsList
            )
        {
            Buf = "";
            while (position < input.Length && char.IsDigit(input[position]))
            {
                Pbuf(input[position]);
                position++;
            }

            // Получаем тип, номер - записываем в lexemSequence
            var (type, number) = Buf_Num(ref numericConstantsTable);
            AddToList(ref numericConstantsList);
            AddToSequence(type, number, ref lexemSequence);
        }

        private void ProcessStringConstant(
            ref List<KeyValuePair<string, int>> lexemSequence, 
            ref Dictionary<string, (string, int)> stringConstantsTable,
            ref Dictionary<string, int> stringConstantsList
            )
        {
            Buf = "";
            position++; // Пропустить открывающую кавычку
            while (position < input.Length && input[position] != '"')
            {
                Pbuf(input[position]);
                position++;
            }
            position++; // Пропустить закрывающую кавычку

            // Получаем тип, номер - записываем в lexemSequence
            var (type, number) = Buf_Str(ref stringConstantsTable);
            AddToList(ref stringConstantsList);
            AddToSequence(type, number, ref lexemSequence);
        }

        private void ProcessOperatorOrSpecialSymbol(
            ref List<KeyValuePair<string, int>> lexemSequence,
            ref Dictionary<string, int> operatorsList,
            ref Dictionary<string, int> specSymbolsList
            )
        {
            Buf = input[position].ToString();
            position++;
            
            // Если в списке операторов
            if (internalLexems.staticOperatorsTable.ContainsKey(Buf))
            {
                // Получаем тип, номер - записываем в lexemSequence
                var (type, number) = internalLexems.staticOperatorsTable[Buf];
                AddToList(ref operatorsList);
                AddToSequence(type, number, ref lexemSequence);
            }
            // Если в списке спец символов
            else if (internalLexems.staticSpecialSymbolsTable.ContainsKey(Buf))
            {
                // Получаем тип, номер - записываем в lexemSequence
                var (type, number) = internalLexems.staticSpecialSymbolsTable[Buf];
                AddToList(ref specSymbolsList);
                AddToSequence(type, number, ref lexemSequence);
            }
        }

        private void Pbuf(char c)
        {
            // Запись лексемы в буфер посимвольно
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
