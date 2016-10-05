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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShowCustomerDetails_SelectedCustomerIDIsNull_ThrowsInvalidOperationException()
        {
            MainWindowViewModel target = new MainWindowViewModel(null);
            target.ShowCustomerDetails();
        }

        [TestMethod]
        public void ShowCustomerDetails_ToolNotFound_AddNewTool()
        {
            const string customerID = "EXPECTEDID";
            Customer customer = new Customer(){CustomerID = customerID};
            //MainWindowViewModel target = GetShowCustomerDetailsTarget(customer);
            MainWindowViewModel target = GetShowCustomerDetailsTarget2(customerID);
            target.Tools.OfType<CustomerDetailsViewModel>()
                .FirstOrDefault(c => c.Customer.CustomerID == customerID);
        }


        private static MainWindowViewModel GetShowCustomerDetailsTarget(Customer customer)
        {
            IUIDataProvider dataprovider = MockRepository.GenerateMock<IUIDataProvider>();

            MainWindowViewModel target = new MainWindowViewModel(dataprovider);
            target.SelectedCustomerID = customer.CustomerID;
            dataprovider.Stub(c => c.GetCustomer(customer.CustomerID)).Return(customer);
            return target;
        }
        private static MainWindowViewModel GetShowCustomerDetailsTarget2(string customerID)
        {
            IUIDataProvider dataprovider = MockRepository.GenerateMock<IUIDataProvider>();

            MainWindowViewModel target = new MainWindowViewModel(dataprovider);
            target.SelectedCustomerID = customerID;
           // dataprovider.Stub(c => c.GetCustomer(customer.CustomerID)).Return(customer);
            return target;
        }
    }

     
}
