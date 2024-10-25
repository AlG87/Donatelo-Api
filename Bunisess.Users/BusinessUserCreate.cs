using ConexionBD;
using Data.Users;
using Donatelo.Api.Entities;
using System;

namespace Bunisess.Users
{
    public class BusinessUserCreate : BusinessStrategy
    {
        private readonly UsuarioDto userDto;

        public BusinessUserCreate(UsuarioDto userDto)
        {
            this.userDto = userDto;
        }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(userDto.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(userDto.Correo))
                throw new ArgumentException("El correo es obligatorio.");

            if (string.IsNullOrWhiteSpace(userDto.Contraseña))
                throw new ArgumentException("La contraseña es obligatoria.");

            if (userDto.Rol <= 0)
                throw new ArgumentException("El rol es obligatorio y debe ser un valor válido.");

        }
        public override void Process()
        {
            DataUserCreate dataUserCreate = new DataUserCreate(userDto);

            if (dataUserCreate.Execute() != StateStrategy.Success)
            {
                SetException(dataUserCreate.Exception);

            }
            else
            {
                SetResult(dataUserCreate);
            }
        }
    }
}
