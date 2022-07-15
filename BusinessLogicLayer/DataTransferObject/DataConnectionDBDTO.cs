namespace BusinessLogicLayer.DataTransferObject
{
    public record DataConnectionDBDTO
    {
        public string? DataSourceName { get; init; }
        public bool? IsConnected { get; init; }
    }
}
