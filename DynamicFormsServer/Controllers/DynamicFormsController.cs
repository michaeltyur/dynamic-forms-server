using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicFormsServer.BL;
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
            int reportId = 0;
            if (int.TryParse(request, out reportId))
            {
                FormControlObject formsContainer = FormHelper.GetReportForm(reportId);
                return Ok(formsContainer);
            }
            else
            {
                return NotFound("report id is incorrect");
            }
        }

        [HttpGet("GetReportsTitles")]
        public ActionResult GetReportsTitles()
        {
            List<string> list = FormHelper.GetAllReportFormTitles();
            return Ok(list);
        }
    }
}