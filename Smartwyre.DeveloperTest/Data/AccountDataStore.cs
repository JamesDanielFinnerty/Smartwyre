using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        public Account GetByAccountNumber(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public void Update(Account model)
        {
            // Update account in database, code removed for brevity
        }
    }
}
