using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class Response
    {
        public ResponseState State { get; set; }
        public string Message { get; set; }
    }
    public class DataResponse<T>
    {
        public T Data { get; set; }
        public Response Response  {get; set;}
    }
    public enum ResponseState
    {
        Success,
        Fail
    }
}
