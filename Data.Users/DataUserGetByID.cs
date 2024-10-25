using ConexionBD;
using Data.Donations.Mappers;
using Donatelo.Api.Entities;
using System;
using System.Collections.Generic;

namespace Data.Users
{
    public class DataUserGetByID : Conexion
    {
        private int? id;

        public DataUserGetByID(int? id)
        {
            this.id = id;
        }
        public override void Process()
        {
            string query = @"select * from usuarios where usuarioid = @usuarioid";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@usuarioid", id },
                
            };
            List<Object[]> result = ExecuteQuery(query, parameters);

            SetResult(result.MapWOP());
        }
    }
}
