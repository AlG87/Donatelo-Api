using Bunisess.Users;
using ConexionBD;
using Data.Users;
using Donatelo.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api.Controllers.Users
{
    public class UserController : CommonController
    {
       
        [HttpPut]
        [Route("Create")]
        public IActionResult Create(UsuarioDto user)
        {
            BusinessUserCreate businessUserCreate = new BusinessUserCreate(user);
            return Execute(businessUserCreate);
        }

    }
}
