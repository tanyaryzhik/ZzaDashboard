﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zza.Data;
using ZzaDashboard.Services;
using ZzaDashboard.ViewModel;

namespace ZzaDashboard.View
{
    public partial class CustomerEditView : UserControl
    {
        private ICustomersRepository _repository = new CustomersRepository();

        public CustomerEditView()
        {
  //          this.DataContext = new CustomerEditViewModel();
            InitializeComponent();
        }
    }
}