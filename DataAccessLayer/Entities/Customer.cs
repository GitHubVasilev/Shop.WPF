using System;

namespace DataAccessLayer.Entities
{
    public record class Customer : BaseEntity
    {
        public string? Name { get; init; }
        public string? LastName { get; init; }
        public string? Patronymic { get; init; }
        public int? Phone { get; init; }
        public string? Email { get; init; }
    }
}
