using Quigley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.Application
{
    public class UIDataProvider : IUIDataProvider
    {
        private NorthwindEntities1 entities = new NorthwindEntities1();

        public IList<Data.Customer> GetCustomers()
        {
            return entities.Customers.ToList();
        }

        public Customer GetCustomer(string customerID)
        {
            return entities.Customers.Single(
                c => c.CustomerID == customerID);
        }
    }
}
