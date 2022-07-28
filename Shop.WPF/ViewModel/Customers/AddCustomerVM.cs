using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;
using System.Threading.Tasks;

namespace Shop.WPF.ViewModel.Customers
{
    /// <summary>
    /// Модель представления для добавления нового покупателя
    /// </summary>
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

        /// <summary>
        /// Модель представления пользователя для добавления
        /// </summary>
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

        /// <summary>
        /// Комада для добавения нового пользователя
        /// </summary>
        public RelayCommand AddCommand
        {
            get => _addCommand ??= new RelayCommand(async obj => 
            {
                try
                {
                    await Task.Delay(2000);
                    await _service.CreateAsync(Customer.BaseModel);
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
