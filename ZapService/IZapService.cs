using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Http;
using ZapServiceNS.DataObjects.Requests;
using ZapServiceNS.DataObjects.Responses;

namespace ZapServiceNS
{
    [ServiceContract(Namespace = "http://www.zapservice.com/")]
    public interface IZapService
    {            
        [OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "api/test", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [WebGet(UriTemplate = "api/test", ResponseFormat = WebMessageFormat.Json)]
        [Description("Description for GET api/test [GetOK]")]
        string GetOK();
                
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "api/hooks", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SubscribeResponse Subscribe(SubscribeRequest request);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "api/hooks/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UnSubscribeResponse UnSubscribe(string id);
    }

}
