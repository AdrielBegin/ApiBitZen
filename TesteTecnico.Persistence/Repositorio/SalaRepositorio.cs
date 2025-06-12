using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.Interfaces;
using TesteTecnico.Persistence.Contexto;

namespace TesteTecnico.Persistence.Repositorio
{
    public class SalaRepositorio : ISalaRepositorio
    {
        private readonly AppDbContext _context;
        public SalaRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Sala> ObterTodas() => _context.Salas.ToList();
        public void Adicionar(Sala sala)
        {
            _context.Salas.Add(sala);
            _context.SaveChanges();
        }

        public Sala ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Sala sala)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AdicionarAsync(Sala sala)
        {
            _context.Salas.Add(sala); 
            await _context.SaveChangesAsync();
        }
    }
}
