namespace APIRateLimiting;

public abstract class Subscription
{
    protected Guid SubscriptionId {get; set;}
    protected string SubscriptionName {get; set;}
    protected int AvailableCredits  {get; set;}
    protected string SubscriptionPassword {get; set;}
    protected Subscription(Guid subscriptionId, string subscriptionName, int availableCredits, string subscriptionPassword)
    {
        SubscriptionId = subscriptionId;
        SubscriptionName = subscriptionName;
        AvailableCredits = availableCredits;
        SubscriptionPassword = subscriptionPassword;
    }

    public abstract void TakeCredits(int credits);
    public virtual void RechargeCredits() {} // "Virtual" instead of "Abstract", it's the same thing but lets you declare the same method with different variables
    public virtual void RechargeCredits(int credits) {}
}