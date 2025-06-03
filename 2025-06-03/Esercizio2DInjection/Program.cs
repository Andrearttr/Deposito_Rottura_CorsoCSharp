public interface IPaymentGateway
{
    void Pay(double amount);
}

public class PaypalGateway : IPaymentGateway
{
    public void Pay(double amount)
    {
        Console.WriteLine($"pagamento di {amount} euto tramite paypal.");
    }
}

public class StripeGateway : IPaymentGateway
{
    public void Pay(double amount)
    {
        Console.WriteLine($"pagamento di {amount} euto tramite stripe.");
    }
}

public class PaymentProcessor
{
    private readonly IPaymentGateway _paymentGateway;

    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public void PayWithGateway(double amount)
    {
        _paymentGateway.Pay(amount);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var paypalGateway = new PaypalGateway();
        var stripeGateway = new StripeGateway();
        PaymentProcessor paymentProcessor;
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Paga con paypal");
            Console.WriteLine("[2] Paga con stripe");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 2);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("Inserisci somma: ");
                    double amount = Input.Double();
                    paymentProcessor = new PaymentProcessor(paypalGateway);
                    paymentProcessor.PayWithGateway(amount);
                    break;
        
                case 2:
                    Console.Write("Inserisci somma: ");
                    amount = Input.Double();
                    paymentProcessor = new PaymentProcessor(stripeGateway);
                    paymentProcessor.PayWithGateway(amount);
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}