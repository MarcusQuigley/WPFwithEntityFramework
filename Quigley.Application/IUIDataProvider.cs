using Quigley.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.Application
{
    public interface IUIDataProvider
    {
        IList<Customer> GetCustomers();
    }
}
