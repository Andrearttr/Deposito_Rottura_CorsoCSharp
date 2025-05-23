using System;
public class Veicolo //classe base
{
    public string Targa { get; set; }
    public int Riparazioni { get; set; } = 0; //numero di riparazioni
    public int Costo { get; set; }  //costo delle riparazioni

    public Veicolo(string targa)
    {
        Targa = targa;
    }
    public virtual void Ripara()    //ripara il veicolo
    {
        Console.WriteLine("\nIl veicolo viene riparato.");
        Riparazioni += 1;
    }

    public virtual void Ripara(string targa) //ripara il veicolo e cambia la targa
    {
        Ripara();
        Targa = targa;
        Console.WriteLine($"nuova targa: {Targa}");
    }
}

public class Auto : Veicolo
{
    public Auto(string targa) : base(targa)
    {
        Targa = targa;
        Costo = 100;
    }
    public override void Ripara()
    {
        Console.WriteLine($"\nConstrollo olio, freni e motore dell'auto con targa {Targa}.");
        Riparazioni += 1;

    }

    public override void Ripara(string targa)
    {
        Ripara();
        Targa = targa;
        Console.WriteLine($"Nuova targa: {Targa}");
    }
}

public class Moto : Veicolo
{
    public Moto(string targa) : base(targa)
    {
        Targa = targa;
        Costo = 70;
    }
    public override void Ripara()
    {
        Console.WriteLine($"\nConstrollo olio, freni e gomme della moto con targa {Targa}.");
        Riparazioni += 1;

    }

    public override void Ripara(string targa)
    {
        Ripara();
        Targa = targa;
        Console.WriteLine($"Nuova targa: {Targa}");
    }
}

public class Camion : Veicolo
{
    public Camion(string targa) : base(targa)
    {
        Targa = targa;
        Costo = 150;
    }
    public override void Ripara()
    {
        Console.WriteLine($"\nConstrollo sospensioni, freni rinforzati e carico del camion con targa {Targa}.");
        Riparazioni += 1;

    }

    public override void Ripara(string targa)
    {
        Ripara();
        Targa = targa;
        Console.WriteLine($"Nuova targa: {Targa}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>(); //lista dei veicoli
        bool exit = false;

        Console.Write("Inserire il budget: ");
        int budget = Input.Int();

        while (!exit)   //menu
        {
            Console.WriteLine($"\nBudget: {budget}");
            Console.WriteLine("\nScegli l'azione:");
            Console.WriteLine("[1] Aggiungi auto");
            Console.WriteLine("[2] Aggiungi moto");
            Console.WriteLine("[3] Aggiungi camion");
            Console.WriteLine("[4] Ripara un veicolo");
            Console.WriteLine("[5] Visualizza veicoli");
            Console.WriteLine("[0] Esci");

            int menuAction = Input.Int(0, 5);

            switch (menuAction)
            {
                case 0:
                    exit = true;
                    break;

                case 1:
                    Console.Write("\nInserisci la targa: ");    //aggiungi auto
                    string targa = Input.String();
                    veicoli.Add(new Auto(targa));
                    break;

                case 2:
                    Console.Write("\nInserisci la targa: ");    //aggiungi moto
                    targa = Input.String();
                    veicoli.Add(new Moto(targa));
                    break;

                case 3:
                    Console.Write("\nInserisci la targa: "); //aggiungi camion
                    targa = Input.String();
                    veicoli.Add(new Camion(targa));
                    break;

                case 4:
                    Console.Write("\nInserisci la targa: ");    //cerca veicolo per targa
                    targa = Input.String();
                    Console.Write("Vuoi anche cambiare la targa? (1: si, 2: no): ");    //opzione inserimento nuova targa
                    int cambioTarga = Input.Int(1, 2);

                    if (cambioTarga == 1)   //ripara e cambia targa
                    {
                        Console.Write("Inserisci la nuova targa: ");
                        string newTarga = Input.String();
                        foreach (Veicolo v in veicoli)
                        {
                            if (v.Targa == targa && v.Riparazioni < 3 && budget >= v.Costo)
                            {
                                v.Ripara(newTarga);
                                budget -= v.Costo;
                            }
                            else if (budget < v.Costo)
                            {
                                Console.WriteLine("Budget insufficiente.");
                            }
                            else if (v.Riparazioni >= 3)
                            {
                                Console.WriteLine("Riparazioni esauite");
                            }
                        }
                    }
                    else if (cambioTarga == 2)  //ripara
                    {
                        foreach (Veicolo v in veicoli)
                        {
                            if (v.Targa == targa && v.Riparazioni < 3 && budget >= v.Costo)
                            {
                                v.Ripara();
                                budget -= v.Costo;
                            }
                            else if (budget < v.Costo)
                            {
                                Console.WriteLine("Budget insufficiente.");
                            }
                            else if (v.Riparazioni >= 3)
                            {
                                Console.WriteLine("Riparazioni esauite.");
                            }
                        }
                    }
                    break;

                case 5:
                    Console.WriteLine("\nVeicoli: ");   //stampa lista veicoli
                    foreach (Veicolo v in veicoli)
                    {
                        Console.WriteLine($"{v.GetType()} targa {v.Targa}");
                    }
                    break;
            }
        }
    }
}