using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicFormsServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFormsServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicFormsController : ControllerBase
    {
        public DynamicFormsController()
        {
                
        }

        [HttpGet("GetForms")]
        public ActionResult Get(string request)
        {
            FormControlObject formsContainer = new FormControlObject();
            return Ok(formsContainer);
        }
    }
}