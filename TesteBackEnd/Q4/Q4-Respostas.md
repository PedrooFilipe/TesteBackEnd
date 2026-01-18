
  A) É boa prática definir um tipo específico de exceção que estende da classe Exception? Se sim, em quais casos?
  Sim, é uma boa prática criar exceções específicas quando se opta por trabalhar com exceções, principalmente para representar erros bem definidos da aplicação. Exceções específicas evitam o uso de Exception genérica, deixam o código mais legível e facilitam o tratamento adequado do erro.
  Apesar disso, para erros de lógica ou regras de negócio esperadas, eu prefiro utilizar Result Pattern. As exceções ficam mais voltadas para falhas técnicas.
  
  B) Quando você capturaria uma exceção através de clausulas try e catch? Por que?
  Em cenários onde realmente é possível tomar alguma ação a partir do erro. Por exemplo, erro ao salvar dados no banco ou falha ao chamar um serviço externo via HTTP.
  Nesses casos, faz sentido capturar a exceção para registrar logs, realizar uma retentativa, executar rollback ou devolver uma resposta adequada.
  
  C)Em quais situações você lançaria uma exceção? Cite exemplos
  Quando uso Exceções para tratamento de erros de lógica, é comum lançar quando uma regra de negócio falha, por exemplo: O usuário tentou sacar um valor que não possui em sua carteira, será lançada uma SaldoInsuficienteException para realizar o tratamento. 