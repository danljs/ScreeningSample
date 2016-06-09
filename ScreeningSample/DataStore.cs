using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ScreeningSample
{
    public class DataStore : IDataStore
    {
        public static string GetAccountsSql = "irrelevant query";

        public List<Account> LoadAccounts(int clientId)
        {
            using (var connection = CreateConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = GetAccountsSql;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@clientId", clientId);

                var reader = sqlCommand.ExecuteReader();
                var accounts = new List<Account>();
                while (reader.Read())
                {
                    var account = new Account();
                    account.AccountNumber = (string)reader["number"];
                    account.AccountOwner = clientId;
                    if (reader["accountType"] == null || reader["accountType"] == DBNull.Value)
                    {
                        account.AccountType = AccountType.Checking;
                    }
                    else
                    {
                        account.AccountType =
                            (AccountType)Enum.Parse(typeof(AccountType), reader["accountType"].ToString());
                    }
                    accounts.Add(account);
                }
                return accounts;
            }

        }

        private static SqlConnection CreateConnection()
        {
            var sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}