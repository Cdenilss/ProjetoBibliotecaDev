# 📚 Projeto Biblioteca API  

![.NET Core](https://img.shields.io/badge/.NET%208-blue?style=for-the-badge&logo=dotnet)  
![CQRS](https://img.shields.io/badge/CQRS-MediatR-orange?style=for-the-badge)  
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)  

> API desenvolvida em **.NET 8** para gerenciamento de uma biblioteca, utilizando **Clean Architecture**, **CQRS**, **JWT** e boas práticas de desenvolvimento.  

---

## Funcionalidades  

✅ **Gerenciamento de Livros** (Cadastro, edição, exclusão, listagem)  
✅ **Gerenciamento de Usuários** (Autenticação, cadastro, recuperação de senha)  
✅ **Empréstimos e Devoluções** (Controle sobre empréstimos de livros)  
✅ **Autenticação e Autorização** (JWT com controle de acesso por roles)  
✅ **Envio de E-mails** (Recuperação de senha com integração SendGrid)  
✅ **Testes Unitários** (Cobertura de testes com xUnit, Moq, FluentAssertions e Bogus)  

---

## 🏛️ Arquitetura  

📂 **ProjetoBiblioteca.API** → Controllers e configurações da API  
📂 **ProjetoBiblioteca.Application** → Casos de uso, validações, comandos e queries  
📂 **ProjetoBiblioteca.Core** → Entidades, interfaces, regras de negócio  
📂 **ProjetoBiblioteca.Infrastructure** → Banco de dados, repositórios e serviços externos  

---

## 🚀 Tecnologias  

| Tecnologia       | Descrição |
|-----------------|-----------|
| 🔹 **.NET 8**  | Plataforma principal de desenvolvimento |
| 🔹 **Entity Framework Core** | ORM para acesso ao banco de dados |
| 🔹 **MediatR** | Implementação do CQRS (Commands e Queries) |
| 🔹 **JWT** | Autenticação e autorização segura |
| 🔹 **FluentValidation** | Validação avançada de entrada de dados |
| 🔹 **SendGrid** | Envio de e-mails para recuperação de senha |
| 🔹 **xUnit, Moq, FluentAssertions** | Frameworks para testes unitários |

---

## 🛠️ Como Executar  

### 🔹 **Pré-requisitos**  

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) ou outro banco de dados configurado  
- Conta no [SendGrid](https://sendgrid.com/) para envio de e-mails  

### 🔹 **Passos para rodar o projeto**  

1️⃣ **Clone o repositório:**  
```bash
git clone https://github.com/Cdenilss/ProjetoBibliotecaDev.git
cd ProjetoBibliotecaDev
```

2️⃣ **Configure as credenciais no `appsettings.json`:**  
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "sua_string_de_conexao"
  },
  "SendGrid": {
    "ApiKey": "sua_api_key"
  }
}
```

3️⃣ **Aplique as migrações do banco de dados:**  
```bash
dotnet ef database update
```

4️⃣ **Execute o projeto:**  
```bash
dotnet run --project ProjetoBiblioteca.API
```
A API estará disponível em `https://localhost:5001`  

---

## ✅ Como Executar os Testes  

Para rodar os testes unitários, execute:  
```bash
dotnet test
```

---

## 📄 Documentação  

A API está documentada com **Swagger**. Após iniciar o projeto, acesse:  
🔗 [Swagger UI](https://localhost:5001/swagger/index.html)  

---


