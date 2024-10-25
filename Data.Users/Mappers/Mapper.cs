using System.Collections.Generic;
using System;
using Donatelo.Api.Entities;
using System.Linq;

namespace Data.Donations.Mappers
{
    internal static class Mapper
    {
        internal static UsuarioDto Map(this object[] item)
        {
            if (item == null)
                return null;

            return new UsuarioDto
            {
                UsuarioId = item.Length > 0 && item[0] != DBNull.Value ? Convert.ToInt32(item[0]) : 0,
                Nombre = item.Length > 1 && item[1] != DBNull.Value ? Convert.ToString(item[1]) : null,
                Correo = item.Length > 2 && item[2] != DBNull.Value ? Convert.ToString(item[2]) : null,
                Contraseña = item.Length > 3 && item[3] != DBNull.Value ? Convert.ToString(item[3]) : null,
                Rol = item.Length > 4 && item[4] != DBNull.Value ? Convert.ToInt32(item[4]) : 0,
                ImagenUrl = item.Length > 5 && item[5] != DBNull.Value ? Convert.ToString(item[5]) : null,

            };
        }
        internal static UsuarioDto MapWOP(this object[] item)
        {
            if (item == null)
                return null;

            return new UsuarioDto
            {
                UsuarioId = item.Length > 0 && item[0] != DBNull.Value ? Convert.ToInt32(item[0]) : 0,
                Nombre = item.Length > 1 && item[1] != DBNull.Value ? Convert.ToString(item[1]) : null,
                Correo = item.Length > 2 && item[2] != DBNull.Value ? Convert.ToString(item[2]) : null,
                
                Rol = item.Length > 4 && item[4] != DBNull.Value ? Convert.ToInt32(item[4]) : 0,
                ImagenUrl = item.Length > 5 && item[5] != DBNull.Value ? Convert.ToString(item[5]) : null,

            };
        }

        internal static List<UsuarioDto> Map(this List<object[]> items)
        {
            return items.Select(x => x.Map()).ToList();
        }
        internal static List<UsuarioDto> MapWOP(this List<object[]> items)
        {
            return items.Select(x => x.MapWOP()).ToList();
        }

    }
}
