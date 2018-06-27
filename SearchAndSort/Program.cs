using System;
using System.Diagnostics;

namespace SearchAndSort
{
    class MainClass
    {
        static Stopwatch _sw;
        public static void Main(string[] args)
        {
            _sw = new Stopwatch();
            BinarySearchProblem();
        }

        static void BinarySearchProblem() {
            var searchArray = new int[] { 1, 5, 6, 8, 12, 16, 25, 39, 48, 55, 64, 71, 98 };
            var search = 98;

            Debug.WriteLine($"Search :{search}");
            _sw.Start();
            var index = BinarySearch(searchArray, search);
            _sw.Stop();
            Debug.WriteLine($"BinarySearch took {_sw.Elapsed.TotalMilliseconds}");
            _sw.Reset();

            // Slower - Interesting.
            //_sw.Start();
            //index = Array.BinarySearch(searchArray, search);
            //_sw.Stop();
            //Debug.WriteLine($"Array.BinarySearch took {_sw.Elapsed.TotalMilliseconds}");
            //_sw.Reset();

            if (index > -1)
                Debug.WriteLine($"Found {searchArray[index]} at index {index}");
            else
                Debug.WriteLine("Not found.");
        }

        static int BinarySearch(int[] values, int val)
        {
            var first = 0;
            var last = values.Length - 1;
            var mid = 0;
            var found = false;

            while (first <= last)
            {
                mid = (first + last) / 2;

                if(values[mid] == val) {
                    found = true;
                    break;
                }

                if (val > values[mid]) {
                    first = mid + 1;
                } else if (val < values[mid]) {
                    last = mid - 1;
                }
            }

            return found ? mid : -1;
        }
    }
}
