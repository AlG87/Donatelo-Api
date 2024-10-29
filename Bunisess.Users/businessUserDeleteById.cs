using ConexionBD;
using Data.Users;
using System;

namespace Bunisess.Users
{
    public class businessUserDeleteById: BusinessStrategy
    {
        private readonly int? id;

        public businessUserDeleteById(int? id)
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
            DatauserDeleteById datauserDeleteById = new DatauserDeleteById(id);

            if (datauserDeleteById.Execute() != StateStrategy.Success)
            {
                SetException(datauserDeleteById.Exception);

            }
            else
            {
                SetResult(datauserDeleteById);
            }
        }
    }
}
