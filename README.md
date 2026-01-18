# TesteBackEnd

Este projeto contém a solução para um conjunto de questões de backend, implementadas em .NET.

## Estrutura do projeto

Todas as questões estão em pastas separadas, exceto a questão 5 que foi separada em um projeto por ser um WebService completo. Questões 1 e 4 em texto corrido, questão 6 em sql, questões 2 e 3 em código.

## Como Executar

### Executando o Projeto TesteBackEnd

Para executar as questões com código (Q2 e Q3):

```bash
cd TesteBackEnd
dotnet run
```

O projeto executará automaticamente as questões Q2 e Q3 conforme configurado no `Program.cs`.

### Executando o Projeto Q5 (WebService)

#### 1. Configurar o Banco de Dados

Antes de executar, certifique-se de ter o PostgreSQL configurado. A string de conexão está definida no `Program.cs`:

```
Host=localhost;Database=TesteBackEnd;Username=postgres;Password=123456
```

Ajuste conforme necessário para seu ambiente.

#### 2. Executar Migrations

Para criar a base de dados e gerar dados iniciais:

```bash
cd Q5
dotnet ef database update
```

#### 3. Iniciar o Servidor

```bash
cd Q5
dotnet run
```

O servidor será iniciado e estará disponível em `http://localhost:5229`.

#### 4. Endpoints Disponíveis

##### Creditar Valor em uma Conta

```bash
curl -X PUT http://localhost:5229/api/contas/creditar \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "valor": 100
  }'
```

##### Debitar Valor de uma Conta

```bash
curl -X PUT http://localhost:5229/api/contas/debitar \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "valor": 50
  }'
```

## Tecnologias Utilizadas

- **.NET 8.0**
- **Entity Framework Core**
- **PostgreSQL** (para o projeto Q5)
- **ASP.NET Core** (para o projeto Q5)

## Observações

- O projeto Q5 foi criado separadamente por ser um WebService completo
- As migrations do Q5 incluem seed de dados para facilitar os testes
