# AppControleMantec
Aplicativo de controlde de Assistencia Técnica_projeto pessoal


Backend para Controle de Assistência Técnica
Este projeto de backend foi desenvolvido em C# utilizando a arquitetura Clean Architecture, organizado em várias camadas para separação de responsabilidades e facilidade de manutenção.

Estrutura do Projeto
O projeto está estruturado em diversas camadas:

1. API
Descrição: Camada responsável por receber e processar requisições HTTP.
Tecnologias: ASP.NET Core, Swagger para documentação da API.
2. Application
Descrição: Camada que contém a lógica de negócio da aplicação.
Tecnologias: C#, serviços e classes de aplicação.
3. Domain
Descrição: Camada que define os modelos de domínio e interfaces dos repositórios.
Tecnologias: Modelos de domínio em C#.
4. Domain.Test
Descrição: Camada que contém testes unitários para os modelos e regras de negócio.
Tecnologias: xUnit, Moq.
5. Infra.Data.Mongo
Descrição: Camada responsável pela implementação dos repositórios utilizando MongoDB.
Tecnologias: MongoDB.Driver para .NET.
6. Infra.IoC
Descrição: Camada de Injeção de Dependência para configurar o container IoC.
Tecnologias: .NET Core IoC.
Como Iniciar o Projeto
Clone o repositório.
Configure seu ambiente de desenvolvimento.
Execute a aplicação.
Configuração
Para configurar o projeto localmente, siga os passos abaixo:

Clone o Repositório: git clone (https://github.com/lemuelpires/AppControleMantec).git
Instale as Dependências: dotnet restore
Configurações Adicionais: Configure as strings de conexão com o MongoDB em appsettings.json.
Execute a Aplicação: dotnet run
Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir um pull request ou relatar problemas através das issues.
