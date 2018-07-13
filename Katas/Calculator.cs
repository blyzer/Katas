using System;

namespace Katas.various
{
    /// <summary>
    /// ICalculator<T> implementation
    /// </summary>
    internal struct Calculator : ICalculator<double>
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
}
