using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.Linq.Expressions;

namespace Katas.Wrap
{
    public static class Program
    {
        /// <summary>
        /// This Dictionary help to identify the roman number to be converted.
        /// </summary>
        static Dictionary<string, int> RomanMap = new Dictionary<string, int>()
        {
            {" ", 0 },
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };        

        public static void Main()
        {
            int choosenProgram = 1;
            int ColumText = 0;
            string textParam = "";

            while (choosenProgram == 1 || choosenProgram == 2 || choosenProgram == 3)
            {

                Console.WriteLine("Choose an option: \n 1: Word Wrap \n 2: Arabic number to Roman number Converter \n 3: String Calculator \n 0: to exit");
                int.TryParse(Console.ReadLine(), out choosenProgram);

                if (choosenProgram == 1)
                {

                    Console.WriteLine("Enter the string to wrap");
                    textParam = Console.ReadLine();

                    Console.WriteLine("Enter the number of the column to separate.");
                    int.TryParse(Console.ReadLine(), out ColumText);

                    Console.WriteLine(Wrapper.Wrap(textParam, ColumText));
                }
                else if (choosenProgram == 2)
                {
                    Console.WriteLine(RomanNumnber());
                }
                else if (choosenProgram == 3)
                {

                    Console.WriteLine("Enter Numbers");
                    textParam = Console.ReadLine();
                    //tesp();
                    Console.WriteLine(StringCalculator(textParam));
                    Console.WriteLine(WordWrap(textParam));
                }
                else if (choosenProgram == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid option");
                }
            }

        }

        public static string RomanNumnber()
        {
            string stringRomanNumber;
            int numberQuantity;

            Console.WriteLine("convert any quantity of Arabic number to convert");
            stringRomanNumber = Console.ReadLine();

            numberQuantity = RomanToInteger(stringRomanNumber);
            return "the result is: " + numberQuantity + "\n";
        }

        public static int RomanToInteger(string roman)
        {
            int presentNumber = 0;
            char previousCharToCompare = roman[0];
            string previousCharToCompareDictionary = previousCharToCompare.ToString().ToUpper();
            string presentChar;

            foreach (char currentChar in roman)
            {
                presentChar = currentChar.ToString().ToUpper();
                previousCharToCompareDictionary = previousCharToCompare.ToString().ToUpper();

                presentNumber += RomanMap[presentChar];
                if (RomanMap[previousCharToCompareDictionary] < RomanMap[presentChar])
                {
                    presentNumber -= RomanMap[previousCharToCompareDictionary] * 2;
                }
                previousCharToCompare = currentChar;
            }
            return presentNumber;
        }
    }
}
