using Quigley.Application;
using Quigley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.ViewModel
{
    public class CustomerDetailsViewModel : ToolViewModel
    {
        
        IUIDataProvider dataProvider;
        public CustomerDetailsViewModel(IUIDataProvider dataProvider, string customerID)
        {
            this.dataProvider = dataProvider;
            this.Customer = dataProvider.GetCustomer(customerID);
            this.DisplayName = Customer.CompanyName;
        }

        public Customer Customer { get; set; }
    }


}
