using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string plate { get; set; }

        public string driverName { get; set; }

        public int carClass { get; set; }

    }
}
