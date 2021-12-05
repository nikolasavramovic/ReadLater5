using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadLater5.Models.Requests;
using ReadLater5.Models.Responses;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadLeter5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        // GET: api/<AuthCon[HttpPost]
        [HttpPost]
        [Route("Login")]
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Post([FromBody] LoginRequest model)
        {
            LoginResponse response = await _authService.LoginApi(model);
            if (response != null)
                return Ok(response);
            else
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
        }


        // POST api/<AuthController>
        [HttpPost]
        [Route("Register")]
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await  _authService.RegisterApi(model);
                if (result.Succeeded)
                    return Ok();
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            else
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

        }

        
    }
}
