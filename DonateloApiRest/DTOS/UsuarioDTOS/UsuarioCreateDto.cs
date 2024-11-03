namespace DonateloApiRest.DTOS.UsuarioDTOS
{
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int Rol { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
