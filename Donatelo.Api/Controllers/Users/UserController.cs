using Bunisess.Users;
using ConexionBD;
using Data.Users;
using Donatelo.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api.Controllers.Users
{
    public class UserController : CommonController
    {
       
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UsuarioDto user)
        {
            BusinessUserCreate businessUserCreate = new BusinessUserCreate(user);
            return Execute(businessUserCreate);
        }

        [HttpGet]
        [Route("Id")]
        public IActionResult GetById(int? id)
        {
            BusinessUserGetById businessUserGetById = new BusinessUserGetById(id);
            return Execute(businessUserGetById);
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAll()
        {
            BusinessUserGetAll businessUserGetAll = new BusinessUserGetAll();
            return Execute(businessUserGetAll);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateById(UsuarioDto user)
        {
            BusinessuserUpadteById businessuserUpadteById = new BusinessuserUpadteById(user);
            return Execute(businessuserUpadteById);
        }

    }
}
