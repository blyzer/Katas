﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.Linq.Expressions;

namespace Katas.various
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
        static readonly Dictionary<string, string> operators = new Dictionary<string, string>()
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
        /// These operations can be assigned to operators to the StringCalculator.
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
        ///  This regex help to identify numeric characters.
        /// </summary>
        static readonly Regex _regexNumber = new Regex("[^0-9. ,;]");

        /// <summary>
        ///  This regex help to identify arithmetic operators.
        /// </summary>
        static readonly Regex _regexOperator = new Regex("[^\\/\\-*+]");

        /// <summary>
        ///  this regex help to identify arithmetic operators.
        /// </summary>
        static readonly Regex _regexOperatorToEliminate = new Regex("[\\/\\-*+]");

        public static void Main()
        {
            int ChoosenProgram = 1;
            string param = "";

            while (ChoosenProgram == 1 || ChoosenProgram == 2 || ChoosenProgram == 3)
            {

                Console.WriteLine("Choose an option: \n 1: Word Wrap \n 2: Arabic number to Roman number Converter \n 3: String Calculator \n 0: to exit");
                int.TryParse(Console.ReadLine(), out ChoosenProgram);

                if (ChoosenProgram == 1)
                {

                    Console.WriteLine("Enter the string to wrap");
                    param = Console.ReadLine();

                    Console.WriteLine(WordWrap(param));
                }
                else if (ChoosenProgram == 2)
                {
                    Console.WriteLine(RomanNumnber());
                }
                else if (ChoosenProgram == 3)
                {

                    Console.WriteLine("Enter Numbers");
                    param = Console.ReadLine();
                    //tesp();
                    Console.WriteLine(StringCalculator(param));
                }
                else if (ChoosenProgram == 0)
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
        ///  character must be the arithmetic operator and later the numbers
        ///  separated by one of this characters: comma, semicolon and space. 
        /// </summary>
        /// <param name="numbers">
        /// The string number to calculate character must be the arithmetic 
        /// operator and later the numbers separated by one of this 
        /// characters: comma, semicolon and space.
        /// </param>
        public static string StringCalculator(string numbers)
        {
            string numberToCalculate;
            string operatorToUse;
            string calculatedNumber = "Must enter a number or the entered charaters are not numbers";
            char[] separators = { ',', ';', ' ' };
            string[] numbersStrArray;
            List<string> numbersList = new List<string>();

            if (string.IsNullOrEmpty(numbers))
            {
                return calculatedNumber;
            }

            numberToCalculate = _regexNumber.Replace(numbers, "");
            
            operatorToUse = _regexOperator.Replace(numbers, "");

            if (operatorToUse == "")
            {
                operatorToUse = "+";
            }

            numbersList = numberToCalculate.Split(separators).ToList();
            numbersList.Remove("");
            numbersStrArray = numbersList.ToArray();

            foreach (KeyValuePair<string, string> pair in operators)
            {
                if (pair.Key == operatorToUse[0].ToString())
                {
                    calculatedNumber = OperationsString(numbersStrArray, pair.Value);
                    break;
                }
            }

            return calculatedNumber + "\n";
        }
        
        static string OperationsString(string[] numbers, string Operator)
        {
            string numbersOperation = "";
            string numberResult = "";
            Calculator calculator;
            double valueConverted = 0.00;
            double numberSplitted = 1.00;

            foreach (string splittedNumbers in numbers)
            {
                valueConverted = double.Parse(splittedNumbers);
                numbersOperation += " " + Operator + " " + splittedNumbers;
                
                if (Operator == "+")
                {
                    numberSplitted = calculator.Sum(numberSplitted, valueConverted);
                }
                else if (Operator == "-")
                {
                    numberSplitted = calculator.Subtract(numberSplitted, valueConverted);
                }
                else if (Operator == "*")
                {
                    numberSplitted = calculator.Multiply(numberSplitted, valueConverted);
                }
                else if (Operator == "/")
                {
                    numberSplitted = calculator.Divide(numberSplitted, valueConverted);
                }

            }            

            numberResult = numbersOperation.Remove(0, 3);

            return numberSplitted + " (" + numberResult + ")";
        }
    }
}