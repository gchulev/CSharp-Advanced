using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //var boxesList = new List<Box<string>>();
            var inputList = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                inputList.Add(input);
                //var box = new Box<string>(input);
                //boxesList.Add(box);
            }
            //int[] indices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //int index1 = indices[0];
            //int index2 = indices[1];

            //GenericSwapMethod(boxesList, index1, index2);
            //Console.WriteLine(String.Join(Environment.NewLine, boxesList));
            double element = double.Parse(Console.ReadLine());
            int greaterElementsCount = Box<double>.GetValuesGreaterThan(inputList, element);
            Console.WriteLine(greaterElementsCount);

        }

        public static void GenericSwapMethod<T>(List<T> inputList, int index1, int index2)
        {
            T valueToSwap = inputList[index1];
            inputList[index1] = inputList[index2];
            inputList[index2] = valueToSwap;
        }
    }
}
