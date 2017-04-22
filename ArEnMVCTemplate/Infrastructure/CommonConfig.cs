using System.Globalization;
using System.Threading;
using System.Web;

namespace ArEnMVCTemplate
{
    public static class CommonConfig
    {
        public static bool IsRTL
        {
            get
            {
                return (bool)HttpContext.Current.Items["_IsRtl"];
            }
            set
            {
                HttpContext.Current.Items["_IsRtl"] = value;
            }
        }

        public static string CultureInfo
        {
            get
            {
                return HttpContext.Current.Items["_CultureInfo"]?.ToString();
            }
            set
            {
                HttpContext.Current.Items["_CultureInfo"] = value;
            }
        }

        public static void SetCultureFromCookies()
        {
            string lang = HttpContext.Current.Request.Cookies["CurrentUICulture"] == null ?
                "ar-AE" : HttpContext.Current.Request.Cookies["CurrentUICulture"].Value;

            if (null == HttpContext.Current.Request.QueryString["lang"]
                || (HttpContext.Current.Request.QueryString["lang"] != "ar-AE"
                    && HttpContext.Current.Request.QueryString["lang"] != "en-US"))
            {
                lang = lang == "ar-AE" ? lang : "en-US";
            }
            else
            {
                lang = HttpContext.Current.Request.QueryString["lang"] == "en-US" ? "en-US" : "ar-AE";
            }

            if (HttpContext.Current.Request.Cookies["CurrentUICulture"] == null)
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("CurrentUICulture", lang));
            }
            else
            {
                HttpContext.Current.Response.Cookies["CurrentUICulture"].Value = lang;
            }

            IsRTL = lang == "ar-AE";
            CultureInfo = lang;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureInfo);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
        }
    }
}