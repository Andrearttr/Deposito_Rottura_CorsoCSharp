using System;

//classe base veicolo
public class Veicolo
{
    //proprietà pubbliche
    public string Marca { get; set; }
    public string Modello { get; set; }
    public int AnnoImmatricolazione { get; set; }

    //costruttore
    public Veicolo(string marca, string modello, int annoImmatricolazione)
    {
        Marca = marca;
        Modello = modello;
        AnnoImmatricolazione = annoImmatricolazione;
    }

    //stampa le proprietà del veicolo
    public virtual void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, modello: {Modello}, anno immatricolazione: {AnnoImmatricolazione}");
    }

}

//classe derivata auto
public class AutoAziendale : Veicolo
{
    //proprietà pubbliche della derivata
    public string Targa { get; set; }
    public bool UsoPrivato { get; set; }

    //costruttore derivata
    public AutoAziendale(string marca, string modello, int annoImmatricolazione, string targa, bool usoPrivato) : base(marca, modello, annoImmatricolazione)
    {
        Targa = targa;
        UsoPrivato = usoPrivato;
    }

    //override stampainfo
    public override void StampaInfo()
    {
        string usoPrivatoString;
        if (UsoPrivato)
        {
            usoPrivatoString = "si";
        }
        else
        {
            usoPrivatoString = "no";
        }
        Console.WriteLine($"Marca: {Marca}, modello: {Modello}, anno immatricolazione: {AnnoImmatricolazione}, targa {Targa}, uso privato: {usoPrivatoString}");
    }
}

//classe derivata furgone
public class FurgoneAziendale : Veicolo
{
    //proprietà pubbliche della derivata
    public int CapacitaCarico { get; set; }

    //costruttore
    public FurgoneAziendale(string marca, string modello, int annoImmatricolazione, int capacitaCarico) : base(marca, modello, annoImmatricolazione)
    {
        CapacitaCarico = capacitaCarico;
    }

    //override stampainfo
    public override void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, modello: {Modello}, anno immatricolazione: {AnnoImmatricolazione}, capacità carico: {CapacitaCarico}kg");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>(); //lista dei veicoli

        veicoli.Add(new AutoAziendale("bmw", "mn12", 2008, "ie23y46b", true));
        veicoli.Add(new FurgoneAziendale("Audi", "scm2", 2012, 3000));

        foreach (Veicolo v in veicoli) //stampa tutte le info
        {
            v.StampaInfo();
        }
    }
}