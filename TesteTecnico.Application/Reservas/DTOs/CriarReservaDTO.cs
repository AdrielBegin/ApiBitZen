namespace TesteTecnico.Application.Reservas.DTOs
{
    public class CriarReservaDTO
    {
        public int SalaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
    }
}
