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

        /// <summary>
        /// This Dictionary help to identify the arithmetic operations to be performed.
        /// </summary>
        static readonly Dictionary<string, string> delimeters = new Dictionary<string, string>()
        {
            { "", "+" },
            { " ", "+" },
            { "+", "+" },
            { "-", "-"},
            { "*", "*"},
            { "x", "*"},
            { "/", "/"},
            { "÷", "/"}
        };

        /// <summary>
        /// This struct defines all of the operations that can be done.
        /// These operations can be assigned to delimeters to the StringCalculator.
        /// </summary>
        struct Calculator
        {
            public double Sum(double firstNumber, double secondNumber)
            {
                return firstNumber + secondNumber;
            }

            public double Subtract(double firstNumber, double secondNumber)
            {
                return firstNumber - secondNumber;
            }
            public double Multiply(double firstNumber, double secondNumber)
            {
                return firstNumber * secondNumber;
            }

            public Double Divide(Double firstNumber, Double secondNumber)
            {
                return firstNumber / secondNumber;
            }
        }

        /// <summary>
        ///  This regular expression help to identify numeric characters.
        /// </summary>
        static readonly Regex _regexNumber = new Regex("[^0-9. ,;]");

        /// <summary>
        ///  This regular expression help to identify arithmetic delimeters.
        /// </summary>
        static readonly Regex _regexDelimeter = new Regex("[^\\/\\-*+]");

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

        public static string WordWrap(string unWrappedText)
        {
            string stringReturned = "";
            List<string> wrappedWords = new List<string>();
            wrappedWords = Regex.Matches(unWrappedText, "([a-zA-Z0-9]*\\S)").Cast<Match>().Select(m => m.Value).ToList();
            wrappedWords.ToString().Replace(" ", "");
            
            foreach (var item in wrappedWords)
            {
                stringReturned += item;
            }

            return stringReturned;
        }

        /// <summary>
        ///  This method serve to convert string numeration where the first
        ///  character must be the arithmetic delimeter and later the numbers
        ///  separated by one of this characters: comma, semicolon and space. 
        /// </summary>
        /// <param name="numbers">
        /// The string number to calculate character must be the arithmetic 
        /// delimeter and later the numbers separated by one of this 
        /// characters: comma, semicolon and space.
        /// </param>
        public static string StringCalculator(string numbers)
        {
            string numberToCalculate;
            string delimeterToUse;

            /// Using as default message calculated number resulto too.
            string calculatedNumber = "Must enter a number or the entered charaters are not numbers";

            /// Separator characters.
            char[] separators = { ',', ';', ' ' };
            List<string> numbersList = new List<string>();

            /// Verifying if is empty.
            if (string.IsNullOrEmpty(numbers))
            {
                return calculatedNumber;
            }

            /// Clearing from any other character is not defined 
            /// in the regular expression to find numeric characters.
            numberToCalculate = _regexNumber.Replace(numbers, "");

            /// clearing from any character that is not a arithmetic delimeter.
            delimeterToUse = _regexDelimeter.Replace(numbers, "");

            /// Assigning the default delimeter if it is empty sum.
            if (delimeterToUse == "")
            {
                delimeterToUse = "+";
            }

            /// Spliting the number to a list.
            numbersList = numberToCalculate.Split(separators).ToList();
            numbersList.Remove("");

            /// Finding the delimeter to call the method CalculateOperations
            foreach (KeyValuePair<string, string> pair in delimeters)
            {
                if (pair.Key == delimeterToUse[0].ToString())
                {
                    calculatedNumber = CalculateOperations(numbersList.ToArray(), pair.Value);
                    break;
                }
            }

            return calculatedNumber + "\n";
        }

        /// <summary>
        ///  This method serve to convert string numeration where the first
        ///  character must be the arithmetic delimeter and later the numbers
        ///  separated by one of this characters: comma, semicolon and space. 
        /// </summary>
        /// <param name="numbers">The string array numbers going to be calculated. </param>
        /// <param name="Delimeter">The arithmetic delimeter</param>
        static string CalculateOperations(string[] numbers, string Delimeter)
        {
            string numbersOperation = "";
            string numberResult = "";
            Calculator calculator;
            double valueConverted = 0.00;
            double numberSplitted = 0.00;

            foreach (string splittedNumbers in numbers)
            {
                valueConverted = double.Parse(splittedNumbers);
                numbersOperation += " " + Delimeter + " " + splittedNumbers;
                
                if (Delimeter == "+")
                {
                    numberSplitted = calculator.Sum(numberSplitted, valueConverted);
                }
                else if (Delimeter == "-")
                {
                    numberSplitted = calculator.Subtract(numberSplitted, valueConverted);
                }
                else if (Delimeter == "*")
                {
                    numberSplitted = calculator.Multiply(numberSplitted, valueConverted);
                }
                else if (Delimeter == "/")
                {
                    numberSplitted = calculator.Divide(numberSplitted, valueConverted);
                }

            }            

            numberResult = numbersOperation.Remove(0, 3);

            return numberSplitted + " (" + numberResult + ")";
        }
    }
}
