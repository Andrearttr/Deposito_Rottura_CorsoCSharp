using System;

class Program
{
    static void Main(string[] args)
    {
        Persona persona1 = new Persona("", "", 0);
        Persona persona2 = new Persona("", "", 0);

        for (int i = 0; i < 2; i++)
        {
            Console.Write($"\nPersona {i + 1}\nInserire il nome: ");
            string nome = Input.String();
            Console.Write("Inserire il cognome: ");
            string cognome = Input.String();
            Console.Write("Inserire l'anno di nascita: ");
            int annoNascita = Input.Int();

            if (i == 0)
            {
                persona1.Nome = nome;
                persona1.Cognome = cognome;
                persona1.AnnoNascita = annoNascita;
            }
            else
            {
                persona2.Nome = nome;
                persona2.Cognome = cognome;
                persona2.AnnoNascita = annoNascita;
            }
        }

        Console.WriteLine($"\n{persona1}");
        Console.WriteLine($"\n{persona2}");
    }
}

class Persona
{
    public string Nome;
    public string Cognome;
    public int AnnoNascita;

    public Persona(string nome, string cognome, int annoNascita)
    {
        Nome = nome;
        Cognome = cognome;
        AnnoNascita = annoNascita;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Cognome: {Cognome}, Anno di nascita: {AnnoNascita}";
    }
}