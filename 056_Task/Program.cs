// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

int ReadNumber() // Метод проверки соответствия вводимого числа условиям задачи
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
        {
            return number;
        }
        else Console.WriteLine("Не удалось распознать требуемое число, попробуйте еще раз.");
    }
}

int[,] FillIntArray2D(int m, int n, int min, int max) // Метод заполнения массива случайными числами
{
    int[,] array = new int[m, n];
    Random number = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = number.Next(min, max + 1);
        }
    }
    return array;
}

void PrintArray2D(int[,] array) // Метод вывода массива в консоль с выравниванием
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            // Выравнивание по правому краю каждого элемента с отступом 3 символа (-##)
            Console.Write(String.Format("{0,3}\t", array[i, j]));
        }
        Console.WriteLine();
    }
}

int SumRow(int[,] array2D, int rowNumber) // Метод нахождения суммы элементов строки массива
{
    int sumRow = 0;
    for (int j = 0; j <= array2D.GetLength(1) - 1; j++)
    {
        sumRow += array2D[rowNumber, j];
    }
    return sumRow;
}

void MinSumRow(int[,] array2D) // Метод нахождения строки с минимальной суммой элементов
{
    int minValue = SumRow(array2D, 0);
    int n = array2D.GetLength(0);
    int tempValue = 0;
    int numberRow = 0;
    for (int i = 1; i < n; i++)
    {
        tempValue = SumRow(array2D, i);
        if (tempValue < minValue)
        {
            minValue = tempValue;
            numberRow = i;
        }
    }
    Console.WriteLine($"Наименьшая сумма элементов {minValue} в {numberRow + 1}-й строке.\n");
}

Console.Clear();
Console.WriteLine("Программа нахождения строки массива (m,n) с наименьшей суммой элементов.");
Console.Write("Введите количество строк в массиве (m): ");
int numString = ReadNumber();
Console.Write("Введите количество столбцов в массиве (n): ");
int numRow = ReadNumber();
int min = 0, max = 10; // Границы генерации случайных чисел
int[,] array2D = FillIntArray2D(numString, numRow, min, max);
Console.WriteLine("\nИсходный массив:");
PrintArray2D(array2D);
MinSumRow(array2D);