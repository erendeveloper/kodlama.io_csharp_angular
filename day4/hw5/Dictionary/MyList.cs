using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class MyList<T>
    {
        T[] _myList;
        public MyList()
        {
            _myList = new T[0];
        }

        public void Add(T item)
        {
            T[] _tempList = _myList;
            _myList = new T[_myList.Length+1];

            for(int i=0; i < _myList.Length-1; i++)
            {
                _myList[i] = _tempList[i];
            }
            _myList[_myList.Length - 1] = item;
        }

        public int Length()
        {
            return _myList.Length;
        }
    }
}
