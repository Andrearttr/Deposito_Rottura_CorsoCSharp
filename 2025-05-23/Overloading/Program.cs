using System;

public class Calcolatrice
{
    public int Somma(int a, int b)  //stessi metodi ma con firma diversa
    {
        return a + b;
    }

    public double Somma(double a, double b)
    {
        return a + b;
    }

    public int Somma(int a, int b, int c)
    {
        return a + b + c;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Calcolatrice calc = new Calcolatrice();
        Console.WriteLine(calc.Somma(10, 5));   //vede il tipo di firma e chiama il metodo corretto
        Console.WriteLine(calc.Somma(10.6, 5.8));
        Console.WriteLine(calc.Somma(10, 5, 3));

        List<Forma> forme = new List<Forma>
        {
            new Rettangolo {Base = 4, Altezza = 5},
            new Cerchio { Raggio = 3}
        };

        foreach (Forma forma in forme)
        {
            Console.WriteLine($"Area: {forma.CalcolaArea()}");
        }
    }
}

public class Forma
{
    public virtual double CalcolaArea()
    {
        return 0;
    }
}

public class Rettangolo : Forma
{
    public double Base { get; set; }
    public double Altezza { get; set; }

    public override double CalcolaArea()
    {
        return Base * Altezza;
    }
}

public class Cerchio : Forma
{
    public double Raggio { get; set; }

    public override double CalcolaArea()
    {
        return Math.PI * Raggio * Raggio;
    }
}