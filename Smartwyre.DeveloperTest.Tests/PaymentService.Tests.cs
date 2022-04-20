using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Tests.Builder;

namespace Smartwyre.DeveloperTest.Tests
{
    [TestClass]
    public class PaymentServiceTests
    {

        [DataTestMethod]
        [DataRow("123456")]
        [DataRow("555555")]
        [DataRow("abdhdd")]
        public void Test001_AccountNoNotInDataStore_PaymentFails(string testAccNo)
        {
            var fakeDataStore = A.Fake<IAccountDataStore>();
            A.CallTo(() => fakeDataStore.GetByAccountNumber(testAccNo)).Returns(null);

            var service = new PaymentService(fakeDataStore);

            var testRequest = new MakePaymentRequestBuilder()
                                        .WithDebtorAcc(testAccNo)
                                        .Build();

            var result = service.MakePayment(testRequest);

            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void Test002_AccountDisabled_AutomatedPaymentSystemRequest_PaymentFails()
        {
            var fakeDataStore = A.Fake<IAccountDataStore>();
            var testAccount = new AccountBuilder().IsDisabled().Build();

            A.CallTo(() => fakeDataStore.GetByAccountNumber(A<string>.Ignored)).Returns(testAccount);

            var service = new PaymentService(fakeDataStore);

            var testRequest = new MakePaymentRequestBuilder()
                                        .AsAutomatedPaymentSystem()
                                        .Build();

            var result = service.MakePayment(testRequest);

            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void Test003_AccountLive_AutomatedPaymentSystemRequest_PaymentSucceeds()
        {
            var fakeDataStore = A.Fake<IAccountDataStore>();
            var testAccount = new AccountBuilder()
                .WithAutomatedPaymentsAllowed()
                .IsLive().Build();

            A.CallTo(() => fakeDataStore.GetByAccountNumber(A<string>.Ignored)).Returns(testAccount);

            var service = new PaymentService(fakeDataStore);

            var testRequest = new MakePaymentRequestBuilder()
                                        .AsAutomatedPaymentSystem()
                                        .Build();

            var result = service.MakePayment(testRequest);

            Assert.AreEqual(true, result.Success);
        }
    }
}
