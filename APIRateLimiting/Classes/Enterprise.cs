namespace APIRateLimiting;

public class Enterprise : Subscription
{
    public Enterprise(Guid subscriptionid, string subscriptionname, int availableCredits, string subscriptionpassword ) : base(subscriptionid,subscriptionname,availableCredits,subscriptionpassword){}

    public override void TakeCredits(int credits)
    {
        if (AvailableCredits -  credits <= -500)
        {
            Console.WriteLine("Error: Please wait for the credits renewal or recharge them!");
        }
        else
        {
            AvailableCredits -= credits;
            Console.WriteLine($"Success: Credits taken: {credits}\n New Available Credits: {AvailableCredits}");
        }
    }

    public override void RechargeCredits(int credits)
    {
        AvailableCredits += credits;
        Console.WriteLine($"Success: Available Credits: {AvailableCredits}");
    }

    public override void RechargeCredits()
    {
        AvailableCredits = 500;
        Console.WriteLine($"Success: Available Credits: {AvailableCredits}");
    }
}