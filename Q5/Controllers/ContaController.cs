using Microsoft.AspNetCore.Mvc;
using Q5.Exceptions;
using Q5.Request;

namespace Q5.Controllers;

[Route("api/contas")]
public class ContaController : ControllerBase
{
    private IContaService _contaService;
    
    public ContaController(IContaService contaService)
    {
        _contaService = contaService;
    }
    
    [HttpPut("creditar")]
    public async Task<IActionResult> Creditar([FromBody] DebitarCreditarConta request)
    {
        try
        {
            await _contaService.Creditar(request.Id, request.Valor);
            return Ok("Valor creditado com sucesso!");
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("debitar")]
    public async Task<IActionResult> Debitar([FromBody] DebitarCreditarConta request)
    {
        try
        {
            await _contaService.Debitar(request.Id, request.Valor);
            return Ok("Valor debitado com sucesso!");
        }
        catch (SaldoInsuFicienteException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}