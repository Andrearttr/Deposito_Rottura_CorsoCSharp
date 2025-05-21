using System;

//classe base
public class Animale
{
    protected int età;                  //protected rende la variabile visibile solo ai figli
    public virtual void FaiVerso()      //virtual rende una classe sovrascrivibile dalla derivata
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

//classe derivata
public class Cane : Animale
{
    public void Scodinzola()
    {
        Console.WriteLine("Il cane scodinzola.");
    }

    public override void FaiVerso()     //override di una classe virtuale della classe base
    {
        base.FaiVerso();                //base usa il metodo originale della classe base
        Console.WriteLine("Il cane abbaia.");
    }
}

public class Gatto : Animale
{
    public new void FaiVerso()          //new nasconde la classe base e ne crea una nuova
    {
        Console.WriteLine("Il gatto miagola.");
    }
}

public sealed class Uccello : Animale   //sealed impedisce alla classe Uccello di essere ereditata ulteriormente
{

}

public class Program
{
    public static void Main(string[] args)
    {
        Cane mioCane = new Cane();      //creazione oggetto della classe derivata
        mioCane.FaiVerso();             //metodo ereditato dalla classe base + override
        mioCane.Scodinzola();           //metodo definito nella classe derivata
        Gatto mioGatto = new Gatto();
        mioGatto.FaiVerso();            //metodo new
    }
}