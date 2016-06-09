using System;
using System.Collections.Generic;
using System.Linq;

namespace ScreeningSample
{
    public class AccountBl
    {
        //private IDataStore dataStore = new DataStore();
        private IDataStore dataStore1;
        private IDataStore dataStore { get { return dataStore1 == null ? new DataStore() : dataStore1; } }

        public void setDataStore(IDataStore ds)
        {
            dataStore1 = ds;
        }

        public List<Account> GetInvestmentAccounts(int clientId, AccountType accountType)
        {
            if (accountType == AccountType.Investment)
            {
                var accounts = dataStore.LoadAccounts(clientId);
                return accounts.Where(a => a.AccountType == AccountType.Investment).ToList();
            }
            throw new Exception("Invalid account type provided");
        }
    }
}