using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepsWebApp.Filter;
using DepsWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepsWebApp.Controllers
{ 
    /// <summary>
    /// Controller registration
    /// </summary>
    [ApiController]
    [Route("/register")]
    [RegisterExceptionFilter]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Return token of registration
        /// </summary>
        /// <param name="register"> login and password</param>
        /// <returns>string</returns>
        [HttpPost]
        [Route("")]
        [RegisterExceptionFilter]
#pragma warning disable IDE0060 // Remove unused parameter
        public ActionResult Register([FromBody] RegisterModel register)

        {
            throw new NotImplementedException();
        }
#pragma warning restore IDE0060 // Remove unused parameter
    }
}
