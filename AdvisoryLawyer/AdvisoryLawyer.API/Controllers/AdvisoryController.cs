using AdvisoryLawyer.Business.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisoryController : ControllerBase
    {
        private readonly IAdvisoryService _advisoryService;

        public AdvisoryController(IAdvisoryService advisoryService)
        {
            _advisoryService = advisoryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAdvisoryById(int id)
        {
            var advisoryModel = _advisoryService.GetAdvisoryById(id);
            return Ok(advisoryModel);
        }
    }
}

