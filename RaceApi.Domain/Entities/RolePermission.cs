using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Permission { get; set; } = string.Empty;
    }
}
