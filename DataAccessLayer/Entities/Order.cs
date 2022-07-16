namespace DataAccessLayer.Entities
{
    public record class Order
    {
        public Guid Id { get; init; }
        public string? EmailCustomer { get; init; }
        public int Atricle { get; init; }
        public string? NameProduct { get; init; } 
    }
}
