using Quigley.Application;
using Quigley.Data;
using Quigley.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

namespace Quigley.ViewModel
{
   public class MainWindowViewModel 
    {
       readonly IUIDataProvider uIDataProvider;
        private IList<Customer> customers;
        private ICommand customerGetCommand;

        public MainWindowViewModel(IUIDataProvider uiDataProvider)
        {
            this.uIDataProvider = uiDataProvider;

            Tools = new ObservableCollection<ToolViewModel>() ;
        }

       public string Name
       {
           get { return "Northwind"; }
       }
       public string ControlPanelName
       {
           get { return "Control Panel"; }
       }

       public String SelectedCustomerID { get; set; }
 
       public IList<Customer> Customers
        {
            get
            {
                if (customers == null)
                     GetCustomers();

                return customers;
            }
        }

       public ICommand CustomerGetCommand
       {
           get {
               if (customerGetCommand == null)
               {
                   customerGetCommand = new RelayCommand((o) => GetCustomer(), 
                       (o) => { return !string.IsNullOrEmpty(SelectedCustomerID); });
               }
               return customerGetCommand;
           }
       }

       private void GetCustomer()
       {
           if (string.IsNullOrEmpty(SelectedCustomerID))
               throw new InvalidOperationException("need a customerD");

           CustomerDetailsViewModel custVM = GetCustomerDetailsTool(SelectedCustomerID);
           if (custVM ==null)
           {
               custVM = new CustomerDetailsViewModel(uIDataProvider, SelectedCustomerID);
               Tools.Add(custVM);
           }
           SetCurrentTool(custVM);

       }

       private void SetCurrentTool(CustomerDetailsViewModel custVM)
       {
           ICollectionView view = CollectionViewSource.GetDefaultView(this.Tools);
           if (view != null)
           {
               if (!view.MoveCurrentTo(custVM))
                   throw new InvalidOperationException("Cant find tool");
           }
       }

       CustomerDetailsViewModel GetCustomerDetailsTool(string customerID)
       {
           return Tools.OfType<CustomerDetailsViewModel>()
               .FirstOrDefault(c => c.Customer.CustomerID == customerID);
       }

       
        private void GetCustomers()
        {
            customers = uIDataProvider.GetCustomers();
        }

        public ObservableCollection<ToolViewModel> Tools { get; set; }
    }
}
