using System;

public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}

public class Auto : IVeicolo
{

    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }
}

public class Moto : IVeicolo
{

    public void Avvia()
    {
        Console.WriteLine("Avvio della moto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }
}

public class Camion : IVeicolo
{

    public void Avvia()
    {
        Console.WriteLine("Avvio del camion");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

public class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto":
                return new Auto();

            case "moto":
                return new Moto();

            case "camion":
                return new Camion();

            default:
                return null;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        Console.Write("\nInserisci tipo (auto, moto, camion): ");
        string tipo = Input.String();
        menu.Seleziona(tipo);
    }
}

public class Menu
{
    public void Seleziona(string tipo) {
        IVeicolo veicolo = VeicoloFactory.CreaVeicolo(tipo);
        if (veicolo != null)
        {
            veicolo.Avvia();
            veicolo.MostraTipo();
        }
        else
        {
            Console.WriteLine("Veicolo non valido");
        }
    }
}