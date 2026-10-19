using APIRateLimiting;

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
        Console.WriteLine("\nAccount Type:");
        Console.WriteLine("[1] Free Tier");
        Console.WriteLine("[2] Enterprise");
        int choice2 = int.Parse(Console.ReadLine());
        if (choice2 == 1)
        {
            Guid id = Guid.NewGuid();
            string subsname = "FREE TIER";
            int availablecreds = 150;
            Console.WriteLine("Subscription Password: ");
            string pass = Console.ReadLine();
            Item = new FreeTier(id, subsname,  availablecreds,pass);
            if (Item != null)
            {
                Console.WriteLine($"Success: New Free Tier Account Created, your new id:\n {id}");    
            }
            else
            {
                Console.WriteLine("Error: No Account Created, Please try again");
            }
            
        }
        
    }

    if (choice == 5)
    {
        Console.WriteLine("\nGoodbye");
        break;
    }
}