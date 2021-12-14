using System;

namespace Homework5
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();

            int size1 = GenerateNumber(4, 6, random);
            int size2 = GenerateNumber(4, 6, random);

            int[,] array = new int[size1, size2];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = GenerateNumber(1, 10, random);
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int[,] result = Task6(array);

            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size1; j++)
                {
                    Console.Write(result[i, j] + " ");
                }

                Console.WriteLine();
            }

            //int result2 = Task5(array);
            //Console.WriteLine(result2);

            //(int, int) result3 = Task4(array);
            //Console.WriteLine(result3);
        }

        private static int Task1(int[,] array)
        {
            int minElement = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (minElement > array[i, j])
                    {
                        minElement = array[i, j];
                    }
                }
            }

            return minElement;
        }

        private static int Task2(int[,] array)
        {
            int maxElement = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (maxElement < array[i, j])
                    {
                        maxElement = array[i, j];
                    }
                }
            }

            return maxElement;
        }

        private static (int, int) Task3(int[,] array)
        {
            (int, int) indexMaxElement = (0, 0);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[indexMaxElement.Item1, indexMaxElement.Item2] > array[i, j])
                    {
                        indexMaxElement = (i, j);
                    }
                }
            }

            return indexMaxElement;
        }

        private static (int, int) Task4(int[,] array)
        {
            (int, int) indexMinElement = (0, 0);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[indexMinElement.Item1, indexMinElement.Item2] < array[i, j])
                    {
                        indexMinElement = (i, j);
                    }

                }
            }

            return indexMinElement;
        }

        private static int Task5(int[,] array)
        {
            int count = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i > 0 && array[i, j] < array[i - 1, j])
                    {
                        continue;
                    }
                    if (i < array.GetLength(0) - 1 && array[i, j] < array[i + 1, j])
                    {
                        continue;
                    }
                    if (j > 0 && array[i, j] < array[i, j - 1])
                    {
                        continue;
                    }
                    if (j < array.GetLength(1) - 1 && array[i, j] < array[i, j + 1])
                    {
                        continue;
                    }

                    count++;
                }
            }

            return count;
        }

        private static int[,] Task6(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        Swap(ref array[i, j], ref array[j, i]);
                    }
                }
            }

            return array;
        }

        private static int GenerateNumber(int rangeStart, int rangeEnd, Random random)
        {
            return random.Next(rangeStart, rangeEnd);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}