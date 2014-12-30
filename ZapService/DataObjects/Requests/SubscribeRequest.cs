using System;
using System.Runtime.Serialization;


namespace ZapServiceNS.DataObjects.Requests
{
    [DataContract]
    public class SubscribeRequest
    {
        [DataMember(Name = "subscription_url")]
        public string Subscription_URL { get; set; }

        [DataMember(Name = "target_url")]
        public string Target_URL { get; set; }

        [DataMember(Name = "event")]
        public string Event { get; set; }

        [DataMember(Name = "account_name")]
        public string Account_Name { get; set; }

        public ErrorInfo Validate()
        {
            if (Target_URL.Length == 0)
            {
                return new ErrorInfo(0, "The [ Target_URL ] is empty.");
            }

            if (Event.Length == 0)
            {
                return new ErrorInfo(0, "The [ Event ] is empty.");
            }

            if (Account_Name.Length == 0)
            {
                return new ErrorInfo(0, "The [ Account_Name ] is empty.");
            }

            return null;
        }
    }
}
