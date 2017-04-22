using System.Collections.Generic;
using System.Web.Http;

namespace ArEnMVCTemplate.Controllers
{
    public class CommonController : ApiController
    {
        public ICollection<Alert> Get()
        {
            return ResponseExtensions.GetAndClearAllNotification(null);
        }
    }
}
