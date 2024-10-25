using ConexionBD;
using Data.Users;
using Donatelo.Api.Entities;
using System;

namespace Bunisess.Users
{
    public class BusinessUserGetById: BusinessStrategy
    {
        private readonly int? id;

        public BusinessUserGetById(int? id)
        {
            this.id = id;
        }
        protected override void Validate()
        {
            if (id is null)
                throw new ArgumentException("El id es obligatorio.");
        }
        public override void Process()
        {
            DataUserGetByID dataUserGetById = new DataUserGetByID(id);

            if (dataUserGetById.Execute() != StateStrategy.Success)
            {
                SetException(dataUserGetById.Exception);

            }
            else
            {
                SetResult(dataUserGetById);
            }
        }
    }
}
