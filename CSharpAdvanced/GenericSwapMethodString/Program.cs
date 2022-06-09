using System;
using System.Collections.Generic;

namespace GenericSwapMethodString
{
    internal class Program
    {
        static void Main()
        {

        }

        public void GenericSwapMethod<T>(List<T> inputList, int index1, int index2)
        {
            T valueToSwap = inputList[index1];
            inputList[index1] = inputList[index2];
            inputList[index2] = valueToSwap;
        }
    }
}
