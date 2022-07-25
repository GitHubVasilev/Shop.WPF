using BusinessLogicLayer.DataTransferObject.Entitys;
using BusinessLogicLayer.Interfaces;
using Shop.WPF.Infrastructure;
using Shop.WPF.Interfaces.Dialogs;
using Shop.WPF.ViewModel.Base;
using System;


namespace Shop.WPF.ViewModel.Orders
{
    internal class AddOrderVM : BaseViewModel
    {
        private readonly IService<OrderDTO> _service;
        private readonly IDialogsConteiner _dialogsConteiner;

        public AddOrderVM(IService<OrderDTO> service, IDialogsConteiner dialogConteiner)
        {
            _service = service;
            _dialogsConteiner = dialogConteiner;
            Order = new OrderVM();
        }


        private OrderVM? _order;
        public OrderVM Order 
        {
            get => _order ?? new OrderVM();
            set
            {
                _order = value;
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
                    await _service.Create(Order.BaseModel);
                    _dialogsConteiner.MessageDialog.ShowDialog("Create Order Success");
                }
                catch (Exception e) 
                {
                    _dialogsConteiner.ErrorDialog.ShowDialog(e.Message);
                }
            });
        }

    }
}
