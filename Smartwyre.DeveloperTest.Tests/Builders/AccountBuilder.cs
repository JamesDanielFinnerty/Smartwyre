using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Tests.Builder
{
    internal class AccountBuilder
    {
        private Account _account;

        internal AccountBuilder()
        {
            _account = new Account();
        }

        internal AccountBuilder WithAutomatedPaymentsAllowed()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.AutomatedPaymentSystem;
            return this;
        }
        internal AccountBuilder IsLive()
        {
            _account.Status = AccountStatus.Live;
            return this;
        }

        internal AccountBuilder IsDisabled()
        {
            _account.Status = AccountStatus.Disabled;
            return this;
        }

        internal Account Build()
        {
            return _account;
        }
    }
}
