using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sharp_9
{
    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }
    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    class Arr : IMath, ISort
    {
        private int[] _arr;
        public Arr()
        {
            _arr = null;
        }
        public Arr(int[] arr)
        {
            _arr = arr;
        }

        public int[] Array
        {
            get 
            { 
                return _arr; 
            }
            set
            {
                _arr = value;
            }
        }
        public void show()
        {
            Console.WriteLine('\n');
            foreach (var item in _arr)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine('\n');
        }
        public new int Max()
        {
            int max = int.MinValue;
            foreach (var item in _arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }
        public new int Min()
        {
            int min = int.MaxValue;
            foreach (var item in _arr)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }
        public new float Avg()
        {
            int sum = 0;
            int count = 0;
            foreach ( var item in _arr)
            {
                sum += item;
                count++;
            }
            return (float)sum/count;
        }
        public new bool Search(int valueToSearch)
        {
            foreach ( var item in _arr)
            {
                if (item == valueToSearch)
                {
                    return true;
                }
            }
            return false;
        }
        public new void SortAsc()
        {
            int temp = 0;
            for (int i = 0; i < _arr.GetLength(0) - 1; i++)
            {
                for (int y = 0; y < _arr.GetLength(0) - i - 1; y++)
                {
                    if (_arr[y] > _arr[y + 1])
                    {
                        temp = _arr[y];
                        _arr[y] = _arr[y + 1];
                        _arr[y + 1] = temp;
                    }
                }
            }
        }
        public new void SortDesc()
        {
            int temp = 0;
            for (int i = 0; i < _arr.GetLength(0) - 1; i++)
            {
                for (int y = 0; y < _arr.GetLength(0) - i - 1; y++)
                {
                    if (_arr[y] < _arr[y + 1])
                    {
                        temp = _arr[y];
                        _arr[y] = _arr[y + 1];
                        _arr[y + 1] = temp;
                    }
                }
            }
        }
        public new void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            int[] forTest = new int[size];
            for (int i = 0; i < size; i++)
            {
                forTest[i] = i;
            }
            Arr Test = new Arr(forTest);
            Test.show();
            Console.WriteLine("Max: " + Test.Max());
            Console.WriteLine("Min: " + Test.Min());
            Console.WriteLine("Avg: " + Test.Avg());
            Console.WriteLine("Search 1 res: " + Test.Search(1));
            Console.WriteLine("Search -1 res: " + Test.Search(-1));
            Test.SortByParam(false);
            Test.show();
            Test.SortByParam(true);
            Test.show();
        }
    }
}
