Console.Write("Введите число: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    if (input.Length >= 4)
    {
        int fourthFromRight = int.Parse(input.Substring(input.Length - 4, 1));

        if (fourthFromRight == 1)
        {
            Console.WriteLine("В данном числе 1 тысяча.");
        }
        else
        {
            Console.WriteLine($"В данном числе {fourthFromRight} тысячи.");
        }
    }
    else
    {
        Console.WriteLine("Число должно состоять как минимум из 4 цифр.");
    }
}
else
{
    Console.WriteLine("Введено некорректное число.");
}