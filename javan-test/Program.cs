class Program
{
    static void Main(string[] args)
    {
        FizzBuzz();
        IsPalindrome("bagas");
        LinqBasic();
    }

    static void FizzBuzz()
    {
        int n = 55;
        for (int i = 1; i <= n; i++)
        {
            if(i % 5 == 0 && i % 3 == 0)
            {
                Console.Write("FizzBuzz");
            }
            else if(i % 5 == 0)
            {
                Console.Write("Fizz");
            } else if (i % 3 == 0)
            {
                Console.Write("Buzz");
            } else
            {
                Console.Write(i);
            }
            if(i < n) Console.Write(", ");
        }
        Console.WriteLine();
    }

    static void IsPalindrome(string text)
    {
        var reserved = new string(text.Reverse().ToArray());
        Console.WriteLine(text.Equals(reserved, StringComparison.OrdinalIgnoreCase));
    }

    static void LinqBasic()
    {
        List<int> numbers = [1, 5, 8, 10, 3, 40, 33, 21, 19];
        // var result = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
        var result = numbers.Where(n => n % 2 == 1).OrderBy(n => n);

        Console.WriteLine(string.Join(", ", result));
    }
}