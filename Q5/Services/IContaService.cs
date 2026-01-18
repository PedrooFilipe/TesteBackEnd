namespace Q5;

public interface IContaService
{
    Task Debitar(long idConta, double valor);

    Task Creditar(long idConta, double valor);
}