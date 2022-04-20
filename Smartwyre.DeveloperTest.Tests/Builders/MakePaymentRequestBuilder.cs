using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Tests.Builder
{
    internal class MakePaymentRequestBuilder
    {
        private MakePaymentRequest _request;

        internal MakePaymentRequestBuilder()
        {
            _request = new MakePaymentRequest();

            _request.CreditorAccountNumber = "test acc no";
            _request.DebtorAccountNumber = "test acc no";
            _request.Amount = 0;
            _request.PaymentDate = new DateTime(2022, 01, 01);
            _request.PaymentScheme = PaymentScheme.AutomatedPaymentSystem;
        }

        internal MakePaymentRequestBuilder WithDebtorAcc(string acc)
        {
            _request.DebtorAccountNumber = acc;
            return this;
        }

        internal MakePaymentRequestBuilder AsAutomatedPaymentSystem()
        {
            _request.PaymentScheme = PaymentScheme.AutomatedPaymentSystem;
            return this;
        }

        internal MakePaymentRequest Build()
        {
            return _request;
        }
    }
}
