using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace GenericBoxOfString
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        private T _data;
        private List<T> _list;
        private static T _element;
        public Box(T data)
        {
            _data = data;
        }

        public Box(List<T> list, T element)
        {
            _list = list;
            _element = element;
        }

        public override string ToString()
        {
            return $"{_data.GetType()}: {_data}";
        }

        public static int GetValuesGreaterThan<U>(List<U> inputList, U element) where U : IComparable<U>
        {
            return inputList.Count(item => item.CompareTo(element) > 0);
        }

        public int CompareTo(T other) => _element.CompareTo(other);
       
    }
}
