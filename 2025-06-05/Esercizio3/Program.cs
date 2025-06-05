using System;

public class Program
{
    private enum TipoTransazione { Acquisto, Rimborso, Trasferimento }
    public static void Main(string[] args)
    {   
        Console.Write("Inserisci tipo di transazione (0.Acquisto, 1.Rimborso, 2.Trasferimento): ");
        int tipo = int.Parse(Console.ReadLine());

        switch (tipo)
        {
            case (int)TipoTransazione.Acquisto:
                Console.WriteLine($"Commissioni: {CalcolaCommissioni(TipoTransazione.Acquisto)} euro");
                break;

            case (int)TipoTransazione.Rimborso:
                Console.WriteLine($"Commissioni: {CalcolaCommissioni(TipoTransazione.Rimborso)} euro");
                break;

            case (int)TipoTransazione.Trasferimento:
                Console.WriteLine($"Commissioni: {CalcolaCommissioni(TipoTransazione.Trasferimento)} euro");
                break;
        }
        
    }

    private static double CalcolaCommissioni(TipoTransazione tipoTransazione) {
        switch (tipoTransazione)
        {
            case TipoTransazione.Acquisto:
                return 1d;
            case TipoTransazione.Rimborso:
                return 0.5d;
            case TipoTransazione.Trasferimento:
                return 1.5d;
            default:
                return 0;
        }
    }
}