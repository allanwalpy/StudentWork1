﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{

    public class Program
    {

        public delegate bool BooleanFunction(bool a, bool b, bool c);

        static void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            WriteLine("Program Lab Walpy");
            WriteLine("Task1");
            Task1.Run();
            WriteLine("Task2");
            Task2.Run();
            WriteLine("Task3");
            Task3.Run();
            Console.ReadLine();
        }

        static public class Task1
        {

            static public void Run()
            {
                PrintFunction(BoolFunction);
            }

            static bool BoolFunction(bool a, bool b, bool c)
            {
                return (((a == b) == c) || !a);
            }

            static void SetOfTwo(int number, ref bool a, ref bool b, ref bool c)
            {
                a = (number / 4) == 1;
                b = (number / 2 - (number / 4) * 2) == 1;
                c = (number % 2) == 1;
            }

            static void PrintFunction(BooleanFunction func)
            {
                bool a = false, b = false, c = false;
                WriteLine("   A      B      C      Result");
                for (int i = 0; i < 8; i++)
                {
                    SetOfTwo(i, ref a, ref b, ref c);
                    WriteLine(String.Format("{0,6} {1,6} {2,6} - {3,6}", a, b, c, func(a, b, c)));
                }
            }

        }

        static public class Task2
        {

            public static void Run()
            {
                for (int i = 100; i < 1000; i++)
                {
                    if (IsSatisfy(i))
                    {
                        WriteLine(String.Format(" {0} ", i));
                    }
                }
            }

            static bool IsSatisfy(int numb)
            {
                return (Math.Pow(numb / 10, 2) - (numb % 10)) == numb;
            }

        }

        static public class Task3
        {

            static int[] array1;

            static int[] array2;

            static public void Run()
            {
                WriteLine("Enter array1:");
                EnterArray(ref array1);
                WriteLine("Enter array2:");
                EnterArray(ref array2);
                Int64 numb1 = MakeNumber(array1);
                Int64 numb2 = MakeNumber(array2);
                WriteLine(String.Format("Summ of two numbers is {0}", numb1 + numb2));
            }

            static bool IsDigit(int numb)
            {
                return (numb <= 9) && (numb >= 0);
            }

            static int EnterNumb(string message)
            {
                int result = 0;
                do
                {
                    WriteLine(message);
                    result = Console.Read();
                } while (IsDigit(result));
                return result;
            }

            static void EnterArray(ref int[] array)
            {
                int size = EnterNumb("Enter size of array: ");
                array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = EnterNumb(String.Format("Enter {0} element: ", i));
                }
            }

            static Int64 MakeNumber(int[] array, int basis = 10)
            {
                Int64 result = 0;
                Int64 basicPow = 1;
                for (int i = 0; i < array.Length; i++, basicPow *= basis)
                {
                    result += array[i] * basicPow;
                }
                return result;
            }

            //Напишите программу, которая вводит 
            //c клавиатуры два непустых массива целых
            //чисел в диапазоне от 0 до 9 и, 
            //считая эти массивы десятичным представлением
            //двух чисел, печатает их сумму.
        }
    }
}