class Program
{

    static bool IsBinaryNumber(string input)
    {
        foreach (char s in input)
        {
            if (s != '0' && s != '1')
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Введите число в бинарном представлении: ");
        string userInput = Console.ReadLine();

        if (IsBinaryNumber(userInput))
        {
            int binaryNumber = Convert.ToInt32(userInput, 2);

            int result = binaryNumber & ~(1 << 3);

            Console.WriteLine($"Число после установки четвертого бита в 0: {result} (в бинарном представлении: {Convert.ToString(result, 2)})");
        }
        else
        {
            Console.WriteLine("Введена некорректная бинарная строка.");
        }
    }
}