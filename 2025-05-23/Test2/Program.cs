using System;

//classe conto
public class ContoCorrente
{
    //attributi private
    private decimal saldo = 0;
    private int numeroOperazioni = 0;

    //proprietà pubbliche
    public decimal Saldo
    {
        get { return saldo; }
    }
    public int NumeroOperazioni
    {
        get { return numeroOperazioni; }
    }

    //funzioni deposito e ritiro
    public void Versa(decimal importo)
    {
        saldo += importo;
        numeroOperazioni++;
    }

    public void Preleva(decimal importo)
    {
        if (saldo >= importo)   //controlla se il saldo è abbastanza per il ritiro
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

        //menu selezione azioni
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
                case 0: //esci
                    exit = true;
                    break;

                case 1: //deposita
                    Console.Write("\nInserisci l'importo: ");
                    decimal importo = Input.Decimal();
                    conto.Versa(importo);
                    break;

                case 2: //ritira
                    Console.Write("\nInserisci l'importo: ");
                    importo = Input.Decimal();
                    conto.Preleva(importo);
                    break;
            }
        }
    }
}