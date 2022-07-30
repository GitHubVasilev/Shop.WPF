using BusinessLogicLayer.DataTransferObject.Entitys;
using Shop.WPF.ViewModel.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel.Customers
{
    /// <summary>
    /// Модель представления для покупателя
    /// </summary>
    internal class CustomerVM : ValidationBaseViewModel, ICloneable
    {
        public CustomerVM(CustomerDTO? customer = null)
        {
            customer ??= new CustomerDTO();
            Name = customer!.Name ?? "";
            Lastname = customer!.LastName ?? "";
            Patronymic = customer!.Patronymic ?? "";
            Phone = customer!.Phone ?? "";
            Email = customer!.Email ?? "";
            _UID = customer!.UID;
        }

        private Guid _UID { get; set; }
        /// <summary>
        /// Модель для передачи данных
        /// </summary>
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
        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Name 
        {
            get => _firstName;
            set => Set(ref _firstName, value, nameof(Name));
        }

        private string? _lastName;
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Lastname
        {
            get => _lastName;
            set => Set(ref _lastName, value, nameof(Lastname));
        }

        private string? _patronymic;
        /// <summary>
        /// Отчество
        /// </summary>
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value, nameof(Patronymic));
        }

        private string? _email;
        /// <summary>
        /// Почтовый ящик
        /// </summary>
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Email
        {
            get => _email;
            set => Set(ref _email, value, nameof(Email));
        }

        private string? _phone;
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone
        {
            get => _phone;
            set => Set(ref _phone, value, nameof(Phone));
        }

        public object Clone()
        {
            return new CustomerVM(BaseModel)
            {
                Name = (string)(Name ?? "").Clone(),
                Lastname = (string)(Lastname ?? "").Clone(),
                Patronymic = (string)(Patronymic ?? "").Clone(),
                Email = (string)(Email ?? "").Clone(),
                Phone = Phone
            };
        }
    }
}