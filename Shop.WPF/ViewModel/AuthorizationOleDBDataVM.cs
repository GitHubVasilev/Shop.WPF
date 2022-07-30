using BusinessLogicLayer.DataTransferObject;
using Shop.WPF.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace Shop.WPF.ViewModel
{
    /// <summary>
    /// Модель предстваления для авторизации в источнике данных MS Access
    /// </summary>
    internal class AuthorizationOleDBDataVM : ValidationBaseViewModel
    {
        public AuthorizationOleDBDataVM(AuthorizationOleDBDataDTO? dto=null)
        {
            AuthorizationOleDBDataDTO _dto = dto ?? new();
            DataSourceName = _dto.DataSourceName ?? "";
            Login = _dto.Login ?? "";
            Password = _dto.Password ?? "";
        }

        public AuthorizationOleDBDataDTO BaseModel =>
            new AuthorizationOleDBDataDTO()
            {
                DataSourceName = DataSourceName,
                Login = Login,
                Password = Password
            };

        private string? _dataSourceName;
        /// <summary>
        /// Строка подключения
        /// </summary>
        [Required(ErrorMessage = "Not Empty")]
        public string? DataSourceName
        {
            get => _dataSourceName;
            set => Set(ref _dataSourceName, value, nameof(DataSourceName));
        }

        private string? _login;
        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "Not Empty")]
        public string? Login 
        {
            get => _login;
            set => Set(ref _login, value, nameof(Login));
        }

        private string? _password;
        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Not Empty")]
        public string? Password 
        {
            get => _password;
            set => Set(ref _password, value, nameof(Password));
        }
    }
}
