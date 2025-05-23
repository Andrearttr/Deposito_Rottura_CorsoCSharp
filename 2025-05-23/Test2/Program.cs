using System;

public class ContoCorrente
{
    private decimal saldo = 0;
    private int numeroOperazioni = 0;

    public decimal Saldo
    {
        get { return saldo; }
    }
    public int NumeroOperazioni
    {
        get { return numeroOperazioni; }
    }

    public void Versa(decimal importo)
    {
        saldo += importo;
        numeroOperazioni++;
    }

    public void Preleva(decimal importo)
    {
        if (saldo >= importo)
        {
            saldo -= importo;
            numeroOperazioni++;
        }
        else
        {
            Console.WriteLine("Saldo non sufficiente.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;
        ContoCorrente conto = new ContoCorrente();

        
        while (!exit)
        {

            Console.WriteLine($"\nSaldo: {conto.Saldo}\nOperazioni effettuate: {conto.NumeroOperazioni}");
            Console.WriteLine("\nBenvenuto, seleziona l'operazione da eseguire");
            Console.WriteLine("[1] Deposita");
            Console.WriteLine("[2] Preleva");
            Console.WriteLine("[0] Esci");
            int menuAction = Input.Int(0, 2);

            switch (menuAction)
            {
                case 0:
                    exit = true;
                    break;

                case 1:
                    Console.Write("\nInserisci l'importo: ");
                    decimal importo = Input.Decimal();
                    conto.Versa(importo);
                    break;

                case 2:
                    Console.Write("\nInserisci l'importo: ");
                    importo = Input.Decimal();
                    conto.Preleva(importo);
                    break;
            }
        }
    }
}