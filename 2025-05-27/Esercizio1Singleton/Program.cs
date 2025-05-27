using System;

public sealed class Singleton_Logger
{
    private static Singleton_Logger _instance;

    private Singleton_Logger() { }

    public static Singleton_Logger getInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton_Logger();
        }
        return _instance;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"{DateTime.Now}: {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Singleton_Logger logger1 = Singleton_Logger.getInstance();
        Singleton_Logger logger2 = Singleton_Logger.getInstance();

        Console.WriteLine("");
        logger1.ScriviMessaggio("Messaggio 1");
        logger2.ScriviMessaggio("Messaggio 2");

        Console.WriteLine("");
        Console.WriteLine($"hashcode logger 1: {logger1.GetHashCode()}");
        Console.WriteLine($"hashcode logger 2: {logger2.GetHashCode()}");
    }
}