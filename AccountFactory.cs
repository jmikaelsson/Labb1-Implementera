using System;

namespace Labb1_Implementera
{
    // Factory Method-mönster för att skapa konton av olika typer utan att känna till deras specifika klasser.
    public static class AccountFactory
    {
        public static Account CreateAccount(string type, string accountNumber)
        {
            switch (type.ToLower())
            {
                case "savings":
                    return new SavingsAccount { AccountNumber = accountNumber };
                case "checking":
                    return new CheckingAccount { AccountNumber = accountNumber };
                case "external":
                    return new BankAPIAdapter(accountNumber);
                default:
                    throw new ArgumentException("Ogiltig kontotyp");
            }
        }
    }
}
