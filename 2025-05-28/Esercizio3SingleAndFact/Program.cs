using System;

public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
    void StampaDettagli();
}

public class Auto : IVeicolo
{
    private string _targa;

    public string Targa
    {
        get { return _targa; }
        set { _targa = value; }
    }
    public Auto(string targa)
    {
        Targa = targa;
    }

    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }

    public void StampaDettagli()
    {
        Console.WriteLine($"Auto con targa: {Targa}");
    }
}

public class Moto : IVeicolo
{
    private string _targa;

    public string Targa
    {
        get { return _targa; }
        set { _targa = value; }
    }
    public Moto(string targa)
    {
        Targa = targa;
    }

    public void Avvia()
    {
        Console.WriteLine("Avvio della moto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }

    public void StampaDettagli()
    {
        Console.WriteLine($"Moto con targa: {Targa}");
    }
}

public class Camion : IVeicolo
{
    private string _targa;

    public string Targa
    {
        get { return _targa; }
        set { _targa = value; }
    }
    public Camion(string targa)
    {
        Targa = targa;
    }

    public void Avvia()
    {
        Console.WriteLine("Avvio del camion");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }

    public void StampaDettagli()
    {
        Console.WriteLine($"Camion con targa: {Targa}");
    }
}

public static class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo, string targa)
    {
        switch (tipo.ToLower())
        {
            case "auto":
                return new Auto(targa);

            case "moto":
                return new Moto(targa);

            case "camion":
                return new Camion(targa);

            default:
                return null;
        }
    }
}

public sealed class RegistroVeicoli
{
    private List<IVeicolo> _autoCreate = new List<IVeicolo>();
    private List<IVeicolo> _motoCreate = new List<IVeicolo>();
    private List<IVeicolo> _camionCreati = new List<IVeicolo>();

    private static RegistroVeicoli _instance;

    private RegistroVeicoli() { }

    public static RegistroVeicoli Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RegistroVeicoli();
            }
            return _instance;
        }
    }

    public void Registra(IVeicolo veicolo)
    {
        switch (veicolo.ToString())
        {
            case "Auto":
                _autoCreate.Add(veicolo);
                break;

            case "Moto":
                _motoCreate.Add(veicolo);
                break;

            case "Camion":
                _camionCreati.Add(veicolo);
                break;
        }
    }

    public void StampaAuto()
    {
        foreach (IVeicolo veicolo in _autoCreate)
        {
            veicolo.StampaDettagli();
        }
    }

    public void StampaMoto()
    {
        foreach (IVeicolo veicolo in _motoCreate)
        {
            veicolo.StampaDettagli();
        }
    }

    public void StampaCamion()
    {
        foreach (IVeicolo veicolo in _camionCreati)
        {
            veicolo.StampaDettagli();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        RegistroVeicoli registroVeicoli = RegistroVeicoli.Instance;

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Aggiungi Veicolo");
            Console.WriteLine("[2] Stampa dettagli Auto");
            Console.WriteLine("[3] Stampa dettagli Moto");
            Console.WriteLine("[4] Stampa dettagli Camion");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 4);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nInserisci tipo (auto, moto, camion): ");
                    string tipo = Input.String();
                    Console.Write("Inserisci targa: ");
                    string targa = Input.String();
                    IVeicolo veicolo = VeicoloFactory.CreaVeicolo(tipo, targa);
                    registroVeicoli.Registra(veicolo);
                    break;
        
                case 2:
                    Console.WriteLine("\nAuto: ");
                    registroVeicoli.StampaAuto();
                    break;
                
                case 3:
                    Console.WriteLine("\nMoto: ");
                    registroVeicoli.StampaMoto();
                    break;

                case 4:
                    Console.WriteLine("\nCamion: ");
                    registroVeicoli.StampaCamion();
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}