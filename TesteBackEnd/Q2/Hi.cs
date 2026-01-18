namespace TesteBackEnd.Q2;

public class Hi
{
    public static double FormulaMagica(double custo, int validade)
    {
        double precoVenda = 0;
        double valorDesconto = ValidadeRegra.Calcular(validade); 

        precoVenda += new PrecoCustoRegra().Calcular(custo);
        if(valorDesconto > 0)
        {
            precoVenda -= (valorDesconto * precoVenda)/100;
        }

        return precoVenda;
    }
}