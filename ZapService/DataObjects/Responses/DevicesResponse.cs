using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ZapService.DataAccess.DataModel;


namespace ZapServiceNS.DataObjects.Responses
{
    [DataContract]
    public class DevicesResponse: BaseResponse
    {
        [DataMember(Name="devices")]
        public List<Device> Devices { get; set; }
    }
}
