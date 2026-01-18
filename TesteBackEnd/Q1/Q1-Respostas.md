## A) Usar uma interface ou uma classe abstrata? Por que? Cite exemplos.

Classes abstratas são utilizadas quando existe herança entre as classes, compartilhando estados e comportamentos. Permitem reutilização de código e implementação de métodos abstratos.

```csharp
public abstract class Carteira
{
  public Guid Id {get; set;}
  protected string Moeda {get; set;}

  protected decimal Saldo {get; set;}

  public void Creditar(decimal valor)
  {
    Saldo += valor;
  }

  public abstract void Debitar(decimal valor);
}

public class CarteiraReal : Carteira
{
    public override void Debitar(decimal valor)
    {
      Saldo -= valor;  
    }
}

public class CarteiraDollar : Carteira
{   
    public override void Debitar(decimal valor)
    {
      if(Saldo - valor >= 0)
      {
        Saldo -= valor;
      }
    }
}
```

Interfaces são utilizadas para definir as assinaturas que as classes precisam ter, também conhecidas como contratos. Ou seja, quais comportamentos uma classe deve expor sem implementação concreta ou estado. São bastante utilizadas no desacoplamento de código e injeção de dependências.

```csharp
public interface ICarteira {
  decimal Saldo { get; }
  public void Creditar(decimal valor);
  public void Debitar(decimal valor);
}

public class Carteira : ICarteira 
{
  public decimal Saldo {get; private set;}

  public void Creditar(decimal valor)
  {
    Saldo += valor;
  }

  public void Debitar(decimal valor)
  {
    Saldo -= valor;
  }
}
```

## B) Usar herança ou delegação a outros objetos? Por que? Cite exemplos.

A escolha depende do relacionamento das classes. A herança é utilizada quando definimos que uma classe "É UM", por exemplo: Gato é um Animal. No fim das contas, o gato terá tudo que um animal tiver.

A delegação é utilizada quando precisamos, de fato, delegar uma funcionalidade para outra classe, utilizando seus comportamentos.

No mundo real, um Controller do .NET é um ótimo exemplo para a questão, pois ele pode utilizar as duas técnicas. No exemplo abaixo temos a herança do controller que herda e reaproveita as funcionalidades do `ControllerBase`, e utiliza a delegação ao injetar e reutilizar as funções do `IContaService`: 

```csharp
public class ContaController : ControllerBase
{
  private IContaService _contaService;

  public ContaController(IContaService contaService) 
  {
      _contaService = contaService;
  }


  [HttpPost]
  public IActionResult Cadastrar([FromBody] CadastrarConta requisicao) 
  {
      _contaService.Cadastrar(requisicao);
  }

}
```

Nesse cenário, a herança é usada para reaproveitar comportamentos comuns do framework, enquanto a delegação é usada para concentrar a regra de negócio no serviço, deixando o controller mais simples.
