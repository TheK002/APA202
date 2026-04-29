using System;

class Program
{
    static int[] ArrayResize(int[] numbers, params int[] newNumbers)
    {
        int[] result = new int[numbers.Length + newNumbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            result[i] = numbers[i];
        }

        for (int i = 0; i < newNumbers.Length; i++)
        {
            result[numbers.Length + i] = newNumbers[i];
        }

        return result;
    }

    static void Main()
    {
        int[] numbers = { 1, 2, 3 };

        numbers = ArrayResize(numbers, 4, 5, 6, 7);

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}
