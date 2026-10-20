namespace APIRateLimiting;

public class Enterprise : Subscription
{
    public Enterprise(string subscriptionid, string subscriptionname, int availableCredits, string subscriptionpassword ) : base(subscriptionid,subscriptionname,availableCredits,subscriptionpassword){}

    public override void TakeCredits(string passTest, int credits)
    {
        if (CheckPass(passTest))
        {
            if (AvailableCredits -  credits < -500)
            {
                Console.WriteLine("Error: Please wait for the credits renewal or recharge them!");
            }
            else
            {
                AvailableCredits -= credits;
                Console.WriteLine($"Success: Credits taken: {credits}\n New Available Credits: {AvailableCredits}");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid Credentials");
        }
    }

    public override void RechargeCredits(string passTest, int credits)
    {
        if (CheckPass(passTest))
        {
            AvailableCredits += credits;
            Console.WriteLine($"Success: Available Credits: {AvailableCredits}");
        }
        else
        {
            Console.WriteLine("Error: Invalid Credentials");
        }
        
    }

    public override void RechargeCredits(string passTest)
    {
        if (CheckPass(passTest))
        {
            AvailableCredits = 500;
            Console.WriteLine($"Success: Available Credits: {AvailableCredits}");
        }
        else
        {
            Console.WriteLine("Error: Invalid Credentials");
        }
    }
}