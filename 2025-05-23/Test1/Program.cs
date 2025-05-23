using System;

public class Veicolo
{
    public string Marca { get; set; }
    public string Modello { get; set; }
    public int AnnoImmatricolazione { get; set; }

    public Veicolo(string marca, string modello, int annoImmatricolazione)
    {
        Marca = marca;
        Modello = modello;
        AnnoImmatricolazione = annoImmatricolazione;
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, modello: {Modello}, anno immatricolazione: {AnnoImmatricolazione}");
    }

}

public class AutoAziendale : Veicolo
{
    public string Targa { get; set; }
    public bool UsoPrivato { get; set; }

    public AutoAziendale(string marca, string modello, int annoImmatricolazione, string targa, bool usoPrivato) : base(marca, modello, annoImmatricolazione)
    {
        Targa = targa;
        UsoPrivato = usoPrivato;
    }

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

public class FurgoneAziendale : Veicolo
{
    public int CapacitaCarico { get; set; }

    public FurgoneAziendale(string marca, string modello, int annoImmatricolazione, int capacitaCarico) : base(marca, modello, annoImmatricolazione)
    {
        CapacitaCarico = capacitaCarico;
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, modello: {Modello}, anno immatricolazione: {AnnoImmatricolazione}, capacità carico: {CapacitaCarico}kg");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>();

        veicoli.Add(new AutoAziendale("bmw", "mn12", 2008, "ie23y46b", true));
        veicoli.Add(new FurgoneAziendale("Audi", "scm2", 2012, 3000));

        foreach (Veicolo v in veicoli)
        {
            v.StampaInfo();
        }
    }
}