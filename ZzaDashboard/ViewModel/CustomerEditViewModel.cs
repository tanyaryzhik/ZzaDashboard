using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    public class CustomerEditViewModel
    {
        public Customer Customer { get; set; }
        private ICustomersRepository Repository { get; set; }
        public ICommand SaveCommand { get; set; }
        public CustomerEditViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.Repository = new CustomersRepository();
            this.SaveCommand = new RelayCommand(SaveCommandExecute, SaveCommandCanExecute);
            GetCustomer();
        }

        public void GetCustomer()
        {
            this.Customer = this.Repository.GetCustomerAsync(new Guid("11DA4696-CEA3-4A6D-8E83-013F1C479618")).Result;
        }

        private async void SaveCommandExecute(object obj)
        {
           await this.Repository.UpdateCustomerAsync(this.Customer);
        }

        public bool SaveCommandCanExecute(object obj)
        {
            if (String.IsNullOrWhiteSpace(this.Customer.FirstName) || String.IsNullOrWhiteSpace(this.Customer.LastName) || String.IsNullOrWhiteSpace(this.Customer.Phone))
                return false;

            return true;
        }
    }
}