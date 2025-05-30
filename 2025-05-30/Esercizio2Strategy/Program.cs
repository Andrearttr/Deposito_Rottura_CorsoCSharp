using System;

public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza";
    }

    public string Prepara()
    {
        return "Pizza";
    }
}

public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }

    public string Prepara()
    {
        return "Hamburger";
    }
}

public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Insalata";
    }

    public string Prepara()
    {
        return "Insalata";
    }
}

public interface IPreparazioneStrategia
{
    string Prepara(string descrizione);
}

public class Fritto : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return descrizione + " fritto";
    }
}

public class AlForno : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return descrizione + " al forno";
    }
}

public class AllaGriglia : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return descrizione + " alla griglia";
    }
}

public class Chef
{
    private IPreparazioneStrategia _strategia;

    public void SelezionaCottura(IPreparazioneStrategia strategia)
    {
        _strategia = strategia;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        if (_strategia == null)
        {
            return "Nessuna cottura impostata.";
        }
        string piattoCompleto = _strategia.Prepara(piatto.Descrizione());
        return piattoCompleto;
    }
}

public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piatto;

    public IngredienteExtra(IPiatto piatto)
    {
        _piatto = piatto;
    }

    public abstract string Descrizione();

    public string Prepara()
    {
        return _piatto.Prepara();
    }
}

public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con formaggio";
    }
}

public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con bacon";
    }
}

public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con salsa";
    }
}

public static class PiattoFactory
{
    public static IPiatto Crea(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "pizza":
                return new Pizza();

            case "hamburger":
                return new Hamburger();

            case "insalata":
                return new Insalata();

            default:
                Console.WriteLine("Piatto non disponibile");
                return null;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var chef = new Chef();
        IPiatto piatto;

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("[1] Prepara piatto");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 1);

            switch (menuAction)
            {
                case 1:
                    Console.Write("\nScegli il tipo di piatto (pizza, hamburger, insalata): ");
                    string tipo = Input.String();
                    piatto = PiattoFactory.Crea(tipo);
                    piatto = DecorationMenu(piatto);

                    Console.WriteLine("\nScegli il metodo di cottura");
                    Console.WriteLine("[1] Al forno");
                    Console.WriteLine("[2] Fritto");
                    Console.WriteLine("[3] Alla Griglia");
                    Console.Write("Scelta: ");
                    int menuAction2 = Input.Int(1, 3);

                    switch (menuAction2)
                    {
                        case 1:
                            chef.SelezionaCottura(new AlForno());
                            break;

                        case 2:
                            chef.SelezionaCottura(new Fritto());
                            break;

                        case 3:
                            chef.SelezionaCottura(new AllaGriglia());
                            break;
                    }

                    Console.WriteLine($"Descrizione: {piatto.Descrizione()}");
                    Console.WriteLine($"Preparazione: {chef.PreparaPiatto(piatto)}");
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
    
    public static IPiatto DecorationMenu(IPiatto piatto)
    {
        bool exit = false;

        IPiatto _piatto = piatto;

        while (!exit)
        {
            Console.WriteLine("\nVuoi Aggiungere qualcosa?");
            Console.WriteLine("[1] Formaggio");
            Console.WriteLine("[2] Bacon");
            Console.WriteLine("[3] Salsa");
            Console.WriteLine("[0] No");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 1:
                    _piatto = new ConFormaggio(_piatto);
                    Console.WriteLine("\nAggiunto formaggio");
                    break;

                case 2:
                    _piatto = new ConBacon(_piatto);
                    Console.WriteLine("\nAggiunto bacon");
                    break;

                case 3:
                    _piatto = new ConSalsa(_piatto);
                    Console.WriteLine("\nAggiunta salsa");
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }

        return _piatto;
    }
}