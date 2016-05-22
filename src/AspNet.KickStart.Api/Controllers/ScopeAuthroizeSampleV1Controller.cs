using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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