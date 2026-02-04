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

        public List<ValidationError> Errors { get; set; }

        public T? Data { get; set; }

        public Result(bool state, T? data, List<ValidationError> errors = null)
        {
            State = state;
            Errors = errors;
            Data = data;
        }

        public static Result<T> Success(T data)
            {
           
            return new Result<T>(true,data);
             }

        public static Result<T> Failure(List<ValidationError> errors) {

            return new Result<T>(false,default,errors);
        }

        public static Result<T> Failure(ValidationError error) { 
        
            return new Result<T>(false,default,)
        }
}
}
