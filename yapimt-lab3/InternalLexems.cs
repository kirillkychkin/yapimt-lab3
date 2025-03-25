﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapimt_lab3
{
    public static class internalLexems
    {
        public static Dictionary<string, (string type, int number)> staticKeywordsTable = new Dictionary<string, (string, int)>
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
        public static Dictionary<string, (string type, int number)> staticOperatorsTable = new Dictionary<string, (string, int)>
        {
            {"+", ("operator", 1)},
            {"-", ("operator", 2)},
            {"*", ("operator", 3)},
            {"/", ("operator", 4)},
            {"==", ("operator", 5)},
            {"!=", ("operator", 6)},

        };
        public static Dictionary<string, (string type, int number)> staticSpecialSymbolsTable = new Dictionary<string, (string, int)>
        {
            {";", ("special", 1)},
            {",", ("special", 2)},
            {"(", ("special", 3)},
            {")", ("special", 4)},
            {"{", ("special", 5)},
            {"}", ("special", 6)},

        };
    }
}
