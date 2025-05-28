using System;

public sealed class ConfigurazioneSistema
{
    private ConfigurazioneSistema() { }

    private static ConfigurazioneSistema _instance;

    private Dictionary<string, string> _keyValuePairs = new Dictionary<string, string>();

    public static ConfigurazioneSistema Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurazioneSistema();
            }
            return _instance;
        }
    }

    public void Imposta(string key, string value)
    {
        if (_keyValuePairs.ContainsKey(key))
        {
            _keyValuePairs[key] = value;
        }
        else
        {
            _keyValuePairs.Add(key, value);
        }
    }

    public string Leggi(string key)
    {
        if (_keyValuePairs.ContainsKey(key))
        {
            return _keyValuePairs[key];
        }
        else
        {
            return "Chiave inesistente";
        }
    }

    public void StampaTutte()
    {
        Console.WriteLine("\nConfigurazioni:");
        foreach (string key in _keyValuePairs.Keys)
        {
            Console.WriteLine($"{key}: {_keyValuePairs[key]}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ConfigurazioneSistema moduloA = ConfigurazioneSistema.Instance;
        ConfigurazioneSistema moduloB = ConfigurazioneSistema.Instance;

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Configura ModuloA");
            Console.WriteLine("[2] Configura ModuloB");
            Console.WriteLine("[3] Stampa configurazioni");
            Console.WriteLine("[4] Confronta moduli");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 4);

            switch (menuAction)
            {
                case 1:
                    Console.Write("\nInserisci la chiave: ");
                    string key = Input.String();
                    Console.Write("\nInserisci il valore: ");
                    string value = Input.String();
                    moduloA.Imposta(key, value);
                    break;

                case 2:
                    Console.Write("\nInserisci la chiave: ");
                    key = Input.String();
                    Console.Write("\nInserisci il valore: ");
                    value = Input.String();
                    moduloB.Imposta(key, value);
                    break;

                case 3:
                    ConfigurazioneSistema.Instance.StampaTutte();
                    break;

                case 4:
                    Console.Write("\nInserisci la chiave: ");
                    key = Input.String();
                    Console.WriteLine($"Uguali: {moduloA.Leggi(key).Equals(moduloB.Leggi(key))}");
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}