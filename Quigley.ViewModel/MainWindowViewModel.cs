using Quigley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.ViewModel
{
   public class MainWindowViewModel
    {
        private IList<Customer> customers;

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
            customers = new NorthwindEntities1().Customers.ToList();
         }
    }
}
