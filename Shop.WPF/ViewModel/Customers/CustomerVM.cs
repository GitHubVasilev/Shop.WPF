using BusinessLogicLayer.DataTransferObject.Entitys;
using Shop.WPF.ViewModel.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel.Customers
{
    internal class CustomerVM : ValidationBaseViewModel
    {
        public CustomerVM(CustomerDTO? customer = null)
        {
            customer ??= new CustomerDTO();
            Name = customer!.Name;
            Lastname = customer!.LastName;
            Patronymic = customer!.Patronymic;
            Phone = customer!.Phone;
            Email = customer!.Email;
            _UID = customer!.UID;
        }

        private Guid _UID { get; set; }

        public CustomerDTO BaseModel => new CustomerDTO()
        {
            Name = Name,
            LastName = Lastname,
            Patronymic = Patronymic,
            Phone = Phone,
            Email = Email,
            UID = _UID == default ? Guid.NewGuid() : _UID
        };

        private string? _firstName;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Name 
        {
            get => _firstName;
            set => Set(ref _firstName, value, nameof(Name));
        }

        private string? _lastName;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Lastname
        {
            get => _lastName;
            set => Set(ref _lastName, value, nameof(Lastname));
        }

        private string? _patronymic;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value, nameof(Patronymic));
        }

        private string? _email;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Email
        {
            get => _email;
            set => Set(ref _email, value, nameof(Email));
        }

        private string? _phone;
        public string? Phone
        {
            get => _phone;
            set => Set(ref _phone, value, nameof(Phone));
        }

        public string? EmailErrors => GetErrorsString(nameof(Email));
        public string? NameErrors => GetErrorsString(nameof(Name));
        public string? LastnameErrors => GetErrorsString(nameof(Lastname));
        public string? PatronymicErrors => GetErrorsString(nameof(Patronymic));
        public string? PhoneErrors => GetErrorsString(nameof(Phone));
    }
}