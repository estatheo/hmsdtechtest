using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hmsd.encryption.Interfaces;
using hmsd.encryption.Models;
using Microsoft.AspNetCore.Mvc;

namespace hmsd.encryption.Controllers
{
    [Route("api")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private IEncryptionService _encryptionService;
        public EncryptionController(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }
        // POST api/encrypt
        [HttpPost("encrypt")]
        public ActionResult<DecryptMessageModel> Encrypt([FromBody] EncryptMessageModel input)
        {
            return Ok(new DecryptMessageModel
            {
                data = _encryptionService.Encrypt(input.secret)
            });
        }

        // POST api/decrypt
        [HttpPost("decrypt")]
        public ActionResult<EncryptMessageModel> Decrypt([FromBody] DecryptMessageModel input)
        {
            return Ok(new EncryptMessageModel()
            {
                secret = _encryptionService.Decrypt(input.data)
            });
        }


        // PUT api/key
        [HttpPut("key")]
        public IActionResult Put()
        {
            // can get a value from the request and pass it to the rotation method in the future
            _encryptionService.UpdateKey(Guid.NewGuid().ToString());
            return Accepted();
        }

    }
}
