using BusinessLogicLayer.DataTransferObject;
using Shop.WPF.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel
{
    /// <summary>
    /// Модель предстваления для авторизации в источнике данных MS SQL
    /// </summary>
    internal class AuthorizationMSSQLDataVM : ValidationBaseViewModel
    {
        public AuthorizationMSSQLDataVM(AuthorizationMSSQLDataDTO? dto=null)
        {
            AuthorizationMSSQLDataDTO _dto = dto ?? new();
            DataSourceName = _dto.DataSourceName ?? "";
        }

        public AuthorizationMSSQLDataDTO BaseModel =>
            new() 
            {
                DataSourceName = DataSourceName
            };

        private string? _dataSourceName;
        /// <summary>
        /// Строка соединения
        /// </summary>
        [Required(ErrorMessage="Not Empty")]
        public string? DataSourceName 
        {
            get => _dataSourceName;
            set => Set(ref _dataSourceName, value, nameof(DataSourceName));
        }
    }
}
