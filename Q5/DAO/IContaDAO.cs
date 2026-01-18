using Q5.Entities;

namespace Q5.DAO;

public interface IContaDAO
{
    Task<Conta?> BuscaConta(long id);

    void Atualiza(Conta conta);
}