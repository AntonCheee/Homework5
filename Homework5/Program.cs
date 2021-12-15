using System;

namespace Homework5
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();

            int size1 = GenerateNumber(6, 6, random);
            int size2 = GenerateNumber(4, 6, random);

            int[,] array = new int[size1, size1];

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

            int[,] result = ReflectElementsRelativeToDiagonal(array);

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

        private static int FindMinElement(int[,] array)
        {
            (int i, int j) = FindIndexMinElement(array);

            return array[i, j];
        }

        private static int FindMaxElement(int[,] array)
        {
            (int i, int j) = FindIndexMaxElement(array);

            return array[i, j];
        }

        private static (int, int) FindIndexMinElement(int[,] array)
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

        private static (int, int) FindIndexMaxElement(int[,] array)
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

        private static int FindElementMoreThanAllNeighbor(int[,] array)
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

        private static int[,] ReflectElementsRelativeToDiagonal(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i + 1; j < array.GetLength(1); j++)
                {
                    Swap(ref array[i, j], ref array[j, i]);
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