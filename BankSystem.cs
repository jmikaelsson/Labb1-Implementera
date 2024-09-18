using System;
using System.Collections.Generic;

namespace Labb1_Implementera
{
    // Singleton-mönster för att säkerställa en enda instans av BankSystem.
    public class BankSystem
    {
        private static BankSystem _instance;
        private static readonly object _lock = new object();
        private List<Account> _accounts = new List<Account>();

        private BankSystem() { }

        public static BankSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BankSystem();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccount(string accountNumber)
        {
            return _accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }
    }
}
