using Business.Publications;
using Donatelo.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api.Controllers.Publications
{
    public class PublicationController : CommonController
    {

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(PublicacionDto pubication)
        {
            BusinessPublicationCreate businessPublicationCreate = new BusinessPublicationCreate(pubication);
            return Execute(businessPublicationCreate);
        }

        /*
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

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteById(int id)
        {
            businessUserDeleteById businessUserDeleteById = new businessUserDeleteById(id);
            return Execute(businessUserDeleteById);
        }*/
    }
}
