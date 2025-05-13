using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _12_5_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string[], bool) chek_list(string[] list)
            {
                if (list.Length >= 3)
                {
                    foreach (var arg in list)
                    {
                        if ((!chekStringIfDigit(arg)))
                        {
                            return (list, false);

                        }
                        if (!chekStringNumIfPos(arg))
                        {
                            return (list, false);
                        }
                    }
                    return (list, true);

                }
                return (list, false);


            }

            bool chekStringIfDigit(string word)
            {
                foreach (char ch in word)
                {
                    if (!(char.IsDigit(ch)))
                    {
                        return false;
                    }
                }
                return true;

            }
            bool chekStringNumIfPos(string word)
            {
                if (int.Parse(word) < 0)
                {
                    return false;
                }
                return true;
            }

            (string[], bool) TryGetSeriesFromArgs()
            {
                (string[] list, bool good_list) = chek_list(args);
                return (list, good_list);

            }

            string[] GetSeriesFromUser()
            {
                bool is_good_list = false;
                string[] list_input;
                do
                {
                    Console.WriteLine("Please enter a list");
                    list_input = Console.ReadLine().Split(',');
                    (string[] list, bool good_list) = chek_list(list_input);
                    is_good_list = good_list;
                }
                while (!is_good_list);

                return (list_input);
            }

            void ShowMenu()
            {
                Console.WriteLine(@"
                a. Input a Series. (Replace the current series)
                b. Display the series in the order it was entered.
                c. Display the series in the reversed order it was
                entered.
                d. Display the series in sorted order (from low to
                high).
                e. Display the Max value of the series.
                f. Display the Min value of the series.
                g. Display the Average of the series.
                h. Display the Number of elements in the series.
                i. Display the Sum of the series.
                j. Exit.");
            }


            string GetUserChoice()
            {
                while (true)
                {
                    {
                        string choice = Console.ReadLine();
                        if ((choice == "a") || (choice == "b") || (choice == "c") || (choice == "d") || (choice == "e") || (choice == "f") || (choice == "g") || (choice == "h") || (choice == "i") || (choice == "j"))
                        {
                            return choice;
                        }
                        Console.WriteLine("Must choose one of the following options");
                        ShowMenu();
                    }

                }

            }

            void ShowSeries(string[] list)
            {
                foreach (string item in list)
                {
                    Console.Write(item + " , ");
                }
            }

            void ShowReversed(string[] list)
            {
                string[] revers = new string[list.Length];
                int index_list = list.Length - 1;
                foreach (string item in list)
                {
                    revers[index_list] = item;
                    index_list--;
                }
                foreach (string item in revers)
                {
                    Console.WriteLine(item);
                }
            }

            int[] From_string_to_int(string[] arr)
            {
                int[] int_list = new int[arr.Length];
                int index = 0;
                foreach (string item in arr)
                {
                    int_list[index] = int.Parse(item);
                    index++;
                }
                return int_list;
            }

            int[] bubbleSort(string[] arr)
            {
                int[] int_list = From_string_to_int(arr);
                int length = int_list.Length;
                bool flag = false;
                for (int i = 0; i < length - 1; i++)
                {
                    flag = true;
                    for (int j = 0; j < length - i - 1; j++)
                    {
                        if (int_list[j] > int_list[j + 1])
                        {
                            int temp = int_list[j + 1];
                            int_list[j + 1] = int_list[j];
                            int_list[j] = temp;
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        return int_list;
                    }
                }
                return int_list;
            }

            void ShowSorted(string[] arr)
            {
                int[] sort_arr = bubbleSort(arr);
                foreach (var item in sort_arr)
                {
                    Console.Write(item + " , ");
                }
            }


            int GetMax(int[] arr)
            {
                int max = 0;
                foreach (int item in arr)
                {
                    if (item > max)
                    {
                        max = item;

                    }
                }
                return max;

            }
            int GetMin(int[] arr)
            {
                int min = arr[0];
                foreach (int item in arr)
                {
                    if (item < min)
                    {
                        min = item;
                    }

                }
                return min;

            }

            int GetSum(int[] arr)
            {
                int sum = 0;
                foreach (int item in arr)
                {
                    sum += item;
                }
                return sum;
            }

            int GetAverage(int[] arr)
            {
                int sum = GetSum(arr);
                return sum / arr.Length;

            }

            int getLength(int[] arr)
            {
                return arr.Length;
            }













            (string[] arry, bool succses) = TryGetSeriesFromArgs();
            //Console.WriteLine(arry);
            //Console.WriteLine(typeof(arry));
            //Console.WriteLine(succses);
            if (!succses)
            {
                arry = GetSeriesFromUser();
            }
            ShowMenu();
            string choice1 = GetUserChoice();

            switch (choice1)
            {
                case "a":
                    arry = GetSeriesFromUser();
                    break;





            }

            }
        }
    }
