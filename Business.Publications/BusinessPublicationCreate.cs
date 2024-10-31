using ConexionBD;
using Data.Publications;
using Donatelo.Api.Entities;
using System;

namespace Business.Publications
{
    public class BusinessPublicationCreate 
    {
        private readonly PublicacionDto publication;

        public BusinessPublicationCreate(PublicacionDto publication)
        {
            this.publication = publication;
        }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(publication.Titulo))
                throw new ArgumentException("El titulo es obligatorio.");

            if (string.IsNullOrWhiteSpace(publication.Descripcion))
                throw new ArgumentException("La descripcion es obligatorio.");

            if (DateTime.Now < publication.FechaPublicacion)
                throw new ArgumentException("La fecha de creacion es mayor a la actual.");

            if (string.IsNullOrWhiteSpace(publication.ImagenUrl))
                throw new ArgumentException("La imagen es obligatorio.");

        }
        public override void Process()
        {
            DataPublicationCreate dataPublicationCreate = new DataPublicationCreate(publication);

            if (dataPublicationCreate.Execute() != StateStrategy.Success)
            {
                SetException(dataPublicationCreate.Exception);

            }
            else
            {
                SetResult(dataPublicationCreate);
            }
        }
    }
}
