using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Common
{
    public class ValidationError
    {
        public string errorMessage { get; set; }

        public string fieldName { get; set; }
    }
}
