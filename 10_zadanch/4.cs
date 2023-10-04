using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number >= 5 && number <= 10)
            {
                Console.WriteLine("Число находится в диапазоне от 5 до 10 включительно.");
            }
            else
            {
                Console.WriteLine("Число не находится в указанном диапазоне.");
            }
        }
        else
        {
            Console.WriteLine("Введено некорректное число.");
        }
    }
}