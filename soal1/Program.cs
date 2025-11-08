using System;
using System.Threading.Tasks;
using soal1;

class Program
{
    static void Main()
    {

        /* Encapsulation */
        BankAccount myAccount = new();
        myAccount.Deposit(500000);
        myAccount.Withdraw(50000);
        myAccount.Withdraw(50000);
        Console.WriteLine($"Saldo anda sisa Rp.{myAccount.Balance:N0}");

        /* Inheritance and Polymorphism*/
        // using abstract class
        // Anjing anjing = new();
        // anjing.Bersuara();
        // Kucing kucing = new();
        // kucing.Bersuara();
        // using virtual class
        Hewan hewan = new();
        hewan.Bersuara();
        Anjing anjing = new();
        anjing.Bersuara();
        Kucing kucing = new();
        kucing.Bersuara();

        // SwapValue();
        // Star(3);
        // IsPrime(4);
        ReverseString();
    }

    static void SwapValue()
    {
        int a = 10;
        int b = 20;

        Console.WriteLine($"Sebelum di ubah int a = {a}, int b = {b}");
        (a, b) = (b, a);
        Console.WriteLine($"SETELAH di ubah int a = {a}, int b = {b}");
    }

    static void Star(int n)
    {
        int angka = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{angka} ");
                angka++;
            }
            Console.WriteLine();
        }
    }

    static void IsPrime(int number)
    {
        if (number <= 1)
        {
            Console.WriteLine($"{number} is not a Prime!");
            return;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine($"{number} is not a Prime!");
                return;
            }
        }

        Console.WriteLine($"{number} is a Prime!");
    }

    static void ReverseString()
    {
        string sapa = "Halo";
        Console.WriteLine(sapa);
        // sapa = new string(sapa.Reverse().ToArray());
        sapa = new string([.. sapa.Reverse()]);
        Console.WriteLine(sapa);
    }
}


