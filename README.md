Projeto Biblioteca API

Descrição
O Projeto Biblioteca API é uma aplicação desenvolvida em .NET 8 que oferece funcionalidades para gestão de uma biblioteca, permitindo operações como cadastro de livros, usuários e empréstimos. O projeto segue princípios de Clean Architecture e implementa padrões como CQRS e DDD para assegurar uma estrutura escalável e de fácil manutenção.

Arquitetura e Tecnologias
Clean Architecture: Separação de responsabilidades em camadas distintas.
CQRS com MediatR: Separação clara entre comandos (Commands) e consultas (Queries).
Autenticação e Autorização: Implementação de JWT para segurança.
Validações: Uso do FluentValidation para validação de dados.
Testes Unitários: Utilização de xUnit, Moq, FluentAssertions e Bogus para garantir a qualidade do código.
Envio de E-mails: Integração com SendGrid para funcionalidades de comunicação.
Estrutura do Projeto
ProjetoBiblioteca.API: Contém os controllers e configurações da API.
ProjetoBiblioteca.Application: Implementa os casos de uso, comandos, consultas e validações.
ProjetoBiblioteca.Core: Define as entidades, interfaces e exceções.
ProjetoBiblioteca.Infrastructure: Gerencia a persistência de dados, repositórios e serviços externos.
Funcionalidades Principais
Gerenciamento de Livros: CRUD completo para livros.
Gerenciamento de Usuários: Cadastro, autenticação e recuperação de senha.
Gerenciamento de Empréstimos: Controle de empréstimos e devoluções de livros.
Autenticação e Autorização: Proteção de endpoints com base em roles de usuário.
Envio de E-mails: Notificações e recuperação de senha via SendGrid.
Como Executar o Projeto
Pré-requisitos:

.NET 8 SDK
SQL Server ou outro banco de dados configurado.
SendGrid API Key para envio de e-mails.
Configuração:

Clone o repositório:
bash
Copiar
Editar
git clone https://github.com/Cdenilss/ProjetoBibliotecaDev.git
Configure as strings de conexão e a chave da API do SendGrid no arquivo appsettings.json:
json
Copiar
Editar
{
  "ConnectionStrings": {
    "DefaultConnection": "sua_string_de_conexao"
  },
  "SendGrid": {
    "ApiKey": "sua_api_key"
  },
  // Outras configurações
}
Migrar o Banco de Dados:

Navegue até o diretório ProjetoBiblioteca.API e aplique as migrações:
bash
Copiar
Editar
dotnet ef database update
Executar a Aplicação:

No diretório ProjetoBiblioteca.API, execute:
bash
Copiar
Editar
dotnet run
A API estará disponível em https://localhost:5001 ou conforme configurado.
Testes
Para executar os testes unitários:

Navegue até o diretório ProjetoBiblioteca.Tests.
Execute:
bash
Copiar
Editar
dotnet test
