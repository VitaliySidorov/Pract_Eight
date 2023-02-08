// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


// Умножение выполнимо если число столбцов первого множителя равно числу строк второго.

// Произведение двух матриц в общем случае зависит от порядка сомножителей, 
// т.е. оно некоммутативно: A ⋅ B ≠ B ⋅ A

// Произведение матрицы A размера m × n и матрицы B размера n × k — это матрица C размера m × k, 
// в которой элемент c [i, j] ​равен сумме произведений элементов i строки матрицы A 
// на соответствующие элементы j столбца матрицы B:
// c [i, j] = a [i, 1] * b [1, j] + a [i, 2] * b [2, j] + ... + a [i, n] * b [n, j].

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
            Console.Write(String.Format("{0,3} ", array[i, j]));
        }
        Console.WriteLine();
    }
}

int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB) // Метод умножения матриц: принцип "строка на столбец"
{
    int[,] matrixResult = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i <= matrixA.GetLength(0) - 1; i++)
    {
        for (int j = 0; j <= matrixB.GetLength(1) - 1; j++)
        {
            for (int n = 0; n <= matrixB.GetLength(0) - 1; n++) // Счетчик количества слагаемых = количеству строк матрицы В
            {
                // c [i, j] = a [i, 1] * b [1, j] + a [i, 2] * b [2, j] + ... + a [i, n] * b [n, j]
                matrixResult[i, j] += matrixA[i, n] * matrixB[n, j];
            }
        }
    }
    return matrixResult;
}

Console.Clear();
Console.WriteLine("Программа нахождения произведения двух матриц.");
Console.Write("Введите количество строк в матрице А (m): ");
int numRowA = ReadNumber();
Console.Write("Введите количество столбцов в матрице А (n): ");
int numColumnA = ReadNumber();
Console.Write("Введите количество строк в матрице В (m): ");
int numRowB = ReadNumber();
Console.Write("Введите количество столбцов в матрице В (n): ");
int numColumnB = ReadNumber();
int min = 1, max = 5; // Границы генерации случайных чисел
int[,] matrixA = FillIntArray2D(numRowA, numColumnA, min, max);
int[,] matrixB = FillIntArray2D(numRowB, numColumnB, min, max);

// int[,] matrixA = new int[2, 2] {{2, 4}, {3, 2}};
// int[,] matrixB = new int[2, 2] {{3, 4}, {3, 3}};

Console.WriteLine("\nМатрица А:");
PrintArray2D(matrixA);
Console.WriteLine("\nМатрица В:");
PrintArray2D(matrixB);

if (numColumnA != numRowB) Console.WriteLine("Матрицы несовместимы. Число столбцов матрицы A не равно числу строк матрицы B.");
else
{
    int[,] matrixResult = MatrixMultiplication(matrixA, matrixB);
    Console.WriteLine("\nРезультирующая матрица:");
    PrintArray2D(matrixResult);
}