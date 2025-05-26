using System;

//interfaccia con due metodi vuoti da ereditare
public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

//classe che inerita dall'interfaccia
public class PagamentoCarta : IPagamento
{
    private string _circuito;

    public string Circuito
    {
        get { return _circuito; }
        set { _circuito = value; }
    }

    public PagamentoCarta(string circuito)
    {
        Circuito = circuito;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro con carta: {Circuito}.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine($"Carta di credito: {Circuito}.");
    }
}

public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro in contanti.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti.");
    }
}

public class PagamentoPayPal : IPagamento
{
    private string _emailUtente;

    public string EmailUtente
    {
        get { return _emailUtente; }
        set { _emailUtente = value; }
    }

    public PagamentoPayPal(string emailUtente)
    {
        EmailUtente = emailUtente;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro tramite PayPal da: {EmailUtente}.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine($"PayPal: {EmailUtente}.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<IPagamento> pagamenti = new List<IPagamento>();
        bool exit = false;
        
        // ciclo principale del menù
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Aggiungi carta");
            Console.WriteLine("[2] Aggiungi PayPal");
            Console.WriteLine("[3] Aggiungi contanti");
            Console.WriteLine("[4] Effettua pagamento");
            Console.WriteLine("[5] Visualizza metodi");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 5);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nIsnerisci circuito: ");
                    string circuito = Input.String();
                    pagamenti.Add(new PagamentoCarta(circuito));
                    Console.WriteLine("Carta aggiunta");
                    break;
        
                case 2:
                    Console.Write("\nIsnerisci email: ");
                    string email = Input.String();
                    pagamenti.Add(new PagamentoPayPal(email));
                    Console.WriteLine("PayPal aggiunto");
                    break;
        
                case 3:
                    pagamenti.Add(new PagamentoContanti());
                    Console.WriteLine("Contanti aggiunti");
                    break;
        
                case 4:
                    int i = 0;
                    Console.WriteLine("\nSeleziona metodo:");
                    foreach (IPagamento p in pagamenti) //stampa lista metodi
                    {
                        Console.Write($"[{i}] ");
                        p.MostraMetodo();
                        i++;
                    }
                    int metodo = Input.Int();   //seleziona metodo
                    Console.Write("\nIsnerisci importo in euro: ");
                    decimal importo = Input.Decimal();
                    pagamenti[metodo].EseguiPagamento(importo);
                    break;

                case 5:
                    Console.WriteLine("\nMetodi di pagamento: ");
                    foreach (IPagamento p in pagamenti)
                    {
                        p.MostraMetodo();
                    }
                    break;
        
                case 0:
                    exit = true;
                    break;
            }
        }
    }
}