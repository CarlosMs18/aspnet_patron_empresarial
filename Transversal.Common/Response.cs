using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; } 

        public string Message { get; set; } 

        //propeidad para devolver las solicitues fallidas mediante el FluentValidation
        public IEnumerable<ValidationFailure> Errors { get; set; } 
    }
}
