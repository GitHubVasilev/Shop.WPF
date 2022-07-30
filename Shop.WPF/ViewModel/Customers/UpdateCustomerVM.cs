using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;

namespace Shop.WPF.ViewModel.Customers
{
    internal class UpdateCustomerVM : BaseViewModel
    {
        private readonly IService<CustomerDTO> _service;
        private readonly IDialogsConteiner _dialogsConteiner;

        public UpdateCustomerVM(IService<CustomerDTO> service, IDialogsConteiner dialogConteiner)
        {
            _service = service;
            _dialogsConteiner = dialogConteiner;
        }

        private CustomerVM? _customer;

        public CustomerVM Customer
        {
            get => _customer ?? new CustomerVM();
            set
            {
                _customer = value.Clone() as CustomerVM;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _updateCommand;

        public RelayCommand UpdateCommand 
        {
            get => _updateCommand ??= new RelayCommand(obj => 
            {
                try
                {
                    _service.UpdateAsync(Customer.BaseModel);
                    _dialogsConteiner.MessageDialog.ShowDialog($"Customer {Customer.Name!} has been successfully updated");
                }
                catch (Exception e) 
                {
                    _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                }
            }, _ => Customer.IsValid);
        }
    }
}
