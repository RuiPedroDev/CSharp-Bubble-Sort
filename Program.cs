using System;
using System.Diagnostics;

namespace Program
{
    static class SortProgram
    {
        static int WritesToArray = 0;
        static int Swaps = 0;
        static Stopwatch stopWatch = new Stopwatch();
        static void Main(String[] args)
        {
            //Random rnd = new Random();
            Console.Title = "Bubble Sort";
            while (true)
            {
                Console.Write("Unsorted array: ");
                string str = Console.ReadLine();
                if (str == string.Empty)
                {
                    Console.WriteLine("Error, please enter some values separated by \',\'");
                    continue;
                }
                for (int i = 0; i < str.Split(',').Length; i++)
                {
                    if (str.Split(',')[i].Length > 9)
                    {
                        Console.WriteLine("Error, one of the values you entered is too large");
                        continue;
                    }
                }
                int[] input = new int[str.Split(',').Length];
                //int[] input = new int[16000];

                for (int i = 0; i < input.Length; i++)
                {
                    try
                    {
                        input[i] = Int32.Parse(str.Split(',')[i]);
                    }
                    catch
                    {
                        continue;
                    }
                }
                /*for(int i = 0; i < input.Length ;i++){
                    input[i] = rnd.Next();
                }*/
                Console.Write("Sorted array:   ");
                int[] sortedInput = BubbleSort(input);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(sortedInput[i]);
                    if (i < input.Length - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine($"\nNumber of writes to the array: {WritesToArray}");
                Console.WriteLine($"Swaps: {Swaps}");
                Console.WriteLine($"Time elapsed: {stopWatch.Elapsed}\n\n");
                WritesToArray = 0;
                stopWatch.Reset();
            }
        }
        static int[] BubbleSort(int[] arr)
        {
            stopWatch.Start();
            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        arr = Swap(arr, i);
                        WritesToArray++;
                    }
                }
            }
            stopWatch.Stop();
            return arr;
        }
        static int[] Swap(int[] arr, int loc1)
        {
            Swaps++;
            int loc2 = loc1 + 1;
            int temp = arr[loc1];
            arr[loc1] = arr[loc2];
            arr[loc2] = temp;
            WritesToArray += 2;
            return arr;
        }
    }
}