using System;
using System.Runtime.Serialization;


namespace ZapServiceNS.DataObjects.Requests
{
    [DataContract]
    public class UnSubscribeRequest
    {
        [DataMember(Name = "subscription_url")]
        public string Subscription_URL { get; set; }

        [DataMember(Name = "target_url")]
        public string Target_URL { get; set; }

        [DataMember(Name = "subscription_id")]
        public int Subscription_Id { get; set; }

        public ErrorInfo Validate()
        {
            if (Subscription_Id <= 0)
            {
                return new ErrorInfo(0, string.Format("The [ Id = {0}] is not a valid.", Subscription_Id));
            }

            if (Target_URL.Length == 0)
            {
                return new ErrorInfo(0, "The [ Target_URL ] is empty.");
            }

            return null;
        }
    }
}
