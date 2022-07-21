namespace Shop.WPF.Interfaces.Dialogs
{
    internal interface IWarningDialog
    {
        bool? ResultDialog();
        void ShowDialog(string message);
    }
}
