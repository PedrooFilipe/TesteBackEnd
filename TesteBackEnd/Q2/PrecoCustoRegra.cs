namespace TesteBackEnd.Q2;

public class PrecoCustoRegra
{
    public double Calcular(double precoCusto)
    {
        double valorParaAcrescimo = 5;
        if (precoCusto < 100)
        {
            valorParaAcrescimo += 10;
        }
        
        if (precoCusto >= 100 && precoCusto < 200)
        {
            valorParaAcrescimo += 20;
        }
        
        if(precoCusto >= 200)
        {
            valorParaAcrescimo += 30;
        }

        return valorParaAcrescimo;
    }
}