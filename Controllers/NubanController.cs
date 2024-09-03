using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NubanGenerator.Services;

namespace NubanGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NubanController : ControllerBase
    {
        private readonly INubanService _nubanService;

        public NubanController(INubanService nubanService)
        {
            _nubanService = nubanService;
        }

        [HttpPost("dmb")]
        public ActionResult<string> GenerateNubanDmb([FromBody] NubanRequest request)
        {
            var result = _nubanService.GenerateNubanDmb(request.InstitutionCode, request.SerialNumber);
            return Ok(result);
        }

        [HttpPost("ofi")]
        public ActionResult<string> GenerateNubanOfi([FromBody] NubanRequest request)
        {
            var result = _nubanService.GenerateNubanOfi(request.InstitutionCode, request.SerialNumber);
            return Ok(result);
        }
    }
}