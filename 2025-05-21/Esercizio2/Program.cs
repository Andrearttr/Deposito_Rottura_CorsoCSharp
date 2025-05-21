using System;

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> garage = new List<Veicolo>();     //lista dei veicoli
        int menuAction;
        bool exit = false;

        while (!exit)       //ciclo del menu 
        {
            Console.WriteLine("\nScegli l'operazione da eseguire:\n[1] Inserisci nuovo veicolo\n[2] Visualizza veicoli\n[3] Esci\n");
            menuAction = Input.Int(1, 3);

            switch (menuAction)     //azione da eseguire
            {
                case 1:     //aggiungi veicolo
                    Console.Write("\nE' un'auto(1) o una moto(2)?: ");
                    if (Input.Int(1, 2) == 1)       //scelta tra auto e moto
                    {
                        AggiungiAuto(out string marca, out string modello, out int numeroPorte);
                        garage.Add(new Auto(marca, modello, numeroPorte));
                    }
                    else
                    {
                        AggiungiMoto(out string marca, out string modello, out string tipoManubrio);
                        garage.Add(new Moto(marca, modello, tipoManubrio));
                    }
                    break;

                case 2:     //visualizza veicoli
                    Console.WriteLine("\nVeicoli presenti nel garage:\n");
                    foreach (Veicolo veicolo in garage)
                    {
                        veicolo.StampaInfo();
                    }
                    break;

                case 3:
                    exit = true;
                    break;

            }
        }
    }

    static void AggiungiAuto(out string marca, out string modello, out int numeroPorte)     //funzione aggiunta auto
    {
        Console.Write("\nAggiunta nuova auto\nAggiungi la marca: ");
        marca = Input.String();
        Console.Write("Aggiungi il modello: ");
        modello = Input.String();
        Console.Write("Aggiungi il numero di porte: ");
        numeroPorte = Input.Int();
    }

    static void AggiungiMoto(out string marca, out string modello, out string tipoManubrio)     //funzione aggiunta moto
    {
        Console.Write("\nAggiunta nuova moto\nAggiungi la marca: ");
        marca = Input.String();
        Console.Write("Aggiungi il modello: ");
        modello = Input.String();
        Console.Write("Aggiungi il tipo di manubrio: ");
        tipoManubrio = Input.String();
    }
}

public class Veicolo        //classe base veicolo
{
    public string Marca;
    public string Modello;

    public  Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}");
    }
}

public class Auto : Veicolo     //classe derivata auto
{
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)
    {
        NumeroPorte = numeroPorte;
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}, Numero porte: {NumeroPorte}");
    }
}

public class Moto : Veicolo     //classe derivata moto
{
    public string TipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)
    {
        TipoManubrio = tipoManubrio;
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}, Tipo manubrio: {TipoManubrio}");
    }
}