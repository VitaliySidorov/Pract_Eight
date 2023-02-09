// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] FillIntArray3D(int[] arrayUniqNumbers, int m, int n, int k) // Метод заполнения трехмерно массива из массива случайных чисел
{
    int[,,] array3D = new int[m, n, k];
    int indNumber = 0;
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[i, j, z] = arrayUniqNumbers[indNumber];
                indNumber++;
            }
        }
    }
    return array3D;
}

int[] GetArrayUniqNumbers(int m, int n, int k, int min, int max) // Метод заполнения массива случайными неповторяющимися числами
{
    int[] arrayUniqNumbers = new int[m * n * k]; // Задаем одномерный массив и определяем его размер
    Random number = new Random();
    int indexNumber = 0;
    while (indexNumber < m * n * k)
    {
        int randNumber = number.Next(min, max);
        bool b = true;
        for (int i = 0; i < indexNumber; i++) // Проверка, имеется ли уже такое число в массиве
            if (randNumber == arrayUniqNumbers[i])
            {
                b = false;
                break; // досрочный выход из цикла for, если такое число уже имеется в массиве
            }
        if (b) // Запись числа в массив если число уникальное
        {
            arrayUniqNumbers[indexNumber] = randNumber;
            indexNumber++;

        }
    }
    return arrayUniqNumbers;
}

void PrintArray3D(int[,,] array) // Метод вывода массива в консоль с выравниванием
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int z = 0; z < array.GetLength(2); z++)
            {
                // Выравнивание по правому краю каждого элемента с отступом 2 символа (##)
                Console.Write(String.Format("{0,2}({1},{2},{3}) ", array[i, j, z], i, j, z));
            }
            Console.WriteLine();
        }
    }
}

Console.Clear();
Console.WriteLine("Программа формирует трехмерный массив из неповторяющихся двузначных чисел\n" +
                  "размером [2 х 2 х 2] и выводит элементы массива и их индексы.");
int m = 2, n = 2, k = 2; // Размерность массива
int min = 10, max = 100; // Границы генерации случайных чисел

if (m * n * k > max - min) Console.WriteLine("Заполнить массив неповторяющимися элементами невозможно.");
else
{
    Console.WriteLine("\nЗаданный массив:");
    PrintArray3D(FillIntArray3D(GetArrayUniqNumbers(m, n, k, min, max), m, n, k));
}