using System;

namespace Smartwyre.DeveloperTest.Types
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public AccountStatus Status { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        public bool PaymentSchemeAllowed(PaymentScheme scheme)
        {
            if(scheme == PaymentScheme.AutomatedPaymentSystem)
                return AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.AutomatedPaymentSystem);

            if (scheme == PaymentScheme.BankToBankTransfer)
                return AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.BankToBankTransfer);

            if (scheme == PaymentScheme.ExpeditedPayments)
                return AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.ExpeditedPayments);

            return false;

        }

        public bool HasSufficientFunds(decimal amount)
        {
            return Balance >= amount;
        }

        public bool IsLive()
        {
            return Status.Equals(AccountStatus.Live);
        }

        public bool IsNotLive()
        {
            return !IsLive();
        }

        public void Deduct(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Cannot deduct a negative amount");

            Balance -= amount;
        }
    }
}
