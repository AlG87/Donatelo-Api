using ConexionBD;
using Donatelo.Api.Entities;
using System.Collections.Generic;

namespace Data.Publications
{
    public class DataPublicationCreate 
    {
        private readonly PublicacionDto publication;

        public DataPublicationCreate(PublicacionDto publication)
        {
            this.publication = publication;
        }
        public override void Process()
        {
            string query = @"INSERT INTO Publicaciones(Titulo, Descripcion, FechaCreacion, UsuarioId,Estado) 
                         VALUES (@Titulo, @Descripcion, @FechaCreacion, @UsuarioId,@Estado)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Titulo", publication.Titulo },
                { "@Descripcion", publication.Descripcion },
                { "@FechaCreacion", publication.FechaPublicacion },
                { "@UsuarioId", publication.UsuarioId },
                { "@Estado", publication.Estado }
            };
            int result = ExecuteNonQuery(query, parameters);

            SetResult(result);
        }
    }
}
