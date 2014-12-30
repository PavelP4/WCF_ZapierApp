using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.ServiceModel;
using ZapService.DataAccess;
using ZapService.DataAccess.DataModel;
using ZapServiceNS.DataObjects;
using ZapServiceNS.DataObjects.Requests;
using ZapServiceNS.DataObjects.Responses;
using System.ServiceModel.Web;
using System.Net;


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
            WebOperationContext ctx = WebOperationContext.Current;

            ErrorInfo validateError = request.Validate();
            if (validateError != null)
            {
                ctx.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
                return new SubscribeResponse() { Success = false, Error = validateError };
            }

            SubscribeResponse response = new SubscribeResponse();
            ErrorInfo error = null;

            using (DBZapService context = new DBZapService())
            {
                Subscribe newSubscribe = new Subscribe() 
                {
                    Account_Name = request.Account_Name,
                    Subscription_URL = request.Subscription_URL,
                    Target_URL = request.Target_URL,
                    Event = request.Event,
                    Created = DateTime.Now
                };      
                
                try
                {
                    context.Subscribes.Add(newSubscribe);
                    context.SaveChanges();

                    response.Subscription_Id = newSubscribe.Id;
                }
                catch (Exception ex)
                {
                    error = new ErrorInfo(0, string.Format("Error saving to the database: {0}", ex.Message));
                }                       
            }

            if (error != null)
            {
                ctx.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return new SubscribeResponse() { Success = false, Error = error };
            }
            else
            {                
                ctx.OutgoingResponse.StatusCode = HttpStatusCode.Created;
                return response;
            }
        }


        public UnSubscribeResponse UnSubscribe(UnSubscribeRequest request)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            
            ErrorInfo validateError = request.Validate();
            if (validateError != null)
            {
                ctx.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
                return new UnSubscribeResponse() { Success = false, Error = validateError };
            }

            UnSubscribeResponse response = new UnSubscribeResponse();
            ErrorInfo error = null;

            using (DBZapService context = new DBZapService())
            {
                Subscribe delSubscribe = null;

                try
                {
                    delSubscribe = context.Subscribes.Find(request.Subscription_Id);
                }
                catch (Exception ex)
                {
                    error = new ErrorInfo(0, string.Format("Error serching in the database: {0}", ex.Message));
                }

                if (delSubscribe == null)
                {
                    error = new ErrorInfo(0, string.Format("Data by [ ID = {0} ] not found.", request.Subscription_Id));
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

            if (error != null)
            {
                ctx.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return new UnSubscribeResponse() { Success = false, Error = error };
            }
            else
            {
                ctx.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                return response;
            }                        
        }



        public DevicesResponse Devices()
        {
            DevicesResponse response = new DevicesResponse();
            ErrorInfo error = null;

            using (DBZapService context = new DBZapService())
            {
                try
                {
                    response.Devices = context.Devices.ToList<Device>();
                }
                catch (Exception ex)
                {
                    error = new ErrorInfo(0, string.Format("Cannot get devices list: {0}", ex.Message));
                }
            }

            if (error != null)
            {
                return new DevicesResponse() { Success = false, Error = error };
            }
            else
            {
                return response;
            } 
        }
    }
}
