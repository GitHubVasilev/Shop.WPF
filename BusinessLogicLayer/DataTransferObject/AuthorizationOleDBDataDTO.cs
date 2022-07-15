namespace BusinessLogicLayer.DataTransferObject
{
    public record class AuthorizationOleDBDataDTO : BaseAuthorizationDB
    {
        public string? Login { get; init; }
        public string? Password { get; init; }
    }
}
