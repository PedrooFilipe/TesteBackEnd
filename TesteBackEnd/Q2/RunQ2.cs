namespace TesteBackEnd.Q2;

public class RunQ2
{
    public void Run()
    {
        Random random = new Random();
        Console.WriteLine($"Valor de venda: {Hi.FormulaMagica(random.NextDouble(), random.Next(1, 20))}");
    }
}