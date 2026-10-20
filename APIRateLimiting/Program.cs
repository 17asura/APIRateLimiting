using APIRateLimiting;
List<Subscription> SubscriptionList = new List<Subscription>();
Subscription Item = null;
while (true)
{
    Console.WriteLine("\n=== API Rates Manager ===");
    Console.WriteLine("Welcome, What would you like to do?");
    Console.WriteLine("[1] Make an Account");
    Console.WriteLine("[2] See Account Details");
    Console.WriteLine("[3] Take Credits");
    Console.WriteLine("[4] Recharge Credits");
    Console.WriteLine("[5] Exit");
    Console.Write("Escolha: ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        //Creating an Account
        Console.WriteLine("\nAccount Type:");
        Console.WriteLine("[1] Free Tier");
        Console.WriteLine("[2] Enterprise");
        int choice2 = int.Parse(Console.ReadLine());
        if (choice2 == 1)
        {
            //If choice is Free Tier
            Guid id = Guid.NewGuid();
            string subsname = "FREE TIER";
            int availablecreds = 150;
            Console.WriteLine("Subscription Password: ");
            string pass = Console.ReadLine();
            Item = new FreeTier(id.ToString(), subsname,  availablecreds,pass);
            SubscriptionList.Add(Item);
            if (Item != null)
            {
                Console.WriteLine($"Success: New Free Tier Account Created, your new id:\n {id}");    
            }
            else
            {
                Console.WriteLine("Error: No Account Created, Please try again!");
            }
        }else if (choice2 == 2)
        {
            //If choice is ENTERPRISE
            Guid id = Guid.NewGuid();
            string subsname = "ENTERPRISE";
            int availablecreds = 500;
            Console.WriteLine("Subscription Password: ");
            string pass = Console.ReadLine();
            Item = new Enterprise(id.ToString(), subsname,  availablecreds,pass);
            SubscriptionList.Add(Item);
            if (Item != null)
            {
                Console.WriteLine($"Success: New Enterprise Account Created, your new id:\n {id}");    
            }
            else
            {
                Console.WriteLine("Error: No Account Created, Please try again!");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid Choice!");
        }
        
    }else if (choice == 2)
    {
        //Seeing Account Details
        Console.WriteLine("Account Id");
        string id = Console.ReadLine();
        Console.WriteLine("Account Password");
        string pass = Console.ReadLine();
        int count = 0;
        foreach (Subscription Sub in SubscriptionList)
        {
            if (Sub.CheckId(id))
            {
                Sub.ReturnAccountData(pass);
                count++;
            }
        }
        if (count == 0)
        {
            Console.WriteLine("Error: No Account Found, Please try again!");
        }
    }else if (choice == 3)
    {
        //Take Credits
        Console.WriteLine("Account Id");
        string id = Console.ReadLine();
        Console.WriteLine("Account Password");
        string pass = Console.ReadLine();
        Console.WriteLine("Credits Taken");
        int creds = int.Parse(Console.ReadLine());
        int count = 0;
        foreach (Subscription Sub in SubscriptionList)
        {
            if (Sub.CheckId(id))
            {
                Sub.TakeCredits(pass, creds);
                count++;
            }
        }
        if (count == 0)
        {
            Console.WriteLine("Error: No Account Found, Please try again!");
        }
    }else if (choice == 4)
    {
        //Recharge Credits
        Console.WriteLine("Account Id");
        string id = Console.ReadLine();
        Console.WriteLine("Account Password");
        string pass = Console.ReadLine();
        int count = 0;
        foreach (Subscription Sub in SubscriptionList)
        {
            if (Sub.CheckId(id))
            {
                count++;
                if (Sub.TypeFinder(pass).CompareTo("FREE TIER") == 0)
                {
                    //Free Tier Option to Recharge Credits (only option)
                    Console.WriteLine($"A {Sub.TypeFinder(pass)} account was found.\n How many credits to recharge? ");
                    int creds = int.Parse(Console.ReadLine());
                    Sub.RechargeCredits(pass, creds);
                }else if (Sub.TypeFinder(pass).CompareTo("ENTERPRISE") == 0)
                {
                    //ENTERPRISE Options to Recharge Credits (2 options)
                    Console.WriteLine($"A {Sub.TypeFinder(pass)} account was found.\n Do you want to recharge or renew your Subscription? ");
                    Console.WriteLine("[1] Custom Recharge");
                    Console.WriteLine("[2] Renew Subscription");
                    int chooserech = int.Parse(Console.ReadLine());
                    if (chooserech == 1)
                    {
                        //Option 1 -> Custom Recharge
                        Console.WriteLine("How many credits to recharge? ");
                        int creds = int.Parse(Console.ReadLine());
                        Sub.RechargeCredits(pass, creds);
                    } else if (chooserech == 2)
                    {
                        //Option 2 -> Subscription Renewal
                        Sub.RechargeCredits(pass);
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid Choice!");   
                    }
                }
            }
        }
        if (count == 0)
        {
            //If no account is found with the ID provided
            Console.WriteLine("Error: No Account Found, Please try again!");
        }
    }

    if (choice == 5)
    {
        Console.WriteLine("\nGoodbye");
        break;
    }
}