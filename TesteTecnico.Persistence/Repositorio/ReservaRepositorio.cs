using Microsoft.EntityFrameworkCore;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.Interfaces;
using TesteTecnico.Persistence.Contexto;

namespace TesteTecnico.Persistence.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly AppDbContext _context;
        public ReservaRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Reserva> ObterTodas() => _context.Reservas
            .Include(r => r.Usuario)
            .Include(r => r.Sala)
            .ToList();

        public void Adicionar(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> ObterPorUsuario(int usuarioId)
        {
            return _context.Reservas
               .Include(r => r.Usuario)
               .Include(r => r.Sala)
               .Where(r => r.UsuarioId == usuarioId)
               .ToList();
        }

        public IEnumerable<Reserva> ObterPorSala(int salaId)
        {
            return _context.Reservas
              .Include(r => r.Usuario)
              .Include(r => r.Sala)
              .Where(r => r.SalaId == salaId)
              .ToList();
        }

        public void Atualizar(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            _context.SaveChanges();
        }
       

        public Task AdicionarAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Task<Reserva> ObterPorId(Guid id)
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Sala)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<Reserva>> ObterReservasPorSalaEData(int salaId, DateTime data)
        {
            return _context.Reservas
                .Where(r => r.SalaId == salaId && r.DataInicio.Date == data.Date)
                .ToListAsync();
        }

        Task<Reserva> IReservaRepositorio.Atualizar(Reserva reserva)
        {
            throw new NotImplementedException();
        }
        public void Remover(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
        }
    }
}
