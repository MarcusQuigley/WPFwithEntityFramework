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
    public class CustomerDetailsViewModelTests
    {
        [TestMethod]
        public void Ctr_Always_CallsGetCustomer()
        {
            string customerID = "EXPECTEDID";
            IUIDataProvider uIDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            uIDataProviderMock.Expect(c => c.GetCustomer(customerID)).Return(new Customer());

            CustomerDetailsViewModel target = 
                new CustomerDetailsViewModel(uIDataProviderMock, customerID);

            uIDataProviderMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void Customer_Always_ReturnsCustomerFromGetCustomer()
        {
            const string customerID = "EXPECTEDID";
            Customer customer = new Customer() { CustomerID = customerID };

            IUIDataProvider uIDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();

            uIDataProviderMock.Stub(c => c.GetCustomer(customerID)).Return(customer);

            CustomerDetailsViewModel target = 
                new CustomerDetailsViewModel(uIDataProviderMock, customerID);

            Assert.AreSame(customer, target.Customer);

        }

        [TestMethod]
        public void DisplayName_Always_ReturnsCompanyName()
        {
            const string customerID = "EXPECTEDID";
            const string companyName = "COMPANYNAME";
            Customer customer = new Customer() { CustomerID = customerID, CompanyName = companyName};

            IUIDataProvider uIDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            uIDataProviderMock.Stub(c => c.GetCustomer(customerID)).Return(customer);

            CustomerDetailsViewModel target = 
                new CustomerDetailsViewModel(uIDataProviderMock, customerID);

            Assert.AreSame(target.DisplayName, companyName);


        }
    }
    
}
