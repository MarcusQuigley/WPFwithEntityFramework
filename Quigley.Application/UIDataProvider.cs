using Quigley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.Application
{
    public class UIDataProvider : IUIDataProvider
    {
        public IList<Data.Customer> GetCustomers()
        {
            return new  NorthwindEntities1().Customers.ToList();
        }
    }
}
