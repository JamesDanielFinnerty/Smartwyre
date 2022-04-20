using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Tests.Builder;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests
{
    [TestClass]
    public class AccountTests
    {

        [TestMethod]
        public void Test001_IsLive_LiveStatusReturnsTrue()
        {
            var account = new Account();

            account.Status = AccountStatus.Live;

            Assert.AreEqual(true, account.IsLive());
        }
    }
}
