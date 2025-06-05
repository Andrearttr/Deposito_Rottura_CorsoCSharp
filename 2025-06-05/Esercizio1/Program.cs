using System;

public class Program
{
    private enum GiornoSettimana { Lunedì, Martedì, Mercoledì, Giovedì, Venerdì, Sabato, Domenica }
    public static void Main(string[] args)
    {
        GiornoSettimana giorno = GiornoSettimana.Lunedì;

        switch (giorno)
        {
            case GiornoSettimana.Lunedì:
                Console.WriteLine("Oggi è Lunedì");
                break;
            case GiornoSettimana.Martedì:
                Console.WriteLine("Oggi è Martedì");
                break;
            case GiornoSettimana.Mercoledì:
                Console.WriteLine("Oggi è Mercoedì");
                break;
            case GiornoSettimana.Giovedì:
                Console.WriteLine("Oggi è Giovedì");
                break;
            case GiornoSettimana.Venerdì:
                Console.WriteLine("Oggi è Venerdì");
                break;
            case GiornoSettimana.Sabato:
                Console.WriteLine("Oggi è Sabato");
                break;
            case GiornoSettimana.Domenica:
                Console.WriteLine("Oggi è Domenica");
                break;
        }
    }
}