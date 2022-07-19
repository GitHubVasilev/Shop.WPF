namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    public record class OrderDTO : BaseEntityDTO
    {
        public int Atricle { get; init; }
        public string? NameProduct { get; init; }
    }
}
