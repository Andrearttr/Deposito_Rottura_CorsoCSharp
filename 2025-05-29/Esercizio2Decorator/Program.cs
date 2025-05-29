using System;

public interface ITorta
{
    string Descrizione();
}

public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
}

public class TortaVaniglia : ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}

public class TortaFrutta : ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}

public abstract class DecoratoreTorta : ITorta
{
    protected ITorta _component;

    protected DecoratoreTorta(ITorta component)
    {
        _component = component;
    }

    public virtual String Descrizione()
    {
        return _component.Descrizione();
    }
}

public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta component) : base(component) { }

    public override String Descrizione()
    {
        return base.Descrizione() + " con panna";
    }
}

public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta component) : base(component) { }

    public override String Descrizione()
    {
        return base.Descrizione() + " con fragole";
    }
}

public class ConGlassa : DecoratoreTorta
{
    public ConGlassa(ITorta component) : base(component) { }

    public override String Descrizione()
    {
        return base.Descrizione() + " con glassa";
    }
}

public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "cioccolato":
                return new TortaCioccolato();

            case "vaniglia":
                return new TortaVaniglia();

            case "frutta":
                return new TortaFrutta();

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
            Console.WriteLine("[1] Ordina torta");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 1);

            switch (menuAction)
            {
                case 1:
                    Console.Write("\nDi che tipo? (cioccolato, vaniglia, frutta): ");
                    string tipo = Input.String();
                    ITorta torta = TortaFactory.CreaTortaBase(tipo);

                    if (torta == null)
                    {
                        Console.WriteLine("\nTipo di torta non disponibile");
                        break;
                    }

                    torta = DecorationMenu(torta);
                    Console.WriteLine($"\nProdotto finale: {torta.Descrizione()}");
                    break;
                
                case 0:
                    exit = true;
                    break;
            }
        }
    }
    
    public static  ITorta DecorationMenu(ITorta torta)
    {
        bool exit = false;

        ITorta _torta = torta;

        while (!exit)
        {
            Console.WriteLine("\nVuoi Aggiungere qualcosa?");
            Console.WriteLine("[1] Panna");
            Console.WriteLine("[2] Fragole");
            Console.WriteLine("[3] Glassa");
            Console.WriteLine("[0] No");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 1:
                    _torta = new ConPanna(_torta);
                    Console.WriteLine("\nAggiunta panna");
                    break;

                case 2:
                    _torta = new ConFragole(_torta);
                    Console.WriteLine("\nAggiunte fragole");
                    break;

                case 3:
                    _torta = new ConGlassa(_torta);
                    Console.WriteLine("\nAggiunta glassa");
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }

        return _torta;
    }
}