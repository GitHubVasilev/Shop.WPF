namespace Shop.WPF.Interfaces.Dialogs
{
    internal interface IDialogsConteiner
    {
        IAuthorizationOleDBDialog AuthorizationOleDBDialog { get; }
        IAuthorizationMSSQLDialog AuthorizationMSSQLDialog { get; }
        IErrorDialog ErrorDialog { get; }
    }
}
