using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace sortingapp
{
    public class Program
    {
        private static string helloClass = "Hello, Class!"; 
        public static void DoStuff()
        {
            Console.WriteLine("A message from DoStuff: " + Program.helloClass);
        }

        public static int[] BubbleSort(int[] array)
        {
            /*
            Function Call
            		int[] array = {21, 32, 9, 4, 10, 11}; 
                    array = BubbleSort(array); 
                    foreach(var item in array)
                    {
                        Console.WriteLine(item.ToString());
                    }
             */
             int n = array.Length;
                    array = BubbleSort(array); 
                    foreach(var item in array)
                    {
                        Console.WriteLine(item.ToString());
                    }
             do {
                 int newn = 0;
                 for (int i = 1; i<=n-1; i++)
                 {
                     if (array[i-1] > array[i])
                     {
                        //POST swap instruction from here to web app?
                        int c = 0; 
            			c = array[i-1]; 
            			array[i-1] = array[i]; 
           				array[i] = c; 
                        newn=i; 
                     }
                 }
                 n = newn; 
             } while (n>=1);
			
			return array; 
        }

        public static int[] QuickSort(int[] array, int lo, int hi)
        {
            int p = 0; 
            if (lo<hi)
            {
                p = Partition(array, lo, hi);
                QuickSort(array, lo, p-1);
                QuickSort(array, p+1, hi); 
            }
            return array;
        }
        
        public static int Partition(int[] array, int lo, int hi)
        {
            int pivot = array[hi];
            int i = lo - 1; 
            int temp = 0; 
            for (int j = lo; j < hi; j++)
            {
                if (array[j] <= pivot)
                {
                    if (i != j)
                    { 
                        i++;
                        temp = array[i];
                        array[i] = array[j]; 
                        array[j] = temp; 
                    }		
                }
            }
            temp = array[i + 1];
            array[i+1] = array[hi]; 
            array[hi] = temp; 
            return i+1;
        }

        public static void BucketSort(ref int[] data)
        {
            int minValue = data[0];
            int maxValue = data[0];

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < data.Length; i++)
            {
                bucket[data[i] - minValue].Add(data[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data[k] = bucket[i][j];
                        k++;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
