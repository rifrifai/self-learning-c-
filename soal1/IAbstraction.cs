using System;

namespace soal1;

// Abstraction
public interface IAbstraction
{
    void ProcessPayment(decimal amount);
    bool ValidatePayment();
}
