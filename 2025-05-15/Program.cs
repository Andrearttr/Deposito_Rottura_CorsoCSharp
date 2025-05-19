using System;

class Program{
    static void Main(string[] args){

        //Es1Saluto();
        //Es2Pari();
        //Es3Potenza();
        //Es4Raddoppia();
        //Es5Data();
        //Es6Dividi();
        //Es7Analizza();
        //Es8Punteggio();
        //Es9Studente();
    }

    private static void Es1Saluto(){
        Stampasaluto("Andrea");
    }

    private static void Stampasaluto(string name){
        Console.WriteLine($"\nCiao {name}!");
    }

    private static void Es2Pari(){
        int number = 7;
        if(VerificaPari(number)){
            Console.WriteLine($"\n{number} è un numero pari");
        }
        else{
            Console.WriteLine($"\n{number} è un numero dispari");
        }
    }

    private static bool VerificaPari(int number){
        return number % 2 == 0;
    }

    private static void Es3Potenza(){
        Console.WriteLine($"\nIl risultato è {CalcolaPotenza(2,3)}");
    }

    private static int CalcolaPotenza(int baseNum, int esponente){
        int result = 1;

        for(int i = 0; i < esponente; i++){
            result *= baseNum;
        }    
        return result;
    }

    private static void Es4Raddoppia(){
        int numero = 5;
        Console.WriteLine($"\nIl numero è {numero}");
        Raddoppia(ref numero);
        Console.WriteLine($"\nIl numero raddoppiato è {numero}");
    }

    private static void Raddoppia(ref int numero){
        numero *= 2;
    }

    private static void Es5Data(){
        int giorno = 120;
        int mese = 1;
        int anno = 2025;

        Console.WriteLine($"\n{giorno}/{mese}/{anno}");
        AggiustaData(ref giorno, ref mese, ref anno);
        Console.WriteLine($"\n{giorno}/{mese}/{anno}");

    }

    private static void AggiustaData(ref int giorno, ref int mese, ref int anno){
        while(giorno > 30){
            giorno -= 30;
            mese += 1;
        }

        while(mese > 12){
            mese -= 12;
            anno += 1;
        }
    }

    private static void Es6Dividi(){
        double dividendo = 15;
        double divisore = 4;

        Dividi(dividendo, divisore, out double quoziente, out int resto);
        Console.WriteLine($"\n{dividendo} / {divisore} fa {quoziente} o {(int)quoziente} con resto {resto}");
    }

    private static void Dividi(double dividendo, double divisore, out double quoziente, out int resto){
        quoziente = dividendo / divisore;
        resto = (int)(dividendo % divisore);
    }

    private static void Es7Analizza(){
        string frase = "Ciao a tutti";
        
        AnalizzaParola(frase, out int numVocali, out int numCons, out int numSpazi);
        Console.WriteLine($"\n\"{frase}\" contiene {numVocali} vocali, {numCons} consonanti e {numSpazi} spazi");
    }

    private static void AnalizzaParola(string parola, out int numVocali, out int numCons, out int numSpazi){
        string vocali = "aeiou";
        numVocali = 0;
        numCons = 0;
        numSpazi = 0;

        foreach(char c in parola){
            if (vocali.Contains(char.ToLower(c))){
                numVocali++;
            }
            else if(char.IsWhiteSpace(c)){
                numSpazi++;
            }
            else if(char.IsLetter(c)){
                numCons++;
            }
        }
    }

    private static void Es8Punteggio(){
        int punt1 = 49;
        int punt2 = 15;
        int punt3 = 31;
        int bonus1 = 23;
        int bonus2 = 5;
        int bonus3 = 8;

        AggiornaPunteggio(ref punt1, ref punt2, ref punt3, bonus1, bonus2, bonus3, out int totale, out double media);
        Console.WriteLine($"\nPunteggio totale: {totale}\nPunteggio medio: {media}");
    }

    private static void AggiornaPunteggio(ref int punt1, ref int punt2, ref int punt3,int bonus1, int bonus2, int bonus3, out int totale, out double media){
        punt1 += bonus1;
        punt2 += bonus2;
        punt3 += bonus3;

        totale = punt1 + punt2 + punt3;
        media = totale / 3;
    }

    private static void Es9Studente(){
        string nome = "Andrea";
        double voto1 = 7.5;
        double voto2 = 6;

        ElaboraStudente(nome, ref voto1, ref voto2, out double media, out bool promosso);

        if(promosso){
            Console.WriteLine($"\nLo\\a studente\\ssa {nome} è stato\\a promosso\\a con la media del {media}");
        }
        else{
            Console.WriteLine($"\nLo\\a studente\\ssa {nome} è stato\\a bocciato\\a con la media del {media}");
        }

    }

    private static void ElaboraStudente(string nome, ref double voto1, ref double voto2, out double media, out bool promosso){
        promosso = false;
        media = (voto1 + voto2) / 2;

        if(media >= 6){
            promosso = true;
        }
    }

}