namespace TesteTecnico.Domain.Entidades
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime? DataExclusao { get; private set; }
        public ICollection<Reserva> Reservas { get; set; }
        public Sala(){}
        public Sala(string nome, int capacidadeMaxima, DateTime dataCriacao, DateTime dataExclusao)
        {
            Nome = nome;
            CapacidadeMaxima = capacidadeMaxima;
            DataCriacao = dataCriacao;
            DataExclusao = dataExclusao;
        }

    }
}
