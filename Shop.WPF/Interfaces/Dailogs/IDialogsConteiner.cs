namespace Shop.WPF.Interfaces.Dialogs
{
    internal interface IDialogsConteiner
    {
        IAuthorizationOleDBDialog AuthorizationDBDialog { get; }
        IAuthorizationMSSQLDialog AuthorizationMSSQLDialog { get; }
        IErrorDialog ErrorDialog { get; }
    }
}
