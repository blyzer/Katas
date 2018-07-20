using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Katas.StringCalculator
{
    public static class StrCalculator
    {
        /// <summary>
        ///  This regular expression help to identify numeric characters.
        /// </summary>
        static readonly Regex _regexNumber = new Regex("[^0-9. ,;]");

        /// <summary>
        ///  This regular expression help to identify arithmetic delimeters.
        /// </summary>
        static readonly Regex _regexOperator = new Regex("[^\\/\\-*xX÷+]");

        /// <summary>
        /// This Dictionary help to identify the arithmetic operations to be performed.
        /// </summary>
        static readonly Dictionary<string, string> operatorArithmetic = new Dictionary<string, string>()
        {
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
            char[] delimiter = { ',', ';', ' ' };
            List<string> numbersList = new List<string>();

            /// Verifying if is empty.
            if (string.IsNullOrEmpty(numbers))
            {
                return calculatedNumber;
            }

            /// Clearing from any other character is not defined 
            /// in the regular expression to find numeric characters.
            numberToCalculate = _regexNumber.Replace(numbers, "");

            /// clearing from any character that is not a arithmetic delimeter
            /// and assigning the default delimeter if it is empty sum.
            delimeterToUse = _regexOperator.Replace(numbers, "") == "" ? "+" : _regexOperator.Replace(numbers, "").ToLower();

            /// Spliting the number to a list.
            numbersList = numberToCalculate.Split(delimiter).ToList();
            numbersList.Remove("");

            /// Finding the delimeter to call the method CalculateOperations
            foreach (KeyValuePair<string, string> pair in operatorArithmetic)
            {
                if (pair.Key == delimeterToUse[0].ToString())
                {
                    calculatedNumber = CalculateOperations(numbersList.ToArray(), pair.Value);
                    break;
                }
            }

            return calculatedNumber;
        }

        /// <summary>
        ///  This method serve to convert string numeration where the first
        ///  character must be the arithmetic delimeter and later the numbers
        ///  separated by one of this characters: comma, semicolon and space. 
        /// </summary>
        /// <param name="numbers">The string array numbers going to be calculated. </param>
        /// <param name="operatorMath">The arithmetic operator</param>
        static string CalculateOperations(string[] numbers, string operatorMath)
        {            
            string numbersOperation = "";
            string numberResult = "";
            Calculator calculator;
            double numberChanged = 0.00;
            double numberSplitted = 0.00;

            /// navigating number to determina
            foreach (string splittedNumbers in numbers)
            {
                numberChanged = double.Parse(splittedNumbers);
                numbersOperation += " " + operatorMath + " " + splittedNumbers;

                if (operatorMath == "+")
                {
                    numberSplitted = calculator.Sum(numberSplitted, numberChanged);
                }
                else if (operatorMath == "-")
                {
                    numberSplitted = Math.Abs(numberSplitted) <= 0 ? numberChanged : calculator.Subtract(numberSplitted, numberChanged);
                }
                else if (operatorMath == "*")
                {
                    numberSplitted = Math.Abs(numberSplitted) <= 0 ? numberChanged : calculator.Multiply(numberSplitted, numberChanged);
                }
                else if (operatorMath == "/")
                {
                    numberSplitted = Math.Abs(numberSplitted) <= 0 ? numberChanged : calculator.Divide(numberSplitted, numberChanged);
                }

            }

            numberResult = numbersOperation.Remove(0, 3);

            return numberSplitted + " (" + numberResult + ")";
        }
    }
}
