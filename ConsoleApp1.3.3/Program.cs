using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main()
    {

        int size = GetPositiveInteger("Введите размер квадратной матрицы: ");

        int[,] matrix = GenerateMatrix(size, -50, 50);

        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix);

        int[] rowSums = CalculateRowSums(matrix);
        Console.WriteLine("\nСуммы строк исходной матрицы:");
        PrintRowSums(rowSums);

        int[,] sortedMatrix = SortMatrixByRowSums(matrix);

        Console.WriteLine("\nОтсортированная матрица:");
        PrintMatrix(sortedMatrix);

        int[] sortedRowSums = CalculateRowSums(sortedMatrix);
        Console.WriteLine("\nСуммы строк отсортированной матрицы:");
        PrintRowSums(sortedRowSums);

        PrintStatistics(matrix, sortedMatrix);
    }

    static int[,] GenerateMatrix(int size, int minValue, int maxValue)
    {
        Random random = new Random();
        int[,] matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }

        return matrix;
    }

    static int[] CalculateRowSums(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[] sums = new int[size];

        for (int i = 0; i < size; i++)
        {
            int sum = 0;
            for (int j = 0; j < size; j++)
            {
                sum += matrix[i, j];
            }
            sums[i] = sum;
        }

        return sums;
    }

    static int[,] SortMatrixByRowSums(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[,] sortedMatrix = new int[size, size];
        int[] rowSums = CalculateRowSums(matrix);

        int[] indices = new int[size];
        for (int i = 0; i < size; i++)
        {
            indices[i] = i;
        }

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = 0; j < size - i - 1; j++)
            {
                if (rowSums[indices[j]] > rowSums[indices[j + 1]])
                {
                    int temp = indices[j];
                    indices[j] = indices[j + 1];
                    indices[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            int originalRow = indices[i];
            for (int j = 0; j < size; j++)
            {
                sortedMatrix[i, j] = matrix[originalRow, j];
            }
        }

        return sortedMatrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
    }

    static void PrintRowSums(int[] rowSums)
    {
        for (int i = 0; i < rowSums.Length; i++)
        {
            Console.WriteLine($"Строка {i}: {rowSums[i],6}");
        }
    }
    static void PrintStatistics(int[,] originalMatrix, int[,] sortedMatrix)
    {
        int size = originalMatrix.GetLength(0);
        int[] originalSums = CalculateRowSums(originalMatrix);
        int[] sortedSums = CalculateRowSums(sortedMatrix);

        int positiveSums = sortedSums.Count(sum => sum > 0);
        int negativeSums = sortedSums.Count(sum => sum < 0);
        int zeroSums = sortedSums.Count(sum => sum == 0);

    }

    static int GetPositiveInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                return number;
            Console.WriteLine("Ошибка: введите положительное целое число!");
        }
    }
}
