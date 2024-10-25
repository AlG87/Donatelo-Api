using ConexionBD;
using Data.Donations.Mappers;
using Donatelo.Api.Entities;
using System;
using System.Collections.Generic;

namespace Data.Users
{
    public class DataUserUpdateById : Conexion
    {
        private readonly UsuarioDto user;

        public DataUserUpdateById(UsuarioDto user)
        {
            this.user = user;
        }
        public override void Process()
        {
            string query = @"UPDATE usuarios set ";

            bool nombreEstaVacio = user.Nombre == null;
            bool correoEstaVacio = user.Correo == null;
            bool contraseñaEstaVacio = user.Contraseña == null;
            bool rolEstaVacio = user.Rol == null;
            bool imagenEstaVacio = user.ImagenUrl == null;

            if (!nombreEstaVacio) 
            {
                query += "Nombre = @nombre";
            }
            if (!correoEstaVacio)
            {
                if (!nombreEstaVacio) query += ",";
                query += "Correo = @Correo";
            }
            if (contraseñaEstaVacio)
            {
                if (!correoEstaVacio) query += ",";
                query += ",Contraseña = @Contraseña";
            }
            if (rolEstaVacio)
            {
                if (!contraseñaEstaVacio) query += ",";
                query += "Rol = @Rol";
            }
            if (imagenEstaVacio)
            {
                if (!rolEstaVacio) query += ",";
                query += "ImagenUrl = @ImagenUrl";
            }
            query += "where UsuarioId = @usuarioid";


            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@usuarioid", user.UsuarioId },
                { "@nombre", user.Nombre },
                { "@Correo", user.Correo },
                { "@Contraseña", user.Contraseña },
                { "@Rol", user.Rol },
                { "@ImagenUrl", user.ImagenUrl },

            };
            int result = ExecuteNonQuery(query, parameters);

            SetResult(result);
        }
    }
}
