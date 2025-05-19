using System;

class Program
{
    static void Main(string[] args)
    {

        Studente studente1 = new Studente("", 0, 0);
        Studente studente2 = new Studente("", 0, 0);


        for (int i = 0; i < 2; i++)
        {
            Console.Write($"\nStudente {i + 1}\nInserire il nome: ");
            string nome = Input.String();
            Console.Write("Inserire la matricola: ");
            int matricola = Input.Int();
            Console.Write("Inserire la media dei voti: ");
            double mediaVoti = Input.Int(0, 30);

            if (i == 0)
            {
                studente1.Nome = nome;
                studente1.Matricola = matricola;
                studente1.MediaVoti = mediaVoti;
            }
            else
            {
                studente2.Nome = nome;
                studente2.Matricola = matricola;
                studente2.MediaVoti = mediaVoti;
            }
        }

        Console.WriteLine($"\nStudente: {studente1.Nome}, matricola: {studente1.Matricola}, media voti: {studente1.MediaVoti}");
        Console.WriteLine($"\nStudente: {studente2.Nome}, matricola: {studente2.Matricola}, media voti: {studente2.MediaVoti}");
    }
}

public class Studente
{
    public string Nome;
    public int Matricola;
    public double MediaVoti;

    public Studente(string nome, int matricola, double mediaVoti)
    {
        Nome = nome;
        Matricola = matricola;
        MediaVoti = mediaVoti;
    }
}