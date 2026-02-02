using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Entities
{
    public class Runs
    {
        public int  id { get; set; }
        public int  raceId { get; set; }

        public int carId { get; set; }

        public double elapsedTime { get; set; }
      

        public double   reactionTime { get; set; }
    }
}
