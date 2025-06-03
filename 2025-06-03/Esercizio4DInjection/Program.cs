public interface IStorageService
{
    void Upload(string file);
}

public class DiskStorage : IStorageService
{
    public void Upload(string file)
    {
        Console.WriteLine($"il file {file} è stato caricato sul disco");
    }
}

public class MemoryStorage : IStorageService
{
    public void Upload(string file)
    {
        Console.WriteLine($"il file {file} è stato caricato sulla memoria");
    }
}

public class FileUploader
{
    public IStorageService storageService { get; set; }

    public void Upload(string file)
    {
        if (storageService == null)
        {
            Console.WriteLine("Nessun servizio selezionato");
        }
        else
        {
            storageService.Upload(file);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var diskStorage = new DiskStorage();
        var memoryStorage = new MemoryStorage();
        var fileUploader = new FileUploader();

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Carica su disco");
            Console.WriteLine("[2] Carica su memoria");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 2);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("inserisci file: ");
                    string file = Input.String();
                    fileUploader.storageService = diskStorage;
                    fileUploader.Upload(file);
                    break;
        
                case 2:
                    Console.Write("inserisci file: ");
                    file = Input.String();
                    fileUploader.storageService = memoryStorage;
                    fileUploader.Upload(file);
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}