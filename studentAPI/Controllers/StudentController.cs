using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace studentAPI.Controllers
{
    public class StudentController : ApiController
    {
        //[Authorize(Roles = "OK, GRAD")]
        [HttpGet]
        [Route("api/studApi")]
        public IHttpActionResult GetStudApi() {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Welcome " + identity.Name);
        }
    }
}
