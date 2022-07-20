using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WPF.ViewModel.Customers
{
    internal class CustomersVM : BaseViewModel
    {
        public CustomersVM(IService<CustomerDTO> service, )
        {

        }

        public ObservableCollection<CustomerVM> Customers;
    }
}
