namespace BusinessLogicLayer.DataTransferObject
{
    public record class AuthorizationData
    {
        public string? Login { get; init; }
        public string? Password { get; init; }
    }
}
