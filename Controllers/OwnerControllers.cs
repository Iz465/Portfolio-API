using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;
using IsakSiteApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IsakSiteApi.Controllers
{
    [ApiController]
    [Route("api/owner")]
    public class OwnerControllers : ControllerBase
    {

        private readonly IOwner _services;

        public OwnerControllers(IOwner services) =>
            _services = services;

        [HttpGet]
        public async Task<OwnerDto?> GetOwner() =>
            await _services.GetOwner();

        [HttpPost]
        public async Task<ActionResult> CreateOwner(OwnerCreateDto dto)
        {
            var result = await _services.CreateOwner(dto);

            if(result == EOwner.AlreadyExists) return Conflict();
                
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOwner(OwnerUpdateDto dto)
        {
            var result = await _services.UpdateOwner(dto);

            if (result == EOwner.NotFound) return NotFound();

            return Ok();
        }
       
    }
}
