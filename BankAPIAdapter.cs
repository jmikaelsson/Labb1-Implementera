using System;

namespace Labb1_Implementera
{
    internal class BankAPIAdapter : Account
    {
        private BankAPI _bankService = new BankAPI();

        public BankAPIAdapter(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = _bankService.GetBalance(accountNumber);
        }

        public override void Deposit(decimal amount)
        {
            _bankService.MakeDeposit(AccountNumber, amount);
            Balance += amount;
            Notify();
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                _bankService.MakeWithdrawal(AccountNumber, amount);
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
