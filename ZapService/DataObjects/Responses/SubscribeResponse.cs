using System;
using System.Runtime.Serialization;

namespace ZapServiceNS.DataObjects.Responses
{
    [DataContract]
    public class SubscribeResponse : BaseResponse
    {
        [DataMember(Name="subscribeid")]
        public int SubscribeId { get; set; }

        public SubscribeResponse()
        {
            SubscribeId = -1;
        }
    }
}
