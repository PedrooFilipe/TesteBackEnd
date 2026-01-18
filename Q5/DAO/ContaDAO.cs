using Microsoft.EntityFrameworkCore;
using Q5.Entities;

namespace Q5.DAO;

public class ContaDAO : IContaDAO
{
    public Context _context;

    public ContaDAO(Context context)
    {
        _context = context;
    }
    
    public async Task<Conta?> BuscaConta(long id)
    {
        return await _context.Contas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Atualiza(Conta conta)
    {
        _context.Contas.Update(conta);
    }
}