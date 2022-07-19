using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    public record class CustomerDTO : BaseEntityDTO
    {
        public string? Name { get; init; }
        public string? LastName { get; init; }
        public string? Patronymic { get; init; }
        public int? Phone { get; init; }
    }
}
