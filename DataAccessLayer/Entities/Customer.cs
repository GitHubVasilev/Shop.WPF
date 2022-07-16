namespace DataAccessLayer.Entities
{
    public record class Customer
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? LastName { get; init; }
        public string? Patronymic { get; init; }
        public int? Phone { get; init; }
        public string? Email { get; init; }
    }
}
