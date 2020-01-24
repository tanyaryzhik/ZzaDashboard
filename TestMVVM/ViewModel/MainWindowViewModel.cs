using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard;
using ZzaDashboard.Services;

namespace TestMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> CustomersCollection { get; set; }
        private ICustomersRepository Repository { get; set; }
        public ICommand GetCommand { get; set; }
        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.Repository = new CustomersRepository();
            this.GetCommand = new RelayCommand(GetCommandExecute, GetCommandCanExecute);
            this.CustomersCollection = new ObservableCollection<Customer>();
        }
        private bool GetCommandCanExecute(object obj)
        {
            return true;
        }
        private void GetCommandExecute(object obj)
        {
           ObservableCollection<Customer> temp = new ObservableCollection<Customer>(this.Repository.GetCustomersAsync().Result);
            foreach (var item in temp)
            {
                this.CustomersCollection.Add(item);
            }
        }
    }
}
