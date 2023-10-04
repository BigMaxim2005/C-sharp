int n;
while(true)
{
    Console.Write("Ведите целое число:");
    string num = Console.ReadLine();
    if (int.TryParse(num, out n))
    {
        for (int i = 1; i <= n; i++)
        {
            Console.Write(i + " ");
        }

        for (int i = n - 1; i >= 1; i--)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        break;
    }
    Console.WriteLine("Вы ввели не целое число");

} 

