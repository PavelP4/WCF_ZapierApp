using System;
using System.Runtime.Serialization;


namespace ZapServiceNS.DataObjects
{
    [DataContract]
    public class ErrorInfo
    {
        [DataMember(Name="code")]
        public int Code { get; set; }
        [DataMember(Name="message")]
        public string Message { get; set; }

        public ErrorInfo() 
        {
            Code = 0;
            Message = string.Empty;
        }

        public ErrorInfo(int Code, string Message)
        {
            this.Code = Code;
            this.Message = Message;
        }
    }
}
