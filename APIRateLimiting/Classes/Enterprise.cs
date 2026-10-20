namespace APIRateLimiting;
//Enterprise SubClass
public class Enterprise : Subscription
{
    public Enterprise(string subscriptionid, string subscriptionname, int availableCredits, string subscriptionpassword ) : base(subscriptionid,subscriptionname,availableCredits,subscriptionpassword){}
    //Custom TakeCredits Method (Can have -500 credits)
    public override void TakeCredits(string passTest, int credits)
    {
        if (CheckPass(passTest))
        {
            if (credits >= 0)
            {
                if (AvailableCredits - credits < -500)
                {
                    Console.WriteLine("Error: Please wait for the credits renewal or recharge them!");
                }
                else
                {
                    AvailableCredits -= credits;
                    Console.WriteLine($"Success: Credits taken: {credits}\n New Available Credits: {AvailableCredits}");
                }
            }else
            {
                Console.WriteLine($"Error: Invalid credits, {AvailableCredits} credits left.");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid Credentials");
        }
    }
    //Custom RechargeCredits Method for Subscription Renewal
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