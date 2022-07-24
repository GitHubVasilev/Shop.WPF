using BusinessLogicLayer.DataTransferObject.Entitys;
using Shop.WPF.ViewModel.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel.Orders
{
    internal class OrderVM : ValidationBaseViewModel
    {
        public OrderVM(OrderDTO? order = null)
        {
            OrderDTO orderDTO = order ?? new OrderDTO();
            _UID = orderDTO.UID == default ? Guid.NewGuid() : orderDTO.UID;
            Email = orderDTO.Email;
            Article = orderDTO.Atricle;
            NameProduct = orderDTO.NameProduct;
        }

        public OrderDTO BaseModel => new OrderDTO()
        {
            UID = _UID,
            NameProduct = NameProduct,
            Email = Email,
            Atricle = Article,
        };

        private Guid _UID { get; set; }

        private string? _email;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? Email 
        {
            get => _email;
            set => Set(ref _email, Email, nameof(Email));
        }

        private string? _nameProduct;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string? NameProduct 
        {
            get => _nameProduct;
            set => Set(ref _nameProduct, value, nameof(NameProduct));
        }

        private int _article;
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int Article 
        {
            get => _article;
            set => Set(ref _article, Article, nameof(Article));
        }
    }
}
