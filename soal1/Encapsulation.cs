using System;

namespace soal1;

// Encapsulation
public class BankAccount
{
    private decimal _balance;
    public decimal Balance
    {
        get { return _balance; }
        private set { _balance = value; }
    }
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Saldo harus lebih dari 0!");
        }
        else if (_balance < amount)
        {
            Console.WriteLine("Saldo tidak mencukupi!");
        }
        else
        {
            _balance -= amount;
        }
    }
}
