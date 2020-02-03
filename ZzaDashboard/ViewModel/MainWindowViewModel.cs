using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> customers;

        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set
            {
                if (this.customers == value)
                    return;

                this.customers = value;
                this.OnPropertyChanged(nameof(this.Customers));
            }
        }
        private ICustomersRepository Repository { get; set; }

        private Customer customer;
        public Customer Customer
        {
            get { return this.customer; }
            set
            {
                if (this.customer == value)
                    return;

                this.customer = value;
                this.OnPropertyChanged(nameof(this.Customer));
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return this.selectedCustomer; }
            set
            {
                if (this.selectedCustomer == value)
                    return;

                this.selectedCustomer = value;
                this.OnPropertyChanged(nameof(this.SelectedCustomer));
            }
        }
        public MainWindowViewModel()
        {
            this.Customers = new ObservableCollection<Customer>();
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.Repository = new CustomersRepository();
            GetCustomer();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void GetCustomer()
        {
            this.Customers = new ObservableCollection<Customer>(this.Repository.GetCustomersAsync().Result);
        }
    }
}