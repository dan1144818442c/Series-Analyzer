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
            string Rremove_LastFirst_Sep(string str)
            {
                if (str[str.Length - 1] == ',')
                {
                    str = str.Substring(0, str.Length - 1);

                }
                if (str[0] == ',')
                {
                    str = str.Substring(1);
                }
                return str;
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
                    Console.WriteLine("Please enter a list of (positive) numbers of at least three numbers (the rest are separated by commas)");
                    string string_input = Console.ReadLine();

                    string_input = Rremove_LastFirst_Sep(string_input);

                    list_input = string_input.Split(',');
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

       

            void ShowReversed(string[] list)
            {
                string[] revers = new string[list.Length];
                int index_list = list.Length - 1;
                foreach (string item in list)
                {
                    revers[index_list] = item;
                    index_list--;
                }
                printList(revers);
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
                printList(sort_arr);
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

            double GetAverage(int[] arr)
            {
                int sum = GetSum(arr);
                return ((double)sum / arr.Length);

            }

            int GetLength(int[] arr)
            {
                int counter = 0;
                foreach (int item in arr)
                {
                    counter++;
                }
                return counter;
            }

            void printList<T>(IEnumerable<T> arry)
            {
                foreach (var item in arry)
                {
                    Console.Write(item + " ");
                }
            }


            void menu()
            {
                (string[] arry, bool succses) = TryGetSeriesFromArgs();

                if (!succses)
                {
                    arry = GetSeriesFromUser();
                }
                string choice1 = " ";
                while (choice1 != "exit")
                {
                    ShowMenu();
                    choice1 = GetUserChoice();
                    int[] int_arry = From_string_to_int(arry);
                    switch (choice1)
                    {
                        case "a":
                            arry = GetSeriesFromUser();
                            break;

                        case "b":
                            printList(arry);
                            break;
                        case "c":
                            ShowReversed(arry);
                            break;
                        case "d":
                            ShowSorted(arry);
                            break;

                        case "e":
                            Console.WriteLine(GetMax(int_arry));
                            break;
                        case "f":
                            Console.WriteLine(GetMin(int_arry));
                            break;
                        case "g":
                            Console.WriteLine(GetAverage(int_arry));
                            break;
                        case "h":
                            Console.WriteLine(GetLength(int_arry));
                            break;
                        case "i":
                            Console.WriteLine(GetSum(int_arry));
                            break;
                        case "j":
                            choice1 = "exit";
                            break;
                    }




                }
            }


            menu();
        }
    }
}
