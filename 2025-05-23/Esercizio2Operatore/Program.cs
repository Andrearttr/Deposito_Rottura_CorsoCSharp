using System;

public class Operatore
{
    private string nome;
    private string turno;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    public string Turno
    {
        get { return turno; }
        set
        {
            if (value == "giorno" || value == "notte")
            {
                turno = value;
            }
            else
            {
                Console.WriteLine("Turno non valido");
            }
        }
    }

    public Operatore(string nome, string turno)
    {
        Nome = nome;
        Turno = turno;
    }
    public virtual void StampaCompito()
    {
        Console.WriteLine("Operatore generico in servizio");
    }
}

public class OperatoreEmergenza : Operatore
{
    private int livelloUrgenza;

    public int LivelloUrgenza
    {
        get { return livelloUrgenza; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                livelloUrgenza = value;
            }
            else
            {
                Console.WriteLine("Livello urgenza non valido");
            }
        }
    }

    public OperatoreEmergenza(string nome, string turno, int livelloUrgenza) : base(nome, turno)
    {
        LivelloUrgenza = livelloUrgenza;
    }

    public override void StampaCompito()
    {
        Console.WriteLine($"Gestione emergenza di livello {LivelloUrgenza}.");
    }
}

public class OperatoreSicurezza : Operatore
{
    private string areaSorvegliata;

    public string AreaSorvegliata
    {
        get { return areaSorvegliata; }
        set { areaSorvegliata = value; }
    }

    public OperatoreSicurezza(string nome, string turno, string areaSorvegliata) : base(nome, turno)
    {
        AreaSorvegliata = areaSorvegliata;
    }

    public override void StampaCompito()
    {
        Console.WriteLine($"Sorveglianza dell'area {AreaSorvegliata}.");
    }
}

public class OperatoreLogistica : Operatore
{
    private int numeroConsegne;

    public int NumeroConsegne
    {
        get { return numeroConsegne; }
        set
        {
            if (value >= 0)
            {
                numeroConsegne = value;
            }
            else
            {
                Console.WriteLine("Numero consegne non valido");
            }
        }
    }

    public OperatoreLogistica(string nome, string turno, int numeroConsegne) : base(nome, turno)
    {
        NumeroConsegne = numeroConsegne;
    }

    public override void StampaCompito()
    {
        Console.WriteLine($"Coordinamento di {NumeroConsegne} consegne.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;
        List<Operatore> operatori = new List<Operatore>();

        while (!exit)
        {
            Console.WriteLine("\nGestione del personale:");
            Console.WriteLine("[1] Aggiungi operatore");
            Console.WriteLine("[2] Visualizza oepratori");
            Console.WriteLine("[3] Esegui compiti");
            Console.WriteLine("[0] Esci\n");

            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 0:
                    exit = true;
                    break;

                case 1:

                    Console.WriteLine("\nScegli il tipo:");
                    Console.WriteLine("[1] Operatore Emergenza");
                    Console.WriteLine("[2] Operatore Sicurezza");
                    Console.WriteLine("[3] Operatore Logistica\n");
                    int tipo = Input.Int(1, 3);

                    switch (tipo)
                    {
                        case 1:
                            Console.Write("Inserisci nome: ");
                            string nome = Input.String();
                            Console.Write("Inserisci turno (giorno o notte): ");
                            string turno = Input.String();
                            Console.Write($"Inserisci livello urgenza (1-5): ");
                            int livelloUrgenza = Input.Int();

                            operatori.Add(new OperatoreEmergenza(nome, turno, livelloUrgenza));
                            break;

                        case 2:
                            Console.Write("Inserisci nome: ");
                            nome = Input.String();
                            Console.Write("Inserisci turno (giorno o notte): ");
                            turno = Input.String();
                            Console.Write($"Inserisci area sorvegliata: ");
                            string areaSorvegliata = Input.String();

                            operatori.Add(new OperatoreSicurezza(nome, turno, areaSorvegliata));
                            break;

                        case 3:
                            Console.Write("Inserisci nome: ");
                            nome = Input.String();
                            Console.Write("Inserisci turno (giorno o notte): ");
                            turno = Input.String();
                            Console.Write($"Inserisci numero consegne: ");
                            int numeroConsegne = Input.Int();

                            operatori.Add(new OperatoreLogistica(nome, turno, numeroConsegne));
                            break;
                    }
                    break;

                case 2:
                    Console.WriteLine("\nOperatori:");
                    foreach (Operatore op in operatori)
                    {
                        Console.WriteLine($"Nome: {op.Nome}, tipo: {op.GetType()}, turno: {op.Turno}");
                    }
                    break;

                case 3:
                    Console.WriteLine("\nCompiti:");
                    foreach (Operatore op in operatori)
                    {
                        Console.Write($"{op.Nome}: ");
                        op.StampaCompito();
                    }
                    break;
            }
        }
    }
}