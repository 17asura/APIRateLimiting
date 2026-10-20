namespace APIRateLimiting;

public class FreeTier : Subscription
{
    public FreeTier(string subscriptionid, string subscriptionname, int availableCredits, string subscriptionpassword ) : base(subscriptionid,subscriptionname,availableCredits,subscriptionpassword){}

    public override void TakeCredits(string passTest, int credits)
    {
        if (CheckPass(passTest))
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
        else
        {
            Console.WriteLine("Error: Invalid Credentials");
        }


    }
}