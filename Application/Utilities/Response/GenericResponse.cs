using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities.Response
{
    public class GenericResponse<T>
    {
        public bool IsSuccess { get; set; }=false;
        public T Data { get; set; }
        public List<string> ValidationErrors { get; set; }
        public string Message { get; set; }

    }
}
