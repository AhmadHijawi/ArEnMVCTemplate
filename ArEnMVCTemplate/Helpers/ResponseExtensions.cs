using System.Collections.Generic;
using System.Web;

namespace ArEnMVCTemplate
{
    public static class ResponseExtensions
    {
        private static string sessionKey = "_ResponseMessages";

        public static HttpResponseBase WithError(this HttpResponseBase response, string message)
        {
            if (HttpContext.Current.Session[sessionKey] == null)
                HttpContext.Current.Session[sessionKey] = new List<Alert>();

            ((List<Alert>)HttpContext.Current.Session[sessionKey]).Add(new Alert() { Message = message, MessageType = MessageTypes.ErrorCode });

            return response;
        }
        
        public static HttpResponseBase WithWarning(this HttpResponseBase response, string message)
        {
            if (HttpContext.Current.Session[sessionKey] == null)
                HttpContext.Current.Session[sessionKey] = new List<Alert>();

            ((List<Alert>)HttpContext.Current.Session[sessionKey]).Add(new Alert() { Message = message, MessageType = MessageTypes.WarningCode });

            return response;
        }

        public static HttpResponseBase WithInfo(this HttpResponseBase response, string message)
        {
            if (HttpContext.Current.Session[sessionKey] == null)
                HttpContext.Current.Session[sessionKey] = new List<Alert>();

            ((List<Alert>)HttpContext.Current.Session[sessionKey]).Add(new Alert() { Message = message, MessageType = MessageTypes.InfoCode });

            return response;
        }

        public static HttpResponseBase WithSuccess(this HttpResponseBase response, string message)
        {
            if (HttpContext.Current.Session[sessionKey] == null)
                HttpContext.Current.Session[sessionKey] = new List<Alert>();

            ((List<Alert>)HttpContext.Current.Session[sessionKey]).Add(new Alert() { Message = message, MessageType = MessageTypes.SuccessCode });

            return response;
        }

        public static HttpResponseBase WithNotification(this HttpResponseBase response, Alert notifcation)
        {
            if (HttpContext.Current.Session[sessionKey] == null)
                HttpContext.Current.Session[sessionKey] = new List<Alert>();

            ((List<Alert>)HttpContext.Current.Session[sessionKey]).Add(notifcation);

            return response;
        }

        public static List<Alert> GetAllNotification(this HttpResponseBase response)
        {
            return HttpContext.Current.Session[sessionKey] as List<Alert> ?? new List<Alert>();
        }

        public static void ClearAllNotification(this HttpResponseBase response)
        {
            HttpContext.Current.Session[sessionKey] = null;
        }

        public static List<Alert> GetAndClearAllNotification(this HttpResponseBase response)
        {
            List<Alert> all = HttpContext.Current.Session[sessionKey] as List<Alert> ?? new List<Alert>();

            response.ClearAllNotification();

            return all;
        }
    }
}