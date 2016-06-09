using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreeningSample;

namespace ScreeningSample.Tests
{
    class MockDataStore : ScreeningSample.IDataStore
    {
        public List<Account> LoadAccounts(int clientId)
        {
            var accounts = new List<Account>();

            var account1 = new Account();
            account1.AccountNumber = "25";
            account1.AccountOwner = 25;
            account1.AccountType = AccountType.Investment;
            accounts.Add(account1);

            var account2 = new Account();
            account2.AccountNumber = "26";
            account2.AccountOwner = 26;
            account2.AccountType = AccountType.Checking;
            accounts.Add(account2);

            var account3 = new Account();
            account3.AccountNumber = "27";
            account3.AccountOwner = 27;
            account3.AccountType = AccountType.Savings;
            accounts.Add(account3);

            var account4 = new Account();
            account4.AccountNumber = "28";
            account4.AccountOwner = 28;
            account4.AccountType = AccountType.Trading;
            accounts.Add(account4);

            return accounts;
        }
    }
}
