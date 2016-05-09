using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace AspNet.KickStart.Api.Controllers
{
    [Route("v1/scopeauth"), Authorize]
    public class ScopeAuthroizeSampleV1Controller : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Json(User.Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}