using System;

public interface IPizza
{
    string Descrizione();
}

public class Margherita : IPizza
{
    public string Descrizione()
    {
        return "Margherita";
    }
}

public class Diavola : IPizza
{
    public string Descrizione()
    {
        return "Diavola";
    }
}

public class Vegetariana : IPizza
{
    public string Descrizione()
    {
        return "Vegetariana";
    }
}

public static class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "margherita":
                return new Margherita();

            case "diavola":
                return new Diavola();

            case "vegetariana":
                return new Vegetariana();

            default:
                Console.WriteLine("Pizza non disponibile.");
                return null;
        }
    }
}

public abstract class IngredienteExtra : IPizza
{
    protected IPizza _pizza;

    public IngredienteExtra(IPizza pizza)
    {
        _pizza = pizza;
    }

    public abstract string Descrizione();
}

public class ConOlive : IngredienteExtra
{
    public ConOlive(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con olive";
    }
}

public class ConMozzarellaExtra : IngredienteExtra
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con mozzarella extra";
    }
}

public class ConFunghi : IngredienteExtra
{
    public ConFunghi(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con funghi";
    }
}

public interface MetodoCottura
{
    string Cuoci(string pizza);
}

public class FornoElettrico : MetodoCottura
{
    public string Cuoci(string pizza)
    {
        return pizza + " cotta al forno elettrico";
    }
}

public class FornoLegna : MetodoCottura
{
    public string Cuoci(string pizza)
    {
        return pizza + " cotta al forno a legna";
    }
}

public class FornoVentilato : MetodoCottura
{
    public string Cuoci(string pizza)
    {
        return pizza + " cotta al forno ventilato";
    }
}

public class Chef
{
    private MetodoCottura _cottura;

    public void SelezionaCottura(MetodoCottura cottura)
    {
        _cottura = cottura;
    }

    public string Prepara(IPizza pizza)
    {
        if (_cottura == null)
        {
            return "Nessuna cottura impostata.";
        }
        string pizzaCotta = _cottura.Cuoci(pizza.Descrizione());
        return pizzaCotta;
    }
}

public interface IObserver
{
    void Update(string messaggio);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string messaggio);
}

public class SistemaLog : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine("[log]: " + messaggio);
    }
}

public class Marketing : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine("Promozione: torna a trovarci per uno sconto del 10%!");
    }
}

public sealed class GestoreOrdini : ISubject
{
    private static GestoreOrdini _instance;

    private IPizza _pizza;

    private List<IObserver> _observers = new List<IObserver>();

    private GestoreOrdini() { }

    public static GestoreOrdini Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GestoreOrdini();
            }
            return _instance;
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string messaggio)
    {
        foreach (var o in _observers)
        {
            o.Update(messaggio);
        }
    }

    public void ModificaOrdine(IPizza pizza)
    {
        _pizza = pizza;
    }

    public void StampaOrdine(IPizza pizza)
    {
        Console.WriteLine(pizza.Descrizione());
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var gestoreOrdini = GestoreOrdini.Instance;
        var sistemaLog = new SistemaLog();
        var Marketing = new Marketing();

        IPizza pizza = PizzaFactory.CreaPizza("margherita");
        pizza = new ConFunghi(pizza);

    }
}