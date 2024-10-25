using ConexionBD;
using Data.Donations.Mappers;
using System;
using System.Collections.Generic;

namespace Data.Users
{
    public class DataUserGetAll : Conexion
    {
        

        public DataUserGetAll()
        {
            
        }
        public override void Process()
        {
            string query = @"select * from usuarios";

            
            List<Object[]> result = ExecuteQuery(query);

            SetResult(result.MapWOP());
        }
    }
}
