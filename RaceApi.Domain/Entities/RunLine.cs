using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Entities
{
    public class RunLine
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        public string LaneKey { get; set; } = string.Empty;
        public int CarId { get; set; }
        public string RacerName { get; set; } = string.Empty;
        public int ReactionTimeMs { get; set; }
        public int ElapsedTimeMs { get; set; }
        public decimal Speed { get; set; }
        public decimal PenaltySeconds { get; set; }
        public int FinalTimeMs { get; set; }
        public bool Winner { get; set; }
    }
}
