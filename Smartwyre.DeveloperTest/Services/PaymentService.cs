using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System.Configuration;

namespace Smartwyre.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private IAccountDataStore _accountDataStore;

        public PaymentService(IAccountDataStore accountDataStore)
        {
            _accountDataStore = accountDataStore;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountDataStore.GetByAccountNumber(request.DebtorAccountNumber);

            if (account == null)
                return PaymentFailed("Account not found");

            if (!ValidatePaymentRequestForAccount(account, request))
                return PaymentFailed();

            account.Deduct(request.Amount);
            _accountDataStore.Update(account);

            return PaymentSucceeded();
        }

        private bool ValidatePaymentRequestForAccount(Account account, MakePaymentRequest request)
        {
            if (!account.PaymentSchemeAllowed(request.PaymentScheme))
                return false;

            if (request.PaymentScheme == PaymentScheme.ExpeditedPayments
                && !account.HasSufficientFunds(request.Amount))
                return false;

            if (request.PaymentScheme == PaymentScheme.AutomatedPaymentSystem
                && account.IsNotLive())
                return false;

            return true;
        }

        private MakePaymentResult PaymentFailed()
        {
            return new MakePaymentResult() { Success = false};
        }

        private MakePaymentResult PaymentFailed(string message)
        {
            return new MakePaymentResult() { Success = false, Message = message };
        }

        private MakePaymentResult PaymentSucceeded()
        {
            return new MakePaymentResult() { Success = true };
        }
    }
}
