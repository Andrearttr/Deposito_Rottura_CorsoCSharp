using System;

//interfaccia strategy
public interface IStrategiaOperazione
{
    double? Calcola(double a, double b);
}

//strategia somma
public class SommaStrategia : IStrategiaOperazione
{
    public double? Calcola(double a, double b)
    {
        return a + b;
    }
}

//strategia sottrazione
public class SottrazioneStrategia : IStrategiaOperazione
{
    public double? Calcola(double a, double b)
    {
        return a - b;
    }
}

//strategia molitplicazione
public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double? Calcola(double a, double b)
    {
        return a * b;
    }
}

//strategia divisione
public class DivisioneStrategia : IStrategiaOperazione
{
    public double? Calcola(double a, double b)
    {
        if (b != 0) //controllo divisione per zero
        {
            return a / b;
        }
        else
        {
            return null;
        }
    }
}

//context calcolatrice
public class Calcolatrice
{
    private IStrategiaOperazione _strategia;

    //imposta la strategia passata per parametro
    public void ImpostaStrategia(IStrategiaOperazione nuovaStrategia)
    {
        _strategia = nuovaStrategia;
    }

    //esegue l'operazione grazie alla strategia
    public void EseguiOperazione(double a, double b)
    {
        if (_strategia == null)
        {
            Console.WriteLine("\nNessuna operazione selezionata");
            return;
        }

        double? risultato = _strategia.Calcola(a, b); //richiama il metodo Calcola() della strategia impostata

        if (risultato != null) //controllo divisione per zero
        {
            Console.WriteLine($"Il risultato è {risultato}");
        }
        else
        {
            Console.WriteLine("Impossibile dividere per zero");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var calcolatrice = new Calcolatrice();

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nScegli l'operazione:");
            Console.WriteLine("[1] Somma");
            Console.WriteLine("[2] Sottrazione");
            Console.WriteLine("[3] Moltiplicazione");
            Console.WriteLine("[4] Divisione");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 4);

            if (menuAction == 0)
            {
                break;
            }
            
            Console.Write("Inserisci il primo numero: ");
            double a = Input.Double();
            Console.Write("Inserisci il secondo numero: ");
            double b = Input.Double();
        
            switch (menuAction)
            {
                case 1:
                    calcolatrice.ImpostaStrategia(new SommaStrategia());    //imposta la strategia da usare in base all'operazione richiesta
                    calcolatrice.EseguiOperazione(a, b);                    //esegue l'operazione
                    break;

                case 2:
                    calcolatrice.ImpostaStrategia(new SottrazioneStrategia());
                    calcolatrice.EseguiOperazione(a, b);
                    break;

                case 3:
                    calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia());
                    calcolatrice.EseguiOperazione(a, b);
                    break;

                case 4:
                    calcolatrice.ImpostaStrategia(new DivisioneStrategia());
                    calcolatrice.EseguiOperazione(a, b);
                    break;
            }
        }
    }
}