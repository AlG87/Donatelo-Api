using ConexionBD;
using Donatelo.Api.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data.Users
{
    public class DataUserCreate
    {
        
        Conexion con = new Conexion();
        //readonly string str = con.getStringDeConexion();
        //SqlConnection conexion = new SqlConnection(str);
        UsuarioDto user;
        public DataUserCreate(UsuarioDto user)
        {

            this.user = user;
        }
        protected override void Process()
        {
            string query = @"insert into usuarios (nombre,correo,contraseña,rol) 
                            values('@Nombre','@correo','@contraseña','@rol')";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@nombre",user.Nombre },
                { "@correo",user.Correo},
                {"@contraseña",user.Contraseña },
                {"@rol",user.Rol }
            };
            //List<Object[]> result = con.
        }
    }
}
