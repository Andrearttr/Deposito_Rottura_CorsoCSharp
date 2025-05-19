using System;
class Input{
    public static int Int(){
        while (true){
            if(int.TryParse(Console.ReadLine(), out int output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }

    public static float Float(){
        while (true){
            if(float.TryParse(Console.ReadLine(), out float output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }

    public static double Double(){
        while (true){
            if(double.TryParse(Console.ReadLine(), out double output)){
                return output;
            }
            else{
                Console.WriteLine("\nInput non valido, riprovare\n");
            }
        }
    }

    public static string String(){
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

}

