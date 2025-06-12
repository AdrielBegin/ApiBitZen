namespace TesteTecnico.Application.Salas.DTOs
{
    public class SalaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataExclusao { get; set; } 
    }
}
