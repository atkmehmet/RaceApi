using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Common
{
    public class Result<T>
    {
        public Boolean State { get; set; }

        
        public T? Data { get; set; }

        public Result(bool state, T? data)
        {
            State = state;
        
            Data = data;
        }

        public static Result<T> Success(T data)
            {
           
            return new Result<T>(true,data);
             }

        public static Result<T> Failure(T? data) {

            return new Result<T>(false,data);
        }

        
}
}
