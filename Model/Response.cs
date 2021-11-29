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
    public class ResponseFail : Response
    {
        public ResponseFail(string message)
        {
            this.Message = message;
            State = ResponseState.Fail;
        }
    }
    public class ResponseSuccess : Response
    {
        public ResponseSuccess(string message)
        {
            this.Message = message;
            State = ResponseState.Success;
        }
        public ResponseSuccess()
        {
            this.Message = "";
            State = ResponseState.Success;
        }
    }

    public class DataResponse<T>
    {
        public T Data { get; set; }
        public Response Response  {get; set;}
    }
    public class DataResponeFail<T> : DataResponse<T>
    {
        public DataResponeFail(string message)
        {
            Response =new ResponseFail(message);         
        }
    }
    public class DataResponeSuccess<T> : DataResponse<T>
    {
        public DataResponeSuccess(T data)
        {
            Data = data;
            Response = new ResponseSuccess();
        }
    }
    public enum ResponseState
    {
        Success,
        Fail
    }
}
