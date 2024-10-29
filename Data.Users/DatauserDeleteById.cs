using ConexionBD;
using System.Collections.Generic;

namespace Data.Users
{
    public class DatauserDeleteById : Conexion
    {
        private int? id;

        public DatauserDeleteById(int? id)
        {
            this.id = id;
        }
        public override void Process()
        {
            string query = @"delete from usuarios where usuarioid = @usuarioid";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@usuarioid", id },

            };
            int result = ExecuteNonQuery(query, parameters);

            SetResult(result);
        }
    }
}
