// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

int[,] SortRowDown(int[,] array2Dsort) // Метод пузырьковой сортировки строк в массиве, сложность О(n^2)
{
    int tempValue = 0;
    for (int i = 0; i <= array2Dsort.GetLength(0) - 1; i++) // Цикл перебора рядов
    {
        for (int m = 1; m <= array2Dsort.GetLength(1) - 1; m++) // Цикл отсекания отсортированных чисел
        {
            for (int j = 0; j <= array2Dsort.GetLength(1) - 2; j++) // Цикл перебора оставшихся чисел в строке
            {
                if (array2Dsort[i, m] > array2Dsort[i, j])
                {
                    tempValue = array2Dsort[i, m];
                    array2Dsort[i, m] = array2Dsort[i, j];
                    array2Dsort[i, j] = tempValue;
                }
            }
        }
    }
    return array2Dsort;
}

Console.Clear();
Console.WriteLine("Программа упорядочивания по убыванию элементов в строках массива (m,n).");
Console.Write("Введите количество строк в массиве (m): ");
int numString = ReadNumber();
Console.Write("Введите количество столбцов в массиве (n): ");
int numRow = ReadNumber();
int min = 0, max = 10; // Границы генерации случайных чисел
int[,] array2D = FillIntArray2D(numString, numRow, min, max);
Console.WriteLine("\nИсходный массив:");
PrintArray2D(array2D);
SortRowDown(array2D);
Console.WriteLine("\nСортированный массив:");
PrintArray2D(SortRowDown(array2D));