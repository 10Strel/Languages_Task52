/*
Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

int m = 0, n = 0;
Random random = new Random();

if (!InputControl("Задайте размерность двумерного массива (m n)", ref m, ref n))
    return;

int[,] array = InitArray(m, n);

decimal[] resultArray = DoWorkArray(array);

PrintTwoDimensionalArray(array);

Console.WriteLine();

PrintOneDimensionalArray(resultArray);

# region methods

bool InputControl(string caption, ref int par0, ref int par1)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\n{caption} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputStringArray = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck =
            inputStringArray.Length == 2 &&
            int.TryParse(inputStringArray[0], out par0) &&
            par0 >= 0 &&
            int.TryParse(inputStringArray[1], out par1) &&
            par1 >= 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[,] InitArray(int m, int n)
{
    int[,] array = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = random.Next(0, 100);
        }
    }

    return array;
}

decimal[] DoWorkArray(int[,] array)
{
    decimal[] resultArray = new decimal[n];

    for (int j = 0; j < n; j++)
    {
        int sum = 0;
        for (int i = 0; i < m; i++)
        {
            sum += array[i,j];
        }
        resultArray[j] = Math.Round((decimal)sum/m, 2);
    }

    return resultArray;
}

void PrintTwoDimensionalArray(int[,] array)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{array[i, j]}\t");
        }

        Console.WriteLine();
    }
}

void PrintOneDimensionalArray(decimal[] array)
{
    for (int i = 0; i < n; i++)
    {        
        Console.Write($"{array[i]}\t");
    }
}

# endregion

