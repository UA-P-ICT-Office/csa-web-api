﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace testWebApi.Controllers
{
    public class TestController : ApiController
    {

        /*Authorizes user depending on role
        Tested on Postman with no errors 
        Still working on modifying the code for student accounts*/

        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/test/resource1")]

        public IHttpActionResult GetResource1() {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        [Route("api/test/resource2")]

        public IHttpActionResult GetResource2() {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                    .FirstOrDefault(c => c.Type == "Email").Value;
            var UserName = identity.Name;

            return Ok("Hello " + UserName + ", your Email ID is: " + Email);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/test/resource3")]
        
        public IHttpActionResult GetResource3() {
            var identiy = (ClaimsIdentity)User.Identity;
            var roles = identiy.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value);
            return Ok("Hello " + identiy.Name + ", your role(s) are: " + string.Join(",", roles.ToList()));
        }
    }
}