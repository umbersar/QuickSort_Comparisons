using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quicksortincsharp
{
    class Program
    {
        static void Main(String[] args)
        {
            //var sampleNumbers = genRandomNums(70000000);
            var sampleNumbers = new List<int>() {2,1,3,0,7,4 };
            Console.WriteLine(String.Join(", ", sampleNumbers));

            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            quickSortInPlace(sampleNumbers.ToArray());
            stopWatch.Stop();


            Console.WriteLine(String.Join(", ", sampleNumbers));

            Console.WriteLine("time taken {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("time taken {0} minutes\n", stopWatch.Elapsed.TotalMinutes);
        }

        static List<int> genRandomNums(int count)
        {
            var rnd = new System.Random();
            IEnumerable<int> enumerable = Enumerable.Range(0, count)
                .Select(i => new Tuple<int, int>(rnd.Next(int.MaxValue), i))
                                     //.OrderBy(i => i.Item1)
                                     .Select(i => i.Item1);
            return enumerable.ToList();
        }

        public static void quickSortInPlace(int[] a)
        {
            quickSortInPlace(a, 0, a.Length - 1);

        }

        public static void quickSortInPlace(int[] a, int first, int last)
        {
            if ((last - first) >= 1)
            {
                int pivotposition = partition(a, first, last);
                print(a);
                quickSortInPlace(a, first, pivotposition - 1);
                quickSortInPlace(a, pivotposition + 1, last);
            }

        }

        public static int partition(int[] a, int first, int last)
        {
            int pivot = a[last];
            int wallindex = first;
            for (int currentindex = first; currentindex < last; ++currentindex)
            {
                if (a[currentindex] < pivot)
                {
                    swap(a, wallindex, currentindex);
                    ++wallindex;
                }
            }
            swap(a, wallindex, last);
            return wallindex;

        }

        private static void print(int[] a)
        {
            //foreach (int element in a)
            //{
            //    print(element);
            //}
            //Console.WriteLine(" ");
        }

        public static void swap(int[] a, int indexA, int indexB)
        {
            int temp = a[indexA];
            a[indexA] = a[indexB];
            a[indexB] = temp;
        }
        private static void print(int element)
        {
            //Console.Write(Convert.ToString(element) + " ");
        }
    }

    //class Program
    //{
    //    static List<int> genRandomNums(int count)
    //    {
    //        var rnd = new System.Random();
    //        IEnumerable<int> enumerable = Enumerable.Range(0, count)
    //            .Select(i => new Tuple<int, int>(rnd.Next(int.MaxValue), i))
    //                                 //.OrderBy(i => i.Item1)
    //                                 .Select(i => i.Item1);
    //        return enumerable.ToList();
    //    }

    //    static List<T> QuickSort<T>(List<T> values, int depth)
    //       where T : IComparable
    //    {
    //        if (values.Count == 0)
    //        {
    //            return new List<T>();
    //        }


    //        #region in-efficient partitioning 
    //        //get the first element       
    //        T firstElement = values[0];

    //        //get the smaller and larger elements       
    //        var smallerElements = new List<T>();
    //        var largerElements = new List<T>();
    //        for (int i = 1; i < values.Count; i++)  // i starts at 1       
    //        {                                       // not 0!          
    //            var elem = values[i];
    //            if (elem.CompareTo(firstElement) < 0)
    //            {
    //                smallerElements.Add(elem);
    //            }
    //            else
    //            {
    //                largerElements.Add(elem);
    //            }
    //        }
    //        #endregion

    //        #region in-place efficient partitioning
    //        //todo:
    //        #endregion


    //        //return the result       
    //        var result = new List<T>();
    //        if (depth < 0)
    //        {
    //            List<T> smallList = QuickSort(smallerElements.ToList(), depth);
    //            result.AddRange(smallList);
    //            result.Add(firstElement);
    //            List<T> bigList = QuickSort(largerElements.ToList(), depth);
    //            result.AddRange(bigList);
    //            return result;
    //        }
    //        else
    //        {
    //            Task<List<T>> smallTask = Task.Run(() => { return QuickSort(smallerElements.ToList(), depth - 1); });
    //            Task<List<T>> bigTask = Task.Run(() => { return QuickSort(largerElements.ToList(), depth - 1); });


    //            List<Task<List<T>>> tasks = new List<Task<List<T>>>();
    //            tasks.Add(smallTask);
    //            tasks.Add(bigTask);
    //            Task.WaitAll(tasks.ToArray());

    //            List<T> smallList = smallTask.Result;
    //            result.AddRange(smallList);

    //            result.Add(firstElement);

    //            List<T> bigList = bigTask.Result;
    //            result.AddRange(bigList);
    //            return result;
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        var sampleNumbers = genRandomNums(50000000);
    //        //Console.WriteLine(String.Join(", ", sampleNumbers));

    //        int depth = 4;
    //        var stopWatch = System.Diagnostics.Stopwatch.StartNew();
    //        List<int> sortedList = QuickSort<int>(sampleNumbers, depth);
    //        stopWatch.Stop();


    //        //Console.WriteLine(String.Join(", ", sortedList));

    //        Console.WriteLine("time taken {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
    //        Console.WriteLine("time taken {0} minutes\n", stopWatch.Elapsed.TotalMinutes);
    //    }
    //}
}
