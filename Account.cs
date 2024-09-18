using System;

namespace Labb1_Implementera
{
    // Abstrakt basklass för konton.
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);

        protected void Notify()
        {
            Console.WriteLine($"{this.GetType().Name} {AccountNumber} saldo uppdaterat: {Balance} sek");
        }
    }
}
