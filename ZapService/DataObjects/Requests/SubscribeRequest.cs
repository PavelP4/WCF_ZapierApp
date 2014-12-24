using System;
using System.Runtime.Serialization;


namespace ZapServiceNS.DataObjects.Requests
{
    [DataContract]
    public class SubscribeRequest
    {
        [DataMember(Name="targer_url")]
        public string Target_URL { get; set; }

        [DataMember(Name = "event")]
        public string Event { get; set; }
    }
}
