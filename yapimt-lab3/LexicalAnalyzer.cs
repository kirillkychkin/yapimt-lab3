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
            {"int", ("keyword", 1)},
            {"float", ("keyword", 2)},
            {"if", ("keyword", 3)},
            {"else", ("keyword", 4)},
abstract
as
base
bool
break
byte
case
catch
char
checked
class
const
continue
decimal
default
delegate
do
double
else
enum
event
explicit
extern
false
finally
fixed
float
for
foreach
goto
if
implicit
in
int
interface
internal
is
lock
long
namespace
new
null
object
operator
out
override
params
private
protected
public
readonly
ref
return
sbyte
sealed
short
sizeof
stackalloc
static
string
struct
switch
this
throw
true
try
typeof
uint
ulong
unchecked
unsafe
ushort
using
virtual
void
volatile
while

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
