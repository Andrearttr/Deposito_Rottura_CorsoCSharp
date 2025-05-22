using System;

public class Program
{
    public static void Main(string[] args)
    {
        PrenotazioneViaggio viaggio = new PrenotazioneViaggio();
        Console.Write($"Scegli una destinazione: ");
        viaggio.Destinazione = Input.String();
        viaggio.StampaInfo();
        viaggio.PrenotaPosti(10);
        viaggio.StampaInfo();
        viaggio.AnnullaPrenotazione(5);
        viaggio.StampaInfo();
        
    }
}

public class PrenotazioneViaggio
{
    private const int maxPosti = 20;

    private string destinatione;
    public string Destinazione { get; set; }
    private int postiDisponibili;
    public int PostiDisponibili
    {
        get { return maxPosti - postiPrenotati; }
    }
    private int postiPrenotati = 0;
    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }

    public void PrenotaPosti(int numero)
    {
        if (PostiDisponibili > 0)
        {
            postiPrenotati += numero;
            Console.WriteLine($"{numero} posti prenotati.");
        }
        else
        {
            Console.WriteLine("Posti non disponibili");
        }
    }

    public void AnnullaPrenotazione(int numero)
    {
        if (numero <= postiPrenotati)
        {
            postiPrenotati -= numero;
            Console.WriteLine($"{numero} posti annullati.");
            
        }
    }

    public void StampaInfo()
    {
        Console.WriteLine($"\nDestinazione: {Destinazione}, posti disponibili: {PostiDisponibili}, posti prenotati: {PostiPrenotati}");
    }

}