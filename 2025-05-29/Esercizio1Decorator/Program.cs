using System;
using System.ComponentModel.Design;
using System.Globalization;

public interface IBevanda
{
    string Descrizione();
    double Costo();
}

public class Caffe : IBevanda
{
    public string Descrizione()
    {
        return "Tazzina di caffe in cialda";
    }

    public double Costo()
    {
        return 1.5;
    }
}

public class Te : IBevanda
{
    public string Descrizione()
    {
        return "Tazza di Te nero inglese";
    }

    public double Costo()
    {
        return 1.0;
    }
}

public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda _component;

    protected DecoratoreBevanda(IBevanda component)
    {
        _component = component;
    }

    public virtual string Descrizione()
    {
        return _component.Descrizione();
    }

    public virtual double Costo()
    {
        return _component.Costo();
    }
}

public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda component) : base(component) { }

    public override string Descrizione()
    {
        return $"{base.Descrizione()} con latte";
    }

    public override double Costo()
    {
        return base.Costo() + 0.5;
    }
}

public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda component) : base(component) { }

    public override string Descrizione()
    {
        return $"{base.Descrizione()} con cioccolato";
    }

    public override double Costo()
    {
        return base.Costo() + 1.0;
    }
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda component) : base(component) { }

    public override string Descrizione()
    {
        return $"{base.Descrizione()} con panna";
    }

    public override double Costo()
    {
        return base.Costo() + 0.75;
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
            Console.WriteLine("[1] Ordina caffe");
            Console.WriteLine("[2] Ordina te");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 2);


            switch (menuAction)
            {
                case 1:
                    IBevanda bevanda = new Caffe();
                    bevanda = DecorationMenu(bevanda);
                    Console.WriteLine($"\nDescrizione: {bevanda.Descrizione()}, Costo: {bevanda.Costo()} euro");
                    break;

                case 2:
                    bevanda = new Te();
                    bevanda = DecorationMenu(bevanda);
                    Console.WriteLine($"\nDescrizione: {bevanda.Descrizione()}, Costo: {bevanda.Costo()} euro");
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }

    public static  IBevanda DecorationMenu(IBevanda bevanda)
    {
        bool exit = false;

        IBevanda _bevanda = bevanda;

        while (!exit)
        {
            Console.WriteLine("\nVuoi Aggiungere qualcosa?");
            Console.WriteLine("[1] Latte");
            Console.WriteLine("[2] Cioccolato");
            Console.WriteLine("[3] Panna");
            Console.WriteLine("[0] No");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 1:
                    _bevanda = new ConLatte(_bevanda);
                    Console.WriteLine("\nAggiunto latte");
                    break;

                case 2:
                    _bevanda = new ConCioccolato(_bevanda);
                    Console.WriteLine("\nAggiunto cioccolato");
                    break;

                case 3:
                    _bevanda = new ConPanna(_bevanda);
                    Console.WriteLine("\nAggiunta panna");
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }

        return _bevanda;
    }
}
