using Shop.WPF.Infrastructure;
using Shop.WPF.ViewModel.Base;

namespace Shop.WPF.ViewModel
{
    internal class DataSourceConnectVM : BaseViewModel
    {
        public DataSourceConnectVM()
        {

        }

        private string? _dataSourceName;

        public string? DataSourceName 
        {
            get { return _dataSourceName; }
            set 
            {
                _dataSourceName = value;
                OnPropertyChanged();
            }
        }
        
        private int? _isConnect;

        public int IsConnect 
        {
            get { return _isConnect ?? 0; }
            set 
            {
                _isConnect = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _connectCommand;

        public RelayCommand ConnectCommand 
        {
            get => _connectCommand ??= new RelayCommand(obj =>
            {

            }, _ => IsConnect == 0);
        }

    }
}
