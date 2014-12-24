using System;
using System.Runtime.Serialization;

namespace ZapServiceNS.DataObjects.Requests
{
    [DataContract]
    public class UnSubscribeRequest
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
    }
}
