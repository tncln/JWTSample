using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KimlikController : ControllerBase
    {
        // api/Kimlik/GirisYap
        [HttpGet("[action]")]
        public IActionResult GirisYap()
        {
            return Created("", new TokenCreate().TokenOlustur());
        }
        [HttpGet("[action]")]
        public IActionResult AdminGirisYap()
        {
            return Created("", new TokenCreate().TokenAdminRoleOlustur());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Erisim()
        {
            return Ok("token geçti");
        }
        [Authorize(Roles ="Admin,Member")]
        [HttpGet("[action]")]
        public IActionResult AdminErisim()
        {
            return Ok("token geçti");
        }
    }
}
