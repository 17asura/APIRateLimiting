namespace APIRateLimiting;

public abstract class Subscription
{
    protected string SubscriptionId {get; set;}
    protected string SubscriptionName {get; set;}
    protected int AvailableCredits  {get; set;}
    protected string SubscriptionPassword {get; set;}
    protected Subscription(string subscriptionId, string subscriptionName, int availableCredits, string subscriptionPassword)
    {
        SubscriptionId = subscriptionId;
        SubscriptionName = subscriptionName;
        AvailableCredits = availableCredits;
        SubscriptionPassword = subscriptionPassword;
    }

    public abstract void TakeCredits(string passTest, int credits);
    public virtual void RechargeCredits(string passTest) {} // "Virtual" instead of "Abstract", it's the same thing but lets you declare the same method with different variables

    public virtual void RechargeCredits(string passTest, int credits)
    {
        if (CheckPass(passTest))
        {
            if (credits > 0)
            {
                AvailableCredits += credits;
                Console.WriteLine($"Success: Available Credits: {AvailableCredits}");
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

    public bool CheckPass(string passTest)
    {
        if (passTest.CompareTo(SubscriptionPassword) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckId(string idTest)
    {
        if (idTest.CompareTo(SubscriptionId) == 0)
        {
            return true;
        }
        return false;
    }
    public void ReturnAccountData(string passTest)
    {
        if (CheckPass(passTest) == true)
        {
            Console.WriteLine($"\n-------- ACCOUNT DETAILS --------");
            Console.WriteLine($"Account With ID: {SubscriptionId}");
            Console.WriteLine($"Subscription Type: {SubscriptionName}");
            Console.WriteLine($"Available Credits: {AvailableCredits}");
        }
        else
        {
            Console.WriteLine("Error: Invalid Credentials");
        }
    }

    public string TypeFinder(string passTest)
    {
        if (CheckPass(passTest))
        {
            return SubscriptionName;
        }
        return "Error: Invalid Credentials";
    }
}