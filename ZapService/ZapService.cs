using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using ZapService.DataAccess;
using ZapService.DataAccess.DataModel;
using ZapServiceNS.DataObjects;
using ZapServiceNS.DataObjects.Requests;
using ZapServiceNS.DataObjects.Responses;


namespace ZapServiceNS
{    
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class ZapService : IZapService
    {
        public string GetOK()
        {
            return "OK!!!";
        }     

        public SubscribeResponse Subscribe(SubscribeRequest request)
        {
            ErrorInfo validateError = Validate_SubscribeRequest(request);

            if (validateError != null)
            {
                return new SubscribeResponse() { Success = false, Error = validateError };
            }

            SubscribeResponse response = new SubscribeResponse();
            ErrorInfo error = null;

            using (DBZapService context = new DBZapService())
            {
                Subscribe newSubscribe = new Subscribe() 
                { 
                    Account_Name = "Anonymous",
                    Target_URL = request.Target_URL,
                    Event = request.Event,
                    Created = DateTime.Now
                };      
                
                try
                {
                    context.Subscribes.Add(newSubscribe);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = new ErrorInfo(0, string.Format("Error saving to the database: {0}", ex.Message));
                }                

                response.SubscribeId = newSubscribe.Id;
            }

            if (error != null)
            {
                return new SubscribeResponse() { Success = false, Error = error };
            }
            else
            {
                return response;
            }
        }

        private ErrorInfo Validate_SubscribeRequest(SubscribeRequest request)
        {
            ErrorInfo error = null;

            if (request == null)
            {
                error = new ErrorInfo(0, "Input data object is null.");
            }
            else
            {
                if (string.IsNullOrEmpty(request.Target_URL))
                {
                    error = new ErrorInfo(0, "The [ Target_URL ] is empty or null.");
                }
                else
                {
                    if (string.IsNullOrEmpty(request.Event))
                    {
                        error = new ErrorInfo(0, "The [ Event ] is empty or null.");
                    }
                }
            }

            return error;
        }


        public UnSubscribeResponse UnSubscribe(string id)
        {
            ErrorInfo validateError = Validate_UnSubscribeRequest(id);

            if (validateError != null)
            {
                return new UnSubscribeResponse() { Success = false, Error = validateError };
            }

            UnSubscribeResponse response = new UnSubscribeResponse();
            ErrorInfo error = null;

            using (DBZapService context = new DBZapService())
            {
                Subscribe delSubscribe = null;

                try
                {
                    delSubscribe = context.Subscribes.Find(int.Parse(id));
                }
                catch (Exception ex)
                {
                    error = new ErrorInfo(0, string.Format("Error serching in the database: {0}", ex.Message));
                }

                if (delSubscribe == null)
                {
                    error = new ErrorInfo(0, string.Format("Data by ID = {0} not found.", id));
                }

                delSubscribe.IsUnsubscribed = true;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = new ErrorInfo(0, string.Format("Error saving to the database: {0}", ex.Message));
                }
            }


            //error = new ErrorInfo(0, string.Format("The [ Id ] = [{0}]", id));            

            if (error != null)
            {
                return new UnSubscribeResponse() { Success = false, Error = error };
            }
            else
            {
                return response;
            }                        
        }

        private ErrorInfo Validate_UnSubscribeRequest(string id)
        {
            ErrorInfo error = null;

            int vId = 0;

            if (int.TryParse(id, out vId))
            {
                if (vId <= 0)
                {
                    error = new ErrorInfo(0, "The [ Id ] is not a valid.");
                }
            }
            else
            {
                error = new ErrorInfo(0, "The [ Id ] is not a numeric value.");
            }

            return error;
        }
    }
}
