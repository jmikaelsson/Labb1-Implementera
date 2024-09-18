using System;

namespace Labb1_Implementera
{
    // Ärver från Account och hanterar insättning och uttag.
    public class CheckingAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Notify();
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Notify();
            }
            else
            {
                Console.WriteLine("Otillräckliga medel.");
            }
        }
    }
}
