using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hmsd.encryption.Models;
using hmsd.gateway.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hmsd.gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class EncryptionController : ControllerBase
    {
        private readonly IEncryptionService _encryptionService;
        public EncryptionController(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }
        // POST api/encrypt
        [HttpPost("encrypt")]
        public ActionResult<DecryptMessageModel> Encrypt([FromBody] EncryptMessageModel input)
        {
            return Ok(_encryptionService.EncryptAsync(input));
        }

        // POST api/decrypt
        [HttpPost("decrypt")]
        public ActionResult<EncryptMessageModel> Decrypt([FromBody] DecryptMessageModel input)
        {
            return Ok(_encryptionService.DecryptAsync(input));
        }


        // PUT api/key
        [HttpPut("key")]
        public async Task<IActionResult> Put()
        {
            // can get a value from the request and pass it to the rotation method in the future
            await _encryptionService.UpdateKeyAsync();
            return Accepted();
        }
    }
}
