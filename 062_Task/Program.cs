// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int ReadNumber() // Метод проверки соответствия вводимого числа условиям задачи
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int number) && number > 1)
        {
            return number;
        }
        else Console.WriteLine("Не удалось распознать требуемое число, попробуйте еще раз.");
    }
}

void PrintArray2D(int[,] array) // Метод вывода массива в консоль с выравниванием
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            // Выравнивание по правому краю каждого элемента с отступом 3 символа (-##)
            Console.Write(String.Format("{0,3}  ", array[i, j]));
        }
        Console.WriteLine();
    }
}

int[,] SpiralFilling(int numRow, int numColumn) // Метод заполнения массива спиралью
{
    int column = 0;
    int row = 0;
    int round = 0;

    int[,] array = new int[numRow, numColumn];
    int value = 1;
    do
    {
        while (column < numColumn - round) // заполнение строк слева-направо
        {
            array[row, column] = value;
            column++;
            value++;
        }
        column--; // коррекция индексов при повороте
        row++;

        while (row < numRow - round) // заполнение столбцов сверху-вниз
        {
            array[row, column] = value;
            row++;
            value++;
        }
        row--; // коррекция индексов при повороте
        column--;

        while (column >= round) // заполнение строк справа-налево
        {
            array[row, column] = value;
            column--;
            value++;
        }
        column++; // коррекция индексов при повороте
        row--;
        round++;

        // Вводим переменную round считающую число кругов спирали

        while (row >= 0 + round) // заполнение столбцов снизу-вверх
        {
            array[row, column] = value;
            row--;
            value++;
        }
        row++; // коррекция индексов при повороте
        column++;

    } while (value < array.Length + 1); // Заполняем массив пока не кончатся все элементы
    return array;
}

Console.Clear();
Console.WriteLine("Программа заполнения массива (m,n) по спирали.");
Console.Write("Введите количество строк в массиве (m): ");
int numRow = ReadNumber();
Console.Write("Введите количество столбцов в массиве (n): ");
int numColumn = ReadNumber();

Console.WriteLine("\nЗаполненный массив:");
PrintArray2D(SpiralFilling(numRow, numColumn));