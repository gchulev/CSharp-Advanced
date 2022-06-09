using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T _data;
        public Box(T data)
        {
            _data = data;
        }

        public override string ToString()
        {
            return $"{_data.GetType()}: {_data}";
        }
    }
}
