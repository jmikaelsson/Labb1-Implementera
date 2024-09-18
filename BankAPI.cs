using System;

namespace Labb1_Implementera
{
    internal class BankAPI
    {
        public decimal GetBalance(string accountNumber)
        {
            return 2000.0m;
        }

        public void MakeDeposit(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Inbetalning av {amount} till konto {accountNumber} i ett externt system.");
        }

        public void MakeWithdrawal(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Uttag av {amount} från konto {accountNumber} i ett externt system.");
        }
    }
}
