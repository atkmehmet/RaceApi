using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Entities
{
    public class Penalties
    {
        public int id { get; set; }

        public int runId { get; set; }
        
        public int type { get; set; }

        public double timePenalty { get; set; }

        public Boolean disqualified { get; set; }   
    }
}
