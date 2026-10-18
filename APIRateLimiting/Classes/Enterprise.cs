namespace APIRateLimiting;

public class Enterprise : Subscription
{
    public Enterprise(Guid subscriptionid, string subscriptionname, int availableCredits ) : base(subscriptionid,subscriptionname,availableCredits){}

    public override void TakeCredits(int credits)
    {
    }
    public override void RechargeCredits()
    {
        AvailableCredits = 500;
    }
}