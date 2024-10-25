using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ConexionBD
{
    public abstract class Conexion : DataStrategy
    {
        private readonly string stringDeConexion;
        private SqlConnection connection;
        public Conexion()
        {
            var constructorDeString = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-6EOFKQM\\ig",
                InitialCatalog = "DonateloDbOficial",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };
            stringDeConexion = constructorDeString.ConnectionString;
        }

        protected void OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(stringDeConexion);
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
        protected int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int affectedRows = 0;

            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    affectedRows = command.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }

            return affectedRows;
        }

    }


}

