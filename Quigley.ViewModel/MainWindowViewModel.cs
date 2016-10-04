using Quigley.Application;
using Quigley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.ViewModel
{
   public class MainWindowViewModel 
    {
       readonly IUIDataProvider uIDataProvider;

       public string Name
       {
           get { return "Northwind"; }
       }
       public string ControlPanelName
       {
           get { return "Control Panel"; }
       }
       private IList<Customer> customers;

       public MainWindowViewModel(IUIDataProvider uiDataProvider)
       {
           this.uIDataProvider = uiDataProvider;
       }
 
        public IList<Customer> Customers
        {
            get
            {
                if (customers == null)
                     GetCustomers();

                return customers;
            }
        }

        private void GetCustomers()
        {
            customers = uIDataProvider.GetCustomers();
        }
    }
}
