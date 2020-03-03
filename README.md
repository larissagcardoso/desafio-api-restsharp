## Desafio testes de API - RestSharp

- Arquitetura Projeto
	- Linguagem		- [CSharp](https://docs.microsoft.com/pt-br/dotnet/csharp/ "CSharp")
	- Orquestrador de testes - [NUnit 3.12](https://github.com/nunit/nunit "NUnit 3.12")
	- Relatório de testes automatizados - [ExtentReports 4.0.3](http://extentreports.com/docs/versions/4/net/ "ExtentReports 4.0.3")
	- Framework interação com API - [Rest Sharp 106.6.10](http://restsharp.org/ "RestSharp 106.6.10") 

## Metas

- [x]	1) Implementar 50 scripts de testes que manipulem uma aplicação cuja interface é uma API REST. 
Todos os testes podem ser vistos na pasta testes e nas respectivas subpastas: 

```
Filtros
Linguagem
Projetos
Tarefas
Usuarios
```
 
- [x]	2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven.
É possível verificar ao acessar a classe `CriarNotaDeUmaTarefaTests.cs` com o método `DadosValidos(ArrayList testData)`


- [x]	3) O projeto deve tratar autenticação. Exemplo: OAuth2.

A aplicação de API do Mantis, exige autenticação via API Token, a qual é gerada diretamente pela interface do sistema pelo menu 
`Minha Conta / API Tokens / Criar API Token.`Depois de gerada, o token foi utilizado em todos os testes, sendo fornecido no request como atributo Header da solicitação.


- [x]	4) Pelo menos um teste deve fazer a validação usando REGEX (Expressões Regulares).
Foi utilizado método de asserção `StringAssert.IsMatch()` na Classe `CriarUmProjetoTests.cs` método `DadosValidos()`. 

- [x]	5) O projeto deverá gerar um relatório de testes automaticamente.
O relatório sempre será gerado na pasta raiz do projeto dependendo do ambiente em que o projeto é executado.
```
 \bin\Debug\Reports,
 \bin\desenv\Reports ou
 \bin\prod\Reports 
```
- [x]	6) Implementar pelo menos dois ambientes (desenvolvimento / homologação).
Foi gerado as configurações dos ambientes seguindo as orientações @saymowan [multi-environments-visualstudio](https://github.com/saymowan/multi-environments-visualstudio) .
 Os arquivos encontra-se na raiz do projeto `app.desenv.config` e `app.prod.config`.

- [x]	7) A massa de testes deve ser preparada neste projeto, seja com scripts carregando massa nova no BD ou com restore de banco de dados.
Utilizado conexão com o MySQLConnection foi criado método que remove todos os registros no banco de dados e insere novamente antes da execução dos testes.
O método  `PrepararMassaDeDados()` dentro da Classe `DBHelpers.cs`.

- [x]	8) Executar testes em paralelo. Pelo menos duas threads (25 testes cada).
Foi utilizado atributo do NUnit para paralelizar a execução dos testes, inserindo nos testes a chave `[Parallelizable]` juntamente das chaves que marcam os métodos como teste `[Test]`.
E as Theads de execução dentro do Arquivo `AssemblyInfo.cs` em `[assembly: LevelOfParallelism(2)]`.

- [x]	9)Testes deverão ser agendados pelo Jenkins, CircleCI, TFS ou outra ferramenta de CI que preferir.
 Os testes foram agendados pelo Jenkins seguindo as orientações @saymowan [docker-mariadb-seleniumgrid-IC-POM](https://github.com/saymowan/docker-mariadb-seleniumgrid-IC-POM) a partir do passo 9.
As configurações e evidências do agendamento dos testes estão na pasta `CI Jenkins` com o passo a passo, a execução e o log. 


