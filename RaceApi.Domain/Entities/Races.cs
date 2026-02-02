using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Entities
{
    public class Races
    {
        public int Id { get; set; }

        public DateTime date { get; set; }

        public int status { get; set; }
    }
}
