using System;

public class Program
{
    static void Main(string[] args)
    {
        ContoBancario conto = new ContoBancario();
        conto.Saldo = 1000; //imposta il saldo tramite la proprieta set
        Console.WriteLine(conto.Saldo); //legge il saldo tramite la proprieta get

        conto.Saldo = -500; //valore non valido non viene impostato
        Console.WriteLine(conto.Saldo); //il saldo resta 1000

        conto.Deposita(1000); //modifica il saldo tramite il metodo deposita
        Console.WriteLine(conto.OttieniSaldo()); //
    }
}

public class ContoBancario
{
    //campo privato
    private double saldo;

    //proprieta pubblica per accedere al saldo
    public double Saldo
    {
        get //permette la lettura del saldo
        {
            return saldo;
        }
        set //permette di settare il saldo
        {
            if (value >= 0) //permette di settare solo valori validi
            {
                saldo = value;
            }
        }
    }

    private string? nome;

    //proprieta auto implementata, utile se non servono condizioni
    public string Nome { get; private set; }    //è possibile mettere get e set privati per vietarne l'accesso esterno

    //se non si vuole utilizzare get set è possibile creare dei metodi pubblici che restituiscono gli attributi privati
    public double OttieniSaldo()
    {
        return saldo;
    }

    public void Deposita(double importo)
    {
        if (importo >= 0)
        {
            saldo += importo;
        }
    }
}