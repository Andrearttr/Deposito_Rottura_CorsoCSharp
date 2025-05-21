using System;

class Program
{
    static void Main(string[] args)
    {
        List<Film> raccolta = new List<Film>();

        while (true)
        {
            AggiungiFilm(out string titolo, out string regista, out int anno, out string genere);
            raccolta.Add(new Film(titolo, regista, anno, genere));

            if (raccolta.Count >= 3)
            {
                Console.Write("\nVuoi agigungere un'altro film?(1:si/2:no): ");
                int continua = Input.Int(1, 2);
                if (continua == 2)
                {
                    break;
                }
            }
        }

        bool exitMenu = false;
        while (!exitMenu)
        {
            Console.WriteLine("\nCosa vuoi fare?\n[1] Aggiungi film\n[2] Rimuovi film\n[3] Cerca film\n[4] Mostra raccolta\n[5] Esci\n");
            int azione = Input.Int(1, 5);
            switch (azione)
            {
                case 1:
                    AggiungiFilm(out string titolo, out string regista, out int anno, out string genere);
                    raccolta.Add(new Film(titolo, regista, anno, genere));
                    break;

                case 2:
                    Console.Write("\nInserisci il titolo del film da rimuovere: ");
                    string removefilm = Input.String().ToLower();
                    foreach (Film film in raccolta)
                    {
                        if (film.Titolo.ToLower() == removefilm)
                        {
                            raccolta.Remove(film);
                            break;
                        }
                    }
                    break;

                case 3:
                    Console.Write("\nChe cosa vuoi cercare?\n[1] Titolo\n[2] Regista\n[3] Anno\n[4] Genere");
                    int azioneCerca = Input.Int(1, 4);
                    Cerca(raccolta, azioneCerca);
                    break;

                case 4:
                    Console.WriteLine("\nFilm nella raccolta:");
                    foreach (Film film in raccolta)
                    {
                        film.StampaInfo();
                    }
                    break;

                case 5:
                    exitMenu = true;
                    break;

            }
        }
    }

    static void Cerca(List<Film> raccolta, int tipo)
    {
        switch (tipo)
        {
            case 1:
                Console.Write("\nChe titolo vuoi cercare?: ");
                string titolo = Input.String();
                Console.WriteLine($"\nFilm con titolo {titolo}:");

                foreach (Film film in raccolta)
                {
                    if (film.Titolo.ToLower() == titolo.ToLower())
                    {
                        film.StampaInfo();
                    }
                }
                break;

            case 2:
                Console.Write("\nChe regista vuoi cercare?: ");
                string regista = Input.String();
                Console.WriteLine($"\nFilm con regista {regista}:");

                foreach (Film film in raccolta)
                {
                    if (film.Regista.ToLower() == regista.ToLower())
                    {
                        film.StampaInfo();
                    }
                }
                break;

            case 3:
                Console.Write("\nChe anno vuoi cercare?: ");
                int anno = Input.Int();
                Console.WriteLine($"\nFilm con regista {anno}:");

                foreach (Film film in raccolta)
                {
                    if (film.Anno == anno)
                    {
                        film.StampaInfo();
                    }
                }
                break;

            case 4:
                Console.Write("\nChe genere vuoi cercare?: ");
                string genere = Input.String();
                Console.WriteLine($"\nFilm con genere {genere}:");

                foreach (Film film in raccolta)
                {
                    if (film.Genere.ToLower() == genere.ToLower())
                    {
                        film.StampaInfo();
                    }
                }
                break;
        }
    }


    static void AggiungiFilm(out string titolo, out string regista, out int anno, out string genere)
    {
        Console.Write("\nAggiunta nuovo film\nAggiungi il titolo: ");
        titolo = Input.String();
        Console.Write("Aggiungi il regista: ");
        regista = Input.String();
        Console.Write("Aggiungi l'anno: ");
        anno = Input.Int();
        Console.Write("Aggiungi il genere: ");
        genere = Input.String();
    }
}

class Film
{
    public string Titolo;
    public string Regista;
    public int Anno;
    public string Genere;

    public Film(string titolo, string regista, int anno, string genere)
    {
        Titolo = titolo;
        Regista = regista;
        Anno = anno;
        Genere = genere;
    }

    public  void StampaInfo()
    {
        Console.WriteLine($"Titolo: {Titolo}, Regista: {Regista}, Anno: {Anno}, Genere: {Genere}");
    }
}