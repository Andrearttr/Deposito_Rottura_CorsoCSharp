using System;

public class VoloAereo
{
    const int maxPosti = 150;

    private string codiceVolo;
    public string CodiceVolo { get; set; }

    private int postiOccupati;
    public int PostiOccupati
    {
        get
        {
            return postiOccupati;
        }
    }

    private int postiLiberi;
    public int PostiLiberi
    {
        get
        {
            return maxPosti - postiOccupati;
        }
    }

    public VoloAereo(string Codice)
    {
        CodiceVolo = Codice;
    }
    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= PostiLiberi && numeroPosti > 0)
        {
            postiOccupati += numeroPosti;
            Console.WriteLine($"{numeroPosti} posti prenotati.");
        }
        else
        {
            Console.WriteLine($"Posti non disponibili.");
        }
    }

    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= postiOccupati && numeroPosti > 0)
        {
            postiOccupati -= numeroPosti;
            Console.WriteLine($"{numeroPosti} posti annullati.");
        }
        else
        {
            Console.WriteLine($"Posti non disponibili.");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Codice volo: {CodiceVolo}, posti occupati: {PostiOccupati}, posti liberi: {PostiLiberi}");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        VoloAereo volo = new VoloAereo("AE2057B");
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nBenvenuto nel sistema di prenotazione:\n[1] Effettua Prenotazione\n[2] Annulla Prenotazione\n[3] Visualizza informazioni volo\n[0] Esci\n");
            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 0:
                    exit = true;
                    break;

                case 1:
                    Console.Write("Inserisci il numero di posti da prenotare: ");
                    int aggiungiPosti = Input.Int();
                    volo.EffettuaPrenotazione(aggiungiPosti);
                    volo.VisualizzaStato();
                    break;

                case 2:
                    Console.Write("Inserisci il numero di posti da annullare: ");
                    int annullaPosti = Input.Int();
                    volo.AnnullaPrenotazione(annullaPosti);
                    volo.VisualizzaStato();
                    break;

                case 3:
                    volo.VisualizzaStato();
                    break;


            }
        }


    }
}