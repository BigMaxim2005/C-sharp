class Program
{
    static void Main()
    {
        Console.Write("Введите число в десятичной форме: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int decimalNumber))
        {

            string octalNumber = Convert.ToString(decimalNumber, 8);

            if (octalNumber.Length >= 2)
            {
                char secondFromRight = octalNumber[octalNumber.Length - 2];

                Console.WriteLine($"Во введенном числе вторая справа цифра в восьмеричном представлении: {secondFromRight}");
            }
            else
            {
                Console.WriteLine("Введенное число не имеет восьмеричного представления с двумя цифрами.");
            }
        }
        else
        {
            Console.WriteLine("Введено некорректное число.");
        }
    }
}