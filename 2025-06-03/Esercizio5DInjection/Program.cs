public interface INotifier
{
    void Notify(string message);
}

public class SmsNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"Notifica sms: {message}");
    }
}

public class AlertService
{
    public void SendAlert(string message, INotifier notifier)
    {
        notifier.Notify(message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var smsNotifier = new SmsNotifier();
        var alertService = new AlertService();

        alertService.SendAlert("allerta pioggia", smsNotifier);
    }
}