using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.ValueObjects;

namespace TesteTecnico.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public byte[] SenhaHash { get; private set; }
        public byte[] SenhaSalt { get; private set; }
        public bool Excluido { get; set; }
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public ICollection<Reserva> Reservas { get; set; }
        public Usuario() { }
        public Usuario(int id, string nome, Email email, byte[] senhaHash, byte[] senhaSalt, bool excluido, DateTime dataCriacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            SenhaSalt = senhaSalt;
            Excluido = excluido;
            DataCriacao = dataCriacao;
        }
        public void Atualizar(string nome, Email email)
        {
            Nome = nome;
            Email = email;
        }
        public void AlterarSenha(byte[] novaSenhaHash)
        {
            SenhaHash = novaSenhaHash;
        }
    }
}
