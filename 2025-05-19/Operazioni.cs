
class Operazioni
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Scegli l'operazione:\n\n[1] Somma\n[2] Moltiplicazione\n[3] Divisione\n");
        int operazione = Input.Int();

        Console.Write("\nInserisci il primo numero: ");
        int num1 = Input.Int();
        Console.Write("\nInserisci il secondo numero: ");
        int num2 = Input.Int();

        switch (operazione)
        {
            case 1:
                int somma = Somma(num1, num2);
                StampaRisultato("somma", somma);
                break;
            case 2:
                int prodotto = Moltiplica(num1, num2);
                StampaRisultato("Moltiplicazione", prodotto);
                break;
            case 3:
                double quoziente = Dividi(num1, num2, out bool dbzError);
                if (!dbzError)
                {
                    StampaRisultato("divisione", quoziente);
                }
                else
                {
                    Console.WriteLine("\nErrore: impossibile dividere per zero.");
                }
                break;
        }
        
    }

    public static int Somma(int a, int b)
    {
        return a + b;
    }

    public static int Moltiplica(int a, int b)
    {
        return a * b;
    }

    public static void StampaRisultato(string operazione, double risultato)
    {
        Console.WriteLine($"\nIl risultato della {operazione} è: {risultato}");
    }

    public static int Dividi(int a, int b, out bool error)
    {
        try
        {
            error = false;
            return a / b;
        }
        catch (DivideByZeroException)
        {
            error = true;
            return 0;
        }
    }
}