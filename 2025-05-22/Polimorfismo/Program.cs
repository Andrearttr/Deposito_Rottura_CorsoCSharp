using System;

//classe base con metodo virtuale
public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

//classe derivata con override del metodo
public class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il cane abbaia.");
    }
}

//altra classe derivata con override del metodo
public class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il gatto miagola.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //lista animali
        List<Animale> animali = new List<Animale>();
        animali.Add(new Cane());
        animali.Add(new Gatto());

        //grazie al polimorfismo ogni oggetto chiama la sua versione di FaiVerso()
        foreach (Animale animale in animali)
        {
            animale.FaiVerso();
        }

        Animale a = new Cane();
        if (a is Cane)
        {
            ((Cane)a).FaiVerso();
        }
    }
}