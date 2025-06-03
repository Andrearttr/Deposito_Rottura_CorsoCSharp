public interface ILogger
{
    void Log(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class Printer
{
    public ILogger Logger { get; set; }

    public void Print(string message)
    {
        if (Logger == null)
        {
            Console.WriteLine("Logger non impostato");
        }
        else
        {
            Logger.Log(message);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var logger = new Logger();
        var printer = new Printer();

        printer.Print("Prova senza logger");

        printer.Logger = logger;

        printer.Print("prova con logger");
    }
}