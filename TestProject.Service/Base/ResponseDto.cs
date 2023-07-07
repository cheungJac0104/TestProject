using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Service
{
    public class ResponseDto
    {
        public string Msg { get; set; }
 
        public int Code { get; set; } = 0;

        public bool IsSuccess => Code == 1;
 
        public Object Data { get; set; }
 
        public object Extend { get; set; }


        public static ResponseDto GetByMsg(string msg)
        {
            ResponseDto result = new ResponseDto();
            if (string.IsNullOrEmpty(msg))
            {
                result.Code = 1;
                result.Msg = "Ok";
            }
            else
            {
                result.Code = 0;
                result.Msg = msg;
            }
            return result;
        }
        public static ResponseDto ReturnSuccess(string msg = "", object obj = null)
        {
            if (msg == "")
            {
                msg = "Ok";
            }
            return new ResponseDto() { Code = 1, Msg = msg, Data = obj };
        }
        public static ResponseDto ReturnFail(string msg = "", object obj = null)
        {
            if (msg == "")
            {
                msg = "Failed";
            }
            return new ResponseDto() { Code = 0, Msg = msg, Data = obj };
        }
    }

}
