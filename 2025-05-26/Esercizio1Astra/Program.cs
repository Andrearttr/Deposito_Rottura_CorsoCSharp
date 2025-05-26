using System;

//classe astratta
public abstract class DispositivoElettronico
{
    private string _modello;

    public string Modello
    {
        get { return _modello; }
        set { _modello = value; }
    }

//metodi astratti
    public abstract void Accendi();
    public abstract void Spegni();

    public virtual void MostraInfo()
    {
        Console.WriteLine(Modello);
    }
}

//classe che eredita da classe astratta
public class Computer : DispositivoElettronico
{
    public Computer(string modello)
    {
        Modello = modello;
    }

    //override metodi astratti
    public override void Accendi()
    {
        Console.WriteLine($"Il computer {Modello} si avvia.");
    }

    public override void Spegni()
    {
        Console.WriteLine($"Il computer {Modello} si spegne.");
    }

    public override void MostraInfo()
    {
        Console.Write("Computer: ");
        base.MostraInfo();
    }
}

public class Stampante : DispositivoElettronico
{
    public Stampante(string modello)
    {
        Modello = modello;
    }

    public override void Accendi()
    {
        Console.WriteLine($"La stampante {Modello} si accende.");
    }

    public override void Spegni()
    {
        Console.WriteLine($"La stampante {Modello} va in standby.");
    }

    public override void MostraInfo()
    {
        Console.Write("Stampante: ");
        base.MostraInfo();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nSeleziona l'operazione da eseguire");
            Console.WriteLine("[1] Aggiungi computer");
            Console.WriteLine("[2] Aggiungi stampante");
            Console.WriteLine("[3] Visualizza dispositivi");
            Console.WriteLine("[4] Accendi dispositivi");
            Console.WriteLine("[5] Spegni dispositivi");
            Console.WriteLine("[0] Esci");
            int menuAction = Input.Int(0, 5);

            switch (menuAction)
            {
                case 0:
                    exit = true;
                    break;

                case 1:
                    Console.Write("\nInserisci il modello del computer: ");
                    string modello = Input.String();
                    dispositivi.Add(new Computer(modello));
                    break;

                case 2:
                    Console.Write("\nInserisci il modello della stampante: ");
                    modello = Input.String();
                    dispositivi.Add(new Stampante(modello));
                    break;

                case 3:
                    Console.WriteLine("\nDispositivi:");
                    foreach (DispositivoElettronico d in dispositivi)
                    {
                        d.MostraInfo();
                    }
                    break;

                case 4:
                    Console.WriteLine("\nAccensione dispositivi:");
                    foreach (DispositivoElettronico d in dispositivi)
                    {
                        d.Accendi();
                    }
                    break;

                case 5:
                    Console.WriteLine("\nSpegnimento dispositivi:");
                    foreach (DispositivoElettronico d in dispositivi)
                    {
                        d.Spegni();
                    }
                    break;
            }
        }
    }
}