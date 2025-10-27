using System;

namespace soal1;

// Inheritance & Polymorphism
public class Hewan
{
    public virtual void Bersuara()
    {
        Console.WriteLine("Hewan Bersuara..."); 
    }
}

public class Anjing : Hewan
{
    public override void Bersuara()
    {
        Console.WriteLine("Anjing bersuara guk guk!");
    }
}

public class Kucing : Hewan
{
    public override void Bersuara()
    {
        Console.WriteLine("Kucing bersuara meong meong!");
    }
}
