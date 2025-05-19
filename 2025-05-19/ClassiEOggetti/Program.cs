using System;

public class Persona
{
    public string? Nome;
    public int Eta;

    public Persona(string nome, int eta)
    {
        Nome = nome;
        Eta = eta;
    }

    public void Presentati()
    {
        Console.WriteLine($"Ciao, sono {Nome} e ho {Eta} anni.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Persona p = new Persona("Andrea", 21);
        p.Presentati();
    }
}