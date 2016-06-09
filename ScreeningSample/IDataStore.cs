using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreeningSample
{
    public interface IDataStore
    {
        List<Account> LoadAccounts(int clientId);
    }
}
