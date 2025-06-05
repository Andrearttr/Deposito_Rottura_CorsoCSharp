using System;

public class Program
{
    private enum LivelloAccesso { Ospite, Utente, Amministratore }
    public static void Main(string[] args)
    {
        Console.Write("Inserisci il livello di accesso (0.Ospite, 1.Utente, 2.Amministratore): ");
        int livello = int.Parse(Console.ReadLine());

        switch (livello)
        {
            case (int)LivelloAccesso.Ospite:
                StampaPrivilegi(LivelloAccesso.Ospite);
                break;

            case (int)LivelloAccesso.Utente:
                StampaPrivilegi(LivelloAccesso.Utente);
                break;

            case (int)LivelloAccesso.Amministratore:
                StampaPrivilegi(LivelloAccesso.Amministratore);
                break;
        }
    }

    private static void StampaPrivilegi(LivelloAccesso livelloAccesso)
    {
        switch (livelloAccesso)
        {
            case LivelloAccesso.Ospite:
                Console.WriteLine("\nPrivilegi disponibili per ospite:");
                Console.WriteLine("- Visualizzazione elementi");
                break;

            case LivelloAccesso.Utente:
                Console.WriteLine("\nPrivilegi disponibili per utente:");
                Console.WriteLine("- Visualizzazione elementi");
                Console.WriteLine("- Creazione e modifica elementi personali");
                break;
            
            case LivelloAccesso.Amministratore:
                Console.WriteLine("\nPrivilegi disponibili per amministratore:");
                Console.WriteLine("- Visualizzazione elementi");
                Console.WriteLine("- Creazione e modifica elementi personali");
                Console.WriteLine("- Gestione utenti");
                break;
        }
    }
}