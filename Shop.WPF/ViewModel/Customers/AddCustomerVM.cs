using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;

namespace Shop.WPF.ViewModel.Customers
{
    internal class AddCustomerVM : BaseViewModel
    {
        private readonly IService<CustomerDTO> _service;
        private readonly IDialogsConteiner _dialogsConteiner;

        public AddCustomerVM(IService<CustomerDTO> service, IDialogsConteiner dialogConteiner)
        {
            _dialogsConteiner = dialogConteiner;
            _service = service;
            _customer = new CustomerVM();
        }

        private CustomerVM _customer;

        public CustomerVM Customer 
        {
            get => _customer;
            set 
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _addCommand;

        public RelayCommand AddCommand
        {
            get => _addCommand ??= new RelayCommand(async obj => 
            {
                try
                {
                    await _service.Create(Customer.BaseModel);
                    _dialogsConteiner.MessageDialog.ShowDialog("Create Customer Success");
                }
                catch (Exception e) 
                {
                    _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                }
            }, _ => !Customer.HasErrors);
        }
    }
}
