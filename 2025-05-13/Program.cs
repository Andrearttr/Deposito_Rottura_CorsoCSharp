using System;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

class Program{
    static void Main(string[] args){

        //PariODispari();
        //Calcolatrice();
        //CheckPassword();
        //Voto();
        //BMI();
        //Temperatura();
        //WeekDay();
        //Area();
        //CicloInteri();
        //NumeroSegreto();
        //Bancomat();
        //PasswordMax3();
        //SumAndAmount();
        //SequenceCalculator();
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

    static void PariODispari(){
            Console.WriteLine("Scrivi un numero intero");
            int number = IntParse();

            if(number % 2 == 0){
                Console.WriteLine(number + " è un numero pari");
            }
            else{
                Console.WriteLine(number + " è un numero dispari");
            }
        }

    static void Calcolatrice(){
            Console.WriteLine("Scrivi il primo numero");
            double number1 = DoubleParse();
            Console.WriteLine("Scrivi il secondo numero");
            double number2 = DoubleParse();
            Console.WriteLine("Scrivi l'operatore");
            string operatore = StringCheck();

            if(operatore == "+"){
                double result = number1 + number2;
                Console.WriteLine("Il risultato è " + result);
            }
            else if(operatore == "-"){
                double result = number1 - number2;
                Console.WriteLine("Il risultato è " + result);
            }
            else {
                Console.WriteLine("Operatore non valido");
            }

        }

    static void CheckPassword(){
            const int password = 12345;
            Console.WriteLine("Inserisci la password");
            int userPassword = IntParse();

            if(userPassword == password){
                Console.WriteLine("Accesso Consentito");
            }
            else{
                Console.WriteLine("Accesso Negato");
            }
        }

    static void Voto(){
        Console.Write("Inserisci il voto: ");
        int voto = IntParse();

        if(voto >= 1 && voto <= 4){
            Console.WriteLine("Insufficiente");
        }
        else if(voto >= 5 && voto <= 6){
            Console.WriteLine("Sufficiente");
        }
        else if(voto >= 7 && voto <= 8){
            Console.WriteLine("Buono");
        }
        else if(voto >= 9 && voto <= 10){
            Console.WriteLine("Ottimo");
        }
        else{
            Console.WriteLine("Voto non valido");
        }
    }

    static void BMI(){
        Console.Write("Inserisci il peso in Kg: ");
        float peso = FloatParse();
        Console.Write("Inserisci l'altezza in m: ");
        float altezza = FloatParse();
        float bmi = peso / (altezza * altezza);
        

        if(bmi < 18.5){
            Console.WriteLine("Sei sottopeso");
        }
        else if(bmi >= 18.5 && bmi < 25){
            Console.WriteLine("Sei normopeso");
        }
        else if(bmi >= 25 && bmi < 30){
            Console.WriteLine("Sei sovrappeso");
        }
        else if(bmi > 30){
            Console.WriteLine("Obeso");
        }

    }

    static void Temperatura(){
        Console.Write("Scegli l'unità di misura (C, F, K, R): ");
        string unit1 = StringCheck();

        if (unit1 != "C" && unit1 != "F" && unit1 != "K" && unit1 != "R"){
            Console.Write("Unità non valida\nriprova: ");
            unit1 = StringCheck();
        }

        Console.Write("Inserisci la temperatura:");
        float temp1 = FloatParse();
        Console.Write("Scegli l'unità di misura per la conversione (C, F, K, R): ");
        string unit2 = StringCheck();

        if (unit2 != "C" && unit2 != "F" && unit2 != "K" && unit2 != "R"){
            Console.Write("Unità non valida\nriprova: ");
            unit2 = StringCheck();
        }

        float tempC = 0;

        if(unit1! == "C"){
            tempC = temp1;
        }
        else if(unit1! == "F"){
            tempC = (temp1 - 32) * 5/9;
        }
        else if(unit1! == "K"){
            tempC = temp1 - 273.15f;
        }
        else if(unit1! == "R"){
            tempC = temp1 * 5/9 - 273.15f;
        }
        
        if(unit2 == "C"){
            Console.Write($"{tempC}C");
        }
        else if(unit2 == "F"){
            float temp2 = (tempC * 9/5) + 32;
            Console.Write($"{temp2}F");
        }
        else if(unit2 == "K"){
            float temp2 = tempC + 273.15f;
            Console.Write($"{temp2}K");
        }
        else if(unit2 == "R"){
            float temp2 = (tempC + 273.15f) * 9/5;
            Console.Write($"{temp2}R");
        }
        
    }

    static void WeekDay(){
        Console.Write("Scegli un numero intero da 1 a 7: ");
        int number = IntParse();
        
        switch(number){
            case 1:
                Console.Write("Lunedì");
                break;
            case 2:
                Console.Write("Martedì");
                break;
            case 3:
                Console.Write("Mercoledì");
                break;
            case 4:
                Console.Write("Giovedì");
                break;
            case 5:
                Console.Write("Venerdì");
                break;
            case 6:
                Console.Write("Sabato");
                break;
            case 7:
                Console.Write("Domenica");
                break;
            default:
                Console.Write("Numero non valido");
                break;
        }
    }

    static void Area(){
        Console.Write("Scegli la figura geometrica (quadrato, cerchio, triangolo): ");
        string figura = StringCheck();

        switch(figura){
            case "quadrato":
                Console.Write("Inserisci la lunghezza del lato: ");
                float lato = FloatParse();
                float area = lato * lato;
                Console.Write($"L'area del quadrato è {area}");
                break;

            case "cerchio":
                Console.Write("Inserisci la lunghezza del raggio: ");
                float raggio = FloatParse();
                area = float.Pi * raggio * raggio;
                Console.Write($"L'area del cerchio è {area}");
                break;
            
            case "triangolo":
                Console.Write("Inserisci la lunghezza della base: ");
                float latoBase = FloatParse();
                Console.Write("Inserisci la lunghezza dell'altezza: ");
                float altezza = FloatParse();
                area = latoBase * altezza / 2;
                Console.Write($"L'area del cerchio è {area}");
                break;

            default:
                Console.Write("Figura non valida");
                break;
        }
    }

    static void CicloInteri(){
        int numero = 0;
        int somma = 0;

        while(numero >= 0){
            Console.Write("Inserisci un numero intero: ");
            numero = IntParse();

            if(numero < 0){
                break;
            }
            somma += numero;
        }
        Console.Write($"La somma è {somma}");
    }

    static void NumeroSegreto(){
        int numeroSegreto = 27;
        Console.Write("Inserisci un numero intero: ");
        int guess = IntParse();

        while(numeroSegreto != guess){
            Console.WriteLine("Numero sbagliato");
            if(numeroSegreto > guess){
                Console.WriteLine($"Il numero segreto è maggiore di {guess}");
            }
            else if(numeroSegreto < guess){
                Console.WriteLine($"Il numero segreto è minore di {guess}");
            }
            guess = IntParse();
        }

        Console.WriteLine($"hai indovinato! Il numero segreto era {numeroSegreto}");

    }

    static void Bancomat(){
        double saldo = 0;
        bool continua = true;
        int action = 0;

        while(continua){
            Console.WriteLine("\nSeleziona un'opzione:\n[1] Visualizza saldo\n[2] Deposita denaro\n[3] Preleva denaro\n[4] Esci\n");
            action = IntParse();

            switch(action){
                case 1:
                    Console.WriteLine($"\nIl saldo corrente è {saldo} euro");
                    break;

                case 2:
                    Console.Write("\nInserisci la somma da depositare: ");
                    double amount = IntParse();
                    saldo += amount;
                    Console.WriteLine($"\nHai depositato {amount} euro, il saldo corrente è {saldo} euro");
                    break;

                case 3:
                    Console.Write("\nInserisci la somma da ritirare: ");
                    amount = IntParse();
                    if(amount <= saldo){
                        saldo -= amount;
                        Console.WriteLine($"\nHai ritirato {amount} euro, il saldo corrente è {saldo} euro");
                    }
                    else{
                        Console.WriteLine($"\nNon hai {amount} euro da ritirare, il saldo corrente è {saldo} euro");
                    }
                    
                    break;

                case 4:
                    Console.WriteLine("\nArrivederci");
                    continua = false;
                    break;
                
                default:
                    Console.WriteLine("\nAzione non valida");
                    break;

            }
        }
    }

    static void PasswordMax3(){
        const int password = 12345;
        bool continua = true;
        int tries = 3;
        
        do{
            Console.Write("Inserisci la password: ");
            int userInput = IntParse();

            if(userInput == password){
                Console.WriteLine("Password corretta\nAccesso consentito");
                continua = false;
            }
            else{
                tries--;
                Console.WriteLine($"Password errata\n{tries} tentativi rimasti");
            }
        }
        while(continua && tries > 0);
    }

    static void SumAndAmount(){
        int somma = 0;
        int amount = 0;
        int userInput;

        do{
            Console.Write("Inserisci un numero: ");
            userInput = IntParse();
            somma += userInput;
            amount++;
        }
        while(userInput != 0);

        Console.WriteLine($"La somma è {somma}");
        Console.WriteLine($"Hai inserito {amount - 1} numeri");
    }

    static void SequenceCalculator(){
        bool exit = false;

        do{
            Console.WriteLine("\nScegli l'operazione\n[1] Addizione\n[2] Sottrazione\n[3] Moltiplicazione\n[4] Divisione\n[5] Esci\n");
            int action = IntParse();

            while(action < 1 || action > 5){
                Console.WriteLine("\nOperazione non valida, riprovare\n");
                action = IntParse();
            }

            if(action == 5){
                break;
            }
            
            Console.Write("\nInserire il primo numero: ");
            double num1 = DoubleParse();
            Console.Write("\nInserire il secondo numero: ");
            double num2 = DoubleParse();

            double result = 0;

            switch(action){
                case 1:
                    result = num1 + num2;
                    break;
                case 2:
                    result = num1 - num2;
                    break;
                case 3:
                    result = num1 * num2;
                    break;
                case 4:
                    result = num1 / num2;
                    break;
            }

            Console.WriteLine($"\nIl risultato è {result}");
        }
        while(!exit);
    }

}

