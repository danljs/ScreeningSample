using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreeningSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreeningSample.Tests
{
    [TestClass()]
    public class AccountBlTests
    {

        [TestMethod()]
        public void GetInvestmentAccountsTest()
        {
            var accountBl = new AccountBl();
            IDataStore mds = new MockDataStore();
            accountBl.setDataStore(mds);
            var actual = (accountBl.GetInvestmentAccounts(25, AccountType.Investment))[0];
            Assert.AreEqual(25, actual.AccountOwner);
            Assert.AreEqual(AccountType.Investment, actual.AccountType);

            var expectedMessage = "Invalid account type provided";
            try
            {
                accountBl.GetInvestmentAccounts(26, AccountType.Checking);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
            }

            try
            {
                accountBl.GetInvestmentAccounts(27, AccountType.Savings);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
            }
            try
            {
                accountBl.GetInvestmentAccounts(28, AccountType.Trading);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
            }
        }
    }   
}