namespace TesteBackEnd.Q3;

public class RunQ3
{
    private Dictionary<Rua, List<Casa>> _dados;
    private Random _random = new Random();
    
    public void Run()
    {
        _dados = PreencherDados();
        List<Casa> casasAleatorias = SelecionarCasasAleatorias(_dados.Values.SelectMany(c => c).ToList());
        
        List<Rua> ruas = FiltrarRuas(casasAleatorias);
        foreach (Rua item in ruas)
        {
            Console.WriteLine($" Rua: {item.Nome} - Cep: {item.Cep} - Total de Eleitores: {_dados[item].Sum(c => c.TotalEleitores)}");
        }
    }

    private Dictionary<Rua, List<Casa>> PreencherDados()
    {
        var dictionary =  new Dictionary<Rua, List<Casa>>() { };

        List<Rua> ruas = new List<Rua>();
        for (int i = 0; i < _random.Next(5, 10); i++)
        {
            ruas.Add(new Rua(){Cep = _random.Next(10000000, 99999999).ToString(), Nome = "Rua " + i+1});
        }
        
        dictionary = ruas.ToDictionary(x => x, x => GerarCasas(x));

        return dictionary;
    }

    private List<Casa> GerarCasas(Rua rua)
    {   
        List<Casa> casas = new List<Casa>();
        for (int i = 0; i < 6; i++)
        {
            casas.Add(new Casa(){Rua = rua, Numero = _random.Next(0, 100), TotalEleitores = _random.Next(0, 10)});
        }
        return casas;
    }


    private List<Casa> SelecionarCasasAleatorias(List<Casa> todasCasas)
    {
        int totalCasas = todasCasas.Count;
        int inicio = _random.Next(0, totalCasas);
        int tamanhoMaximo = totalCasas - inicio;
        int tamanhoRange =  _random.Next(1, tamanhoMaximo + 1);
        return todasCasas.Skip(inicio).Take(tamanhoRange).ToList();
    }

    private List<Rua> FiltrarRuas(List<Casa> casas)
    {
        var nomesRuas = casas.Select(c => c.Rua.Nome).Distinct().ToList();

        return _dados
            .Where(x => nomesRuas.Contains(x.Key.Nome))
            .OrderByDescending(x => x.Value.Sum(c => c.TotalEleitores))
            .Select(x => x.Key)
            .ToList();
    }
    
}