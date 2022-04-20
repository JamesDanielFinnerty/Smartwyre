using Smartwyre.DeveloperTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPaymentService, PaymentService>()
                .AddSingleton<IAccountDataStore, AccountDataStore>()
                .BuildServiceProvider();

            var request = new MakePaymentRequest();

            request.CreditorAccountNumber = "test acc no";
            request.DebtorAccountNumber = "test acc no";
            request.Amount = 100;
            request.PaymentDate = new DateTime(2022, 01, 01);
            request.PaymentScheme = PaymentScheme.AutomatedPaymentSystem;

            var service = serviceProvider.GetService<IPaymentService>();

            var result = service.MakePayment(request);

            Console.WriteLine("Payment " + result.Success.ToString());
        }
    }
}
