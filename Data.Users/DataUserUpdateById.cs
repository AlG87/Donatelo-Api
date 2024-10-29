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
            var setClauses = new List<string>();
            var parameters = new Dictionary<string, object> { { "@usuarioid", user.UsuarioId } };

            if (!string.IsNullOrEmpty(user.Nombre))
            {
                setClauses.Add("Nombre = @nombre");
                parameters.Add("@nombre", user.Nombre);
            }

            if (!string.IsNullOrEmpty(user.Correo))
            {
                setClauses.Add("Correo = @correo");
                parameters.Add("@correo", user.Correo);
            }

            if (!string.IsNullOrEmpty(user.Contraseña))
            {
                setClauses.Add("Contraseña = @contraseña");
                parameters.Add("@contraseña", user.Contraseña);
            }

            if (user.Rol != null && IsValidRole(user.Rol))
            {
                setClauses.Add("Rol = @rol");
                parameters.Add("@rol", user.Rol);
            }

            if (!string.IsNullOrEmpty(user.ImagenUrl))
            {
                setClauses.Add("ImagenUrl = @imagenUrl");
                parameters.Add("@imagenUrl", user.ImagenUrl);
            }

            if (setClauses.Count == 0)
            {
                throw new InvalidOperationException("No se especificaron campos para actualizar.");
            }

            string query = $"UPDATE usuarios SET {string.Join(", ", setClauses)} WHERE UsuarioId = @usuarioid";

            int result = ExecuteNonQuery(query, parameters);
            SetResult(result);
        }


        private bool IsValidRole(int roleId)
        {
            string query = "SELECT COUNT(1) FROM roltype WHERE RolId = @RolId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@RolId", roleId } };
            int count = ExecuteNonQuery(query, parameters);

            return count > 0;
        }
    }
}
