using System;

public class Program
{
    public static void Main(string[] args)
    {
        var list = GeneraLista(100000);
        var nome = "pippo";
        var index = CercaElemento(nome, list);
        Console.WriteLine($"{nome} trovato in indice: {index}");
    }

    public static List<String> GeneraLista(int size)
    {
        List<String> lista = new List<string>(); //genera una lista vuota
        Random rand = new Random();

        for (int i = 0; i < size; i++)  //itera per la grandezza passata nella funzione
        {
            int stringlen = rand.Next(4, 10);   //inizio generazione stringa casuale
            int randValue;
            string str = "";
            char letter;
            for (int x = 0; x < stringlen; x++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }

            lista.Add(str.ToLower());   //fine generazione stringa casuale e aggiunta alla lista
        }

        lista.Add("pippo");
        lista.Sort();   //ordinamento lista

        return lista;   //restituisce lista
    }

    public static int CercaElemento(string elemento, List<string> lista)
    {
        int min = 0;
        int max = lista.Count - 1;
        int passes = 0;

        while (true)
        {
            int half = (max + min) / 2; //calcola la metà
            int compare = string.Compare(elemento, lista[half]);    //compara la stringa da cercare a quella a metà

            if (compare > 0)    //se il target si trova dopo la metà aggiorna il minimo
            {
                min = half;
            }
            else if (compare < 0)   //se il target si trova prima della metà aggiorna il massimo
            {
                max = half;
            }
            else if (compare == 0)  //se il target combacia con la metà restitusce l'indice
            {
                return half;
            }

            passes++;
            Console.WriteLine($"passes: {passes}");
        }
    }
}