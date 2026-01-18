using System.Data;
using Q5.DAO;
using Q5.Entities;
using Q5.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Q5.Services;

public class ContaService : IContaService
{
    private Context _context;
    private IContaDAO _contaDAO;

    private readonly ILogger<ContaService> _logger;
    
    public ContaService(Context context, IContaDAO contaDao, ILogger<ContaService> logger)
    {
        _context = context;
        _contaDAO = contaDao;
        _logger = logger;
    }
    
    public async Task Debitar(long idConta, double valor)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable))
        {
            try
            {
                Conta conta = await _contaDAO.BuscaConta(idConta);
                if(!conta.PodeDebitar(valor)) 
                {
                    throw new SaldoInsuFicienteException();
                }
        
                conta.Debite(valor);
                _contaDAO.Atualiza(conta);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Erro ao debitar valor da conta {IdConta}", idConta);
                throw;
            }
        }
    }
    
    public async Task Creditar(long idConta, double valor) 
    {
        using (var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.RepeatableRead))
        {
            try
            {
                Conta conta = await _contaDAO.BuscaConta(idConta);
                conta.Credite(valor);
                _contaDAO.Atualiza(conta);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Erro ao creditar valor da conta {IdConta}", idConta);
                throw;
            }
        }
    }
}