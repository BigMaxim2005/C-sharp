class Program
{
    static void Main()
    {
        Console.Write("Введите число в десятичной форме: ");
        if (int.TryParse(Console.ReadLine(), out int decimalNumber))
        {

            int thirdBitFromRight = (decimalNumber >> 2) & 1;

            Console.WriteLine($"Третий бит справа в двоичном представлении: {thirdBitFromRight}");
        }
        else
        {
            Console.WriteLine("Введено некорректное число.");
        }
    }
}