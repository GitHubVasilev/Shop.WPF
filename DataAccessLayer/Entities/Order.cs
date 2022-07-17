using System;

namespace DataAccessLayer.Entities
{
    public record class Order : BaseEntity
    {
        public string? EmailCustomer { get; init; }
        public int Atricle { get; init; }
        public string? NameProduct { get; init; } 
    }
}
