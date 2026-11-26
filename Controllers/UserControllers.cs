using IsakSiteApi.Dtos;
using IsakSiteApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IsakSiteApi.Controllers
{
    [ApiController]
  
    public class UserControllers : ControllerBase
    {

        private readonly IUser _service;

        public UserControllers(IUser service) =>
            _service = service;


        [HttpPost("api/create")]

        public async Task<ActionResult> CreateUser(UserCreateDto dto)
        {
            var result = await _service.CreateUser(dto);

            if (result == Enums.EUser.AlreadyExists) return Conflict("Can only have one user");

            return Created();
        }

    }
}
