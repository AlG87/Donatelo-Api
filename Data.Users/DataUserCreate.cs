using ConexionBD;
using Donatelo.Api.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data.Users
{
    public class DataUserCreate : Conexion
    {
        private readonly UsuarioDto user;

        public DataUserCreate(UsuarioDto user)
        {
            this.user = user;
        }
        public override void Process()
        {
            string query = @"INSERT INTO usuarios (Nombre, Correo, Contraseña, Rol,ImagenUrl) 
                         VALUES (@nombre, @correo, @contraseña, @rol,@ImagenUrl)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@nombre", user.Nombre },
                { "@correo", user.Correo },
                { "@contraseña", user.Contraseña },
                { "@rol", user.Rol },
                { "@ImagenUrl", user.ImagenUrl }
            };
            int result = ExecuteNonQuery(query, parameters);

            SetResult(result);
        }
    }

}
