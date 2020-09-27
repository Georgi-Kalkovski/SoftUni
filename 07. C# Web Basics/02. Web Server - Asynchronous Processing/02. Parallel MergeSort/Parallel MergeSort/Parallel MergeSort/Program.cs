using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;

namespace Parallel_MergeSort
{
    class Program
    {
        public static object lockObj = new object();

        static async Task Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 10_000).OrderByDescending(x => x).ToList();
            var firstNumbers = numbers.Take(numbers.Count / 2).ToList();
            var secondNumbers = numbers.Skip(numbers.Count / 2).ToList();

            var result = new List<int>();
            await Task.Run(() =>
            {
                lock (lockObj)
                {
                    var left = MergeSort(secondNumbers);
                    result.AddRange(left);
                }
            });

            await Task.Run(() =>
            {
                lock (lockObj)
                {
                    var right = MergeSort(firstNumbers);
                    result.AddRange(right);
                }
            });

            File.WriteAllLines("../../../mergeSort.txt", result.Select(x => x.ToString()));
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
