using System;
using System.Collections.Generic;
using System.Text;

namespace Katas.various
{
    /// <summary>
    /// This interface defines all of the operations that can be done in generic classes
    /// These operations can be assigned to operators in class Number<T>
    /// </summary>
    /// <typeparam name="T">Type that we will be doing arithmetic with</typeparam>
    public interface ICalculator<T>
    {
        T Sum(T firstNumber, T secondNumber);
        T Subtract(T firstNumber, T secondNumber);
        T Multiply(T firstNumber, T secondNumber);
        T Divide(T firstNumber, T secondNumber);
    }
}
