using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using Katas.ArabicToRoman;
using Katas.StringCalculator;

namespace Katas.Wrap
{
    public static class Program
    {


        public static void Main()
        {
            int choosenProgram = 1;
            int ColumText = 0;
            string textParam = "";

            while (choosenProgram != 0)
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
                    Console.WriteLine("enter");
                    int.TryParse(Console.ReadLine(), out ColumText);
                    Console.WriteLine(ArabicNumeralsToRomanNumerals.Of(ColumText));
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
    }
}
