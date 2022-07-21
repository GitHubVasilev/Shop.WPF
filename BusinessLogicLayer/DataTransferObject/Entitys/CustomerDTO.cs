namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    public record class CustomerDTO : BaseEntityDTO
    {
        public string? Name { get; init; }
        public string? LastName { get; init; }
        public string? Patronymic { get; init; }
        public string? Phone { get; init; }
    }
}
