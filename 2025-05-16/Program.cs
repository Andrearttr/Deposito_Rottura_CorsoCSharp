using System;
using System.IO.Pipelines;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        //Es1Somma();
        //Es2Analizza();
        //Es3DueNumeri();
        //Es4Dividi();
        //Es5CinqueNum();
    }

    //---------------------------------------------------------------------

    static void Es1Somma()
    {
        Console.WriteLine($"{Somma(2, 5)}");
        Console.WriteLine($"{Somma(2.5, 5.3)}");
        Console.WriteLine($"{Somma(2, 5, 4)}");
    }

    static int Somma(int x, int y)
    {
        return x + y;
    }

    static double Somma(double x, double y)
    {
        return x + y;
    }

    static int Somma(int x, int y, int z)
    {
        return x + y + z;
    }

    //---------------------------------------------------------------------

    static void Es2Analizza()
    {
        string testo = "Ciao a tutti";

        Analizza(testo);
        Analizza(testo, 't');
        Analizza(testo, true);
    }

    static void Analizza(string testo)
    {
        string noSpazi = testo.Replace(" ", "");
        Console.WriteLine($"Il testo contiene {noSpazi.Length} caratteri");
    }

    static void Analizza(string testo, char carattere)
    {
        int numCar = 0;

        foreach (char c in testo)
        {
            if (c == carattere)
            {
                numCar++;
            }
        }

        Console.WriteLine($"Il testo contiene {carattere} {numCar} volte");
    }

    static void Analizza(string testo, bool contaVocali)
    {
        int numVoc = 0;
        int numCons = 0;
        string vocali = "aeiou";

        foreach (char c in testo)
        {
            if (vocali.Contains(char.ToLower(c)))
            {
                numVoc++;
            }
            else if (char.IsLetter(c))
            {
                numCons++;
            }
        }

        if (contaVocali)
        {
            Console.WriteLine($"Il testo contiene {numVoc} vocali");
        }
        else
        {
            Console.WriteLine($"Il testo contiene {numCons} consonanti");
        }
    }

    //---------------------------------------------------------------------

    static void Es3DueNumeri()
    {
        DueNumeri(out int num1, out int num2);
        Console.WriteLine($"\nNumeri:\n{num1}\n{num2}");
    }

    static void DueNumeri(out int num1, out int num2)
    {
        num1 = 0;
        num2 = 0;

        for (int i = 0; i < 2; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write("\nInserisci un numero: ");
                    if (i == 0)
                    {
                        num1 = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        num2 = int.Parse(Console.ReadLine());
                    }
                    break;
                }
                catch
                {
                    Console.Write("\nNumero non valido");
                }
            }

        }
    }

    //---------------------------------------------------------------------

    static void Es4Dividi()
    {
        bool error = false;
        DueNumeri(out int num1, out int num2);
        int result = Dividi(num1, num2, out error);

        if (!error)
        {
            Console.WriteLine($"\nIl risultato è {result}");
        }
    }

    static int Dividi(int num1, int num2, out bool error)
    {
        try
        {
            int result = num1 / num2;
            error = false;
            return result;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("\nErrore: impossibile dividere per zero");
            error = true;
            return 0;
        }
    }

    //---------------------------------------------------------------------

    static void Es5CinqueNum()
    {
        CinqueNum();
    }

    static void CinqueNum()
    {
        int somma = 0;

        for (int i = 0; i < 5; i++)
        {
            try
            {
                Console.Write($"Inserisci il {i+1}° numero: ");
                somma += int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Numero non valido");
            }
        }

        Console.WriteLine($"\nLa somma è: {somma}");
    }

}