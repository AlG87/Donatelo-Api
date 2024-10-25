using ConexionBD;
using Data.Users;
using Donatelo.Api.Entities;
using System;

namespace Bunisess.Users
{
    public class BusinessuserUpadteById : BusinessStrategy
    {
        private readonly UsuarioDto user;

        public BusinessuserUpadteById(UsuarioDto user)
        {
            this.user = user;
        }
        protected override void Validate()
        {
            
        }
        public override void Process()
        {
            DataUserUpdateById dataUserupdateById = new DataUserUpdateById(user);

            if (dataUserupdateById.Execute() != StateStrategy.Success)
            {
                SetException(dataUserupdateById.Exception);

            }
            else
            {
                SetResult(dataUserupdateById);
            }
        }
    }
}
