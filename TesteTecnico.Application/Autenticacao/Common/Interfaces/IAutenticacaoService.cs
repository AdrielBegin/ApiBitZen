using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Application.Autenticacao.Common.Interfaces
{
    public interface IAutenticacaoService
    {
        string GerarToken(Usuario usuario);
        bool VerificarSenha(string senha, byte[] senhaHash, byte[] senhaSalt);
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    }
}
