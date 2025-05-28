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
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Crea Veicolo");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 1);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nVeicolo da creare (auto, moto, camion): ");
                    string tipo = Input.String();
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
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}