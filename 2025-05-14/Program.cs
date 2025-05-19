using System;

class Program{
    static void Main(string[] args){

        //Tabellina();
        //Media();
        //Fattoriale();
        //ContaCifre();
        //EliminaSpazi();
        //ContaVocali();
        //ValidPassword();
        //AnalyzeString();
    }

    static int IntParse(){
        while (true){
            if(int.TryParse(Console.ReadLine(), out int output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }
    
    static float FloatParse(){
        while (true){
            if(float.TryParse(Console.ReadLine(), out float output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }
    
    static double DoubleParse(){
        while (true){
            if(double.TryParse(Console.ReadLine(), out double output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }

    static string StringCheck(){
        while (true){
            string? output = Console.ReadLine();
            if(!string.IsNullOrEmpty(output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }

    static void Tabellina(){
        Console.Write("\nInserisci un numero: ");
        int num = IntParse();
        Console.WriteLine($"\nLa tabellina di {num} è:\n");

        for(int i = 0; i < 10; i++){
            int result = num * (i+1);
            Console.WriteLine(result);
        }
    }

    static void Media(){
        Console.Write("\nQuanti numeri vuoi inserire? ");
        int amount = IntParse();
        double sum = 0;
        double average = 0;

        for(int i = 0; i < amount; i++){
            Console.Write($"Inserisci il {i+1}° numero: ");
            double num = DoubleParse();
            sum += num;
        }

        average = sum / amount;
        Console.WriteLine($"\nLa media dei numeri è {average}");
    }

    static void Fattoriale(){
        Console.Write("\nInserisci un numero: ");
        int num = IntParse();
        double result = 1;

        while(num < 0){
            Console.Write("\nImpossibile usare un numero negativo, riprova: ");
            num = IntParse();
        }
        

        for(int i = num; i > 0; i--){
            result *= i;
        }

        Console.WriteLine($"\nIl fattoriale di {num} è {result}");
    }

    static void ContaCifre(){
        Console.Write("\nInserisci una frase: ");
        string frase = StringCheck();
        int numeroCifre = 0;

        foreach(char c in frase){
            if (char.IsDigit(c)){
                numeroCifre++;
            }
        }

        Console.WriteLine($"\nLa frase contiene {numeroCifre} cifre");
    }

    static void EliminaSpazi(){
        Console.Write("\nInserisci una frase: ");
        string frase = StringCheck();
        string newFrase = "";
        
        foreach(char c in frase){
            if(c != ' '){
                newFrase += c;
            }
        }

        Console.WriteLine($"\nLa frase senza spazi è {newFrase}");
    }

    static void ContaVocali(){
        Console.Write("\nInserisci una frase: ");
        string frase = StringCheck();
        int numeroVocali = 0;
        const string vocali = "aeiou";

        foreach(char c in frase){
            if(vocali.Contains(char.ToLower(c))){
                numeroVocali++;
            }
        }

        Console.Write($"\nLa frase contiene {numeroVocali} vocali");
    }

    static void ValidPassword(){
        Console.Write("\nInserisci una password: ");
        bool containsUpper = false;
        bool containsDigit = false;
        bool is8Long = false;
        bool isTrimmed = false;
        int minLenght = 8;

        while (true){
            string password = StringCheck();

            foreach(char c in password){
                
                if(!containsUpper && char.IsUpper(c)){
                    containsUpper = true;
                }
                if(!containsDigit && char.IsDigit(c)){
                    containsDigit = true;
                }
            }
    
            if(password.Length >= minLenght){
                is8Long = true;
            }
            if(!password.StartsWith(" ") && !password.EndsWith(" ")){
                isTrimmed = true;
            }
    
            if(containsDigit && containsUpper && is8Long && isTrimmed){
                Console.WriteLine("\nPassword valida");
                break;
            }
            else{
                Console.Write("\nPassword non valida, riprovare: ");
            }
        }
    }

    static void AnalyzeString(){
        Console.Write("\nInserisci una frase: ");
        string frase = StringCheck();

        int numParole = 0;
        int numLettere = 0;
        int numSpazi = 0;
        int numSegni = 0;

        foreach(char c in frase){
            if(char.IsLetter(c)){
                numLettere++;
            }
            else if(char.IsWhiteSpace(c)){
                numSpazi++;
            }
            else if(char.IsPunctuation(c)){
                numSegni++;
            }
        }

        numParole = frase.Split(' ').Length;

        Console.Write($"\nLa frase contiene:\n{numParole} parole\n{numLettere} lettere\n{numSpazi} spazi\n{numSegni} segni");
        
    }

}