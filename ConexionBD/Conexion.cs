using System.Data.SqlClient;

namespace ConexionBD
{
    public class Conexion
    {
        public SqlConnectionStringBuilder constructorDeString;
        public readonly string stringDeConexion;

        public Conexion()
        {
            constructorDeString = new();
            constructorDeString.DataSource = "DESKTOP-LBD131F\SQLEXPRESS";
            constructorDeString.InitialCatalog = "donateloupdate (1)";
            constructorDeString.IntegratedSecurity = true;
            stringDeConexion = constructorDeString.ConnectionString;

        }
        public string getStringDeConexion()
        {
            //SqlConnection sqlConnection = new SqlConnection(stringDeConexion);

            return stringDeConexion;
        }
    }



}

