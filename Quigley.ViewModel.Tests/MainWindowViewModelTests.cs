using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quigley.Application;
using Quigley.Data;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        
         [TestMethod]
        public void Customers_Always_CallsGetCustomers()
        {
            IUIDataProvider dataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            dataProviderMock.Expect(c => c.GetCustomers());

            //act
            MainWindowViewModel target = new MainWindowViewModel(dataProviderMock);

            IList<Customer> customers = target.Customers;
            dataProviderMock.VerifyAllExpectations();
            }

        private IList<Customer> GetCustomers()
        {
            const int custNum = 10;
            IList<Customer> customers = new List<Customer>();
            for (int i = 0; i < custNum; i++)
            {
                customers.Add(new Customer()
                {
                CustomerID= "CustomerID" +  i,
                CompanyName = "CompanyName" + i
                });
            }

            return customers;
        }
    }

     
}
