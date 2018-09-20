using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Katas.Calculator
{
    public static class StringCalculator
    {
        /// <summary>
        ///     This regular expression help to identify numeric characters.
        /// </summary>
        static readonly Regex _regexNumber = new Regex("[^0-9. ,;]");

        /// <summary>
        ///     This regular expression help to identify arithmetic delimeters.
        /// </summary>
        static readonly Regex _regexOperator = new Regex("[^\\/\\-*xX÷+]");

        /// <summary>
        ///     This Dictionary help to identify the arithmetic operations to be performed.
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
        ///     This struct defines all of the operations that can be done.
        ///     These operations can be assigned to delimeters to the StringCalculator.
        /// </summary>
        struct Calculator
        {
            public static double Sum(double firstNumber, double secondNumber) => firstNumber + secondNumber;

            public static double Subtract(double firstNumber, double secondNumber) => firstNumber - secondNumber;
            public static double Multiply(double firstNumber, double secondNumber) => firstNumber * secondNumber;

            public static Double Divide(Double firstNumber, Double secondNumber) => firstNumber / secondNumber;
        }

        /// <summary>
        ///     This method serve to convert string numeration where the first
        ///     character must be the arithmetic delimeter and later the numbers
        ///     separated by one of this characters: comma, semicolon and space. 
        /// </summary>
        /// <param name="numbers">
        ///     The string number to calculate character must be the arithmetic 
        ///     delimeter and later the numbers separated by one of this 
        ///     characters: comma, semicolon and space.
        /// </param>
        /// <returns>
        ///     String calculated as number.
        /// </returns>
        public static string NumbersCalculator(string numbers)
        {
            string numberToCalculate;
            string delimeterToUse;

            /// <summary>
            ///     Using as default message calculated number resulto too.
            /// </summary>
            string calculatedNumber = "Must enter a number or the entered charaters are not numbers";

            /// <summary>
            ///     Separator characters.
            /// </summary>
            char[] delimiter = { ',', ';', ' ' };
            List<string> numbersList = new List<string>();

            /// <summary>
            ///     Verifying if is empty.
            /// </summary>
            if (string.IsNullOrEmpty(numbers))
            {
                return calculatedNumber;
            }

            /// <summary>
            ///     Clearing from any other character is not defined
            ///     in the regular expression to find numeric characters.
            /// </summary>
            numberToCalculate = _regexNumber.Replace(numbers, "");

            /// <summary>
            ///     clearing from any character that is not a arithmetic delimeter
            ///     and assigning the default delimeter if it is empty sum.
            /// </summary>
            delimeterToUse = _regexOperator.Replace(numbers, "") == "" ? "+" : _regexOperator.Replace(numbers, "").ToLower();

            /// <summary>
            ///     Spliting the number to a list.
            /// </summary>
            numbersList = numberToCalculate.Split(delimiter).ToList();
            numbersList.Remove("");

            /// <summary>
            ///     Finding the delimeter to call the method CalculateOperations
            /// </summary>
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
        ///     This method serve to convert string numeration where the first
        ///     character must be the arithmetic delimeter and later the numbers
        ///     separated by one of this characters: comma, semicolon and space. 
        /// </summary>
        /// <param name="numbers">
        ///     The string array numbers going to be calculated. 
        /// </param>
        /// <param name="operatorMath">
        ///     The arithmetic operator
        /// </param>
        /// <returns>
        ///     returning the calculated operation math string.
        /// </returns>
        static string CalculateOperations(string[] numbers, string operatorMath)
        {            
            string numbersOperation = "";
            string numberResult = "";
            Calculator calculator;
            double numberChanged = 0.00;
            double numberSplitted = 0.00;

            /// <summary>
            ///     navigating number to determina
            /// </summary> 
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
