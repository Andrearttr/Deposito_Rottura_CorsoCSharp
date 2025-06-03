using System;

public interface IExportFormatter
{
    void Export(string file);
}

public class JsonExporter : IExportFormatter
{
    public void Export(string file)
    {
        Console.WriteLine($"{file} esportato come .Json");
    }
}

public class XmlExporter : IExportFormatter
{
    public void Export(string file)
    {
        Console.WriteLine($"{file} esportato come .xml");
    }
}

public class DataExporter
{
    public void Export(string file, IExportFormatter exportFormatter)
    {
        exportFormatter.Export(file);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var jsonExporter = new JsonExporter();
        var xmlExporter = new XmlExporter();
        var dataExporter = new DataExporter();

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Esporta in .json");
            Console.WriteLine("[2] Esporta in .xml");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int();
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("Inserisci file: ");
                    string file = Input.String();
                    dataExporter.Export(file, jsonExporter);
                    break;
        
                case 2:
                    Console.Write("Inserisci file: ");
                    file = Input.String();
                    dataExporter.Export(file, xmlExporter);
                    break;
        
                case 0:
                    exit = true;
                    break;
            }
        }
    }
}