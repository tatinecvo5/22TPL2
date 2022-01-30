using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintArray);
            Task task2 = task1.ContinueWith(action);



            Action<Task<int[]>> action1 = new Action<Task<int[]>>(SummaArray);
            Task task3 = task1.ContinueWith(action1);

            //Task task2 = task1.ContinueWith<int[]>(func1);

            Action<Task<int[]>> action2 = new Action<Task<int[]>>(MaxArray);
            Task task4 = task1.ContinueWith(action2);

            //Task task5 = task1.ContinueWith<int[]>(func1);
            //task1.Start();
            //Console.ReadKey();



            task1.Start();
            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 10);
            }
            return array;
        }
        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Count(); i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        static void /*int[]*/ SummaArray(Task<int[]> task)
        {
            int[] array = task.Result;
            int summa = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                summa += array[i];
            }
            Console.WriteLine(summa);
            //return summa;
        }
        static void MaxArray(Task<int[]> task)
        {
            int[] array = task.Result;
            int max = array[0];
            foreach (int x in array)
            {
                if (x > max)
                    max = x;
            }
            Console.WriteLine(max);

        }
    }
}