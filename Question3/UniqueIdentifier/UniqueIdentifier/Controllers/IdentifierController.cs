using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniqueIdentifier.DTOs;
using UniqueIdentifier.Repositories;

namespace UniqueIdentifier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentifierController : ControllerBase
    {
        IIdentityRepository _repository;

        public IdentifierController(IIdentityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("CreateIdentifier")]
        [ProducesResponseType(typeof(IdentityDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IdentityDTO>> CreateIdentifier()
        {
            var id = await _repository.CreateIdentifier();

            return Ok(id);
        }


        [HttpPost("DisableIdentifier")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DisableIdentifier([FromQuery] string id)
        {
            var isDisabled = await _repository.DisableIdentifier(id);

            return Ok(isDisabled ? $"{id} Successfuly disabled" : $"Failed to disable {id}");
        }

    }
}