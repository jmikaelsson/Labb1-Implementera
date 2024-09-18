using System.Security.Principal;

namespace Labb1_Implementera
{
    internal class Program
    {
        // Denna applikation använder följande designmönster:
        // 1. Singleton: Säkerställer en enda instans av BankSystem.
        // 2. Factory Method: Skapar olika kontotyper via AccountFactory.
        // 3. Adapter: Anpassar extern bank-API till Account-gränssnittet.

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            BankSystem banksystem = BankSystem.Instance;

            // Skapar konton med Factory Method
            Account savings = AccountFactory.CreateAccount("savings", "123");
            Account checking = AccountFactory.CreateAccount("checking", "456");
            Account external = AccountFactory.CreateAccount("external", "789");

            banksystem.AddAccount(savings);
            banksystem.AddAccount(checking);
            banksystem.AddAccount(external);

            while (true)
            {
                Console.WriteLine("****************************************");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("     🎉 Välkommen till Edumaten! 🎉    ");
                Console.ResetColor();
                Console.WriteLine("****************************************");
                Console.WriteLine();
                Console.WriteLine("Välj ett alternativ från menyn nedan:");
                Console.WriteLine();
                Console.WriteLine("1. 💰 Insättning – Sätt in pengar på ditt konto.");
                Console.WriteLine("2. 🏧 Uttag – Ta ut pengar från ditt konto.");
                Console.WriteLine("3. 📊 Kontrollera saldo – Se hur mycket som finns kvar på ditt konto.");
                Console.WriteLine("4. 🚪 Avsluta – Tack för att du använde Edumaten!");
                Console.WriteLine();
                Console.Write("Ditt val: ");


                var choice = Console.ReadLine();
                Console.Clear();

                if (choice == "4")
                {
                    Console.Clear();
                    // Visa tack-meddelande och vänta i 3 sekunder
                    Console.WriteLine("Tack för att du använder Edumaten!");
                    Thread.Sleep(3000);
                    break;
                }


                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("****************************************");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("       --- Insättning på Konto ---      ");
                        Console.ResetColor();
                        Console.WriteLine("****************************************");
                        Console.WriteLine();

                        Console.Write("Ange kontonummer: ");
                        var accountNumber = Console.ReadLine();
                        var account = banksystem.GetAccount(accountNumber);

                        if (account == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ogiltigt kontonummer. Vänligen försök igen.");
                            Console.WriteLine();
                            Console.WriteLine("Tryck på en tangent för att gå tillbaka till menyn...");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        Console.Write("Ange belopp att sätta in: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                            Console.WriteLine();
                            Console.WriteLine($"Inbetalning av {depositAmount} SEK till konto {accountNumber}.");
                            Console.WriteLine($"Nytt saldo: {account.Balance} SEK");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ogiltigt belopp. Vänligen ange ett korrekt belopp.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Tryck på en tangent för att gå tillbaka till menyn...");
                        Console.ReadKey();

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("****************************************");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("        --- Uttag från Konto ---        ");
                        Console.ResetColor();
                        Console.WriteLine("****************************************");
                        Console.WriteLine();

                        Console.Write("Ange kontonummer: ");
                        accountNumber = Console.ReadLine();
                        account = banksystem.GetAccount(accountNumber);

                        if (account == null)
                        {
                            Console.WriteLine("Ogiltigt kontonummer.");
                            Console.WriteLine();
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        Console.Write("Ange belopp att ta ut: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine();
                            Console.WriteLine($"Uttag av {withdrawAmount} SEK från konto {accountNumber}.");
                            Console.WriteLine($"Nytt saldo: {account.Balance} SEK");
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt belopp.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Tryck på en tangent för att gå tillbaka till menyn...");
                        Console.ReadKey();
                        break;


                    case "3":
                        Console.Clear();
                        Console.WriteLine("****************************************");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("       --- Kontrollera Saldo ---        ");
                        Console.ResetColor();
                        Console.WriteLine("****************************************");
                        Console.WriteLine();

                        Console.Write("Ange kontonummer: ");
                        accountNumber = Console.ReadLine();
                        account = banksystem.GetAccount(accountNumber);

                        if (account == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ogiltigt kontonummer. Vänligen kontrollera och försök igen.");
                            Console.WriteLine();
                            Console.WriteLine("Tryck på en tangent för att gå tillbaka till menyn...");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Aktuellt saldo för konto {accountNumber}: {account.Balance} SEK");
                        Console.WriteLine();
                        Console.WriteLine("Tryck på en tangent för att fortsätta...");
                        Console.ReadKey();

                        break;
                }

                Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
