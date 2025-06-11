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

        public Reserva ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> ObterPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> ObterPorSala(int salaId)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public void Remover(bool excluido)
        {
            throw new NotImplementedException();
        }
    }
}
