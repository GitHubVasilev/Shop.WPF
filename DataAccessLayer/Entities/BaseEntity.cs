using System;

namespace DataAccessLayer.Entities
{
    public record class BaseEntity
    {
        public Guid UID { get; init; }
    }
}
