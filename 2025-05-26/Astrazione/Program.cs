using System;

//classe astratta
public abstract class Veicolo
{
    public abstract void Avvia();
}

//classe concreta che eredita dalla classe astratta
public class Auto : Veicolo
{
    public override void Avvia()
    {
        Console.WriteLine("L'auto si accende.");
    }
}

//interafaccia
public interface IVeicoloElettrico
{
    void Ricarica();
}

//classe che implementa l'interfaccia
public class ScooterElettrico : IVeicoloElettrico
{
    public void Ricarica()
    {
        Console.WriteLine("Scooter in ricarica.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Veicolo miaAuto = new Auto();
        miaAuto.Avvia();

        IVeicoloElettrico mioScooter = new ScooterElettrico();
        mioScooter.Ricarica();
    }
}