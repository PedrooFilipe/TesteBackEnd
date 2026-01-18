namespace TesteBackEnd.Q2;

public class ValidadeRegra
{
    public static double Calcular(int validade)
    {
        double desconto = 0;
        if (validade is > 15 and < 30)
        {
            desconto = 10;
        }
        
        if (validade is > 5 and < 15)
        {
            desconto = 20;
        }
        
        if(validade <= 5)
        {
            desconto = 30;
        }

        return desconto;
    }
}