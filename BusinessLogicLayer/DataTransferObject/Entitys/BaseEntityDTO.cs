namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    public record class BaseEntityDTO 
    {
        public Guid UID { get; init; }
        public string? Email { get; init; }
    }
}
