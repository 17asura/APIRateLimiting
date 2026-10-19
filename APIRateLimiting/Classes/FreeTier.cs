namespace APIRateLimiting;

public class FreeTier : Subscription
{
    public FreeTier(Guid subscriptionid, string subscriptionname, int availableCredits, string subscriptionpassword ) : base(subscriptionid,subscriptionname,availableCredits,subscriptionpassword){}

    public override void TakeCredits(int credits)
    {
        if (credits >= 0)
        {
            if (AvailableCredits < credits)
            {
                Console.WriteLine($"Error: Recharge your credits! {AvailableCredits} credits left.");
            }
            else
            {
                AvailableCredits -= credits;
                Console.WriteLine($"Success: Took {credits} credits, {AvailableCredits} credits left.");
            }
        }
        else
        {
            Console.WriteLine($"Error: Invalid credits, {AvailableCredits} credits left.");
        }

    }

    public override void RechargeCredits(int credits)
    {
        AvailableCredits += credits;
        Console.WriteLine($"Success: {AvailableCredits} credits left.");
    }
}