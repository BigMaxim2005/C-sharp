class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {

            bool CriteriaTrue = (number % 5 == 2) && (number % 7 == 1);

            if (CriteriaTrue)
            {
                Console.WriteLine("Число удовлетворяет обоим критериям.");
            }
            else
            {
                Console.WriteLine("Число не удовлетворяет обоим критериям.");
            }
        }
        else
        {
            Console.WriteLine("Введено некорректное число.");
        }
    }
}