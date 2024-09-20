# Customer API

Esta é uma API simples para gerenciar informações de clientes, construída com ASP.NET Core e Entity Framework Core. A API permite realizar operações CRUD (Criar, Ler, Atualizar e Deletar) sobre clientes.

## Estrutura do Projeto

O projeto é dividido em duas partes principais:

- **CustomerApi**: A API principal que fornece endpoints para gerenciar clientes.
- **CustomerApi.Tests**: Projeto de testes que contém testes de unidade para a API.

## Funcionalidades

A API possui os seguintes endpoints:

- `GET /api/customers`: Obtém todos os clientes.
- `GET /api/customers/{id}`: Obtém um cliente específico pelo ID.
- `POST /api/customers`: Adiciona um novo cliente.
- `PUT /api/customers/{id}`: Atualiza um cliente existente.
- `DELETE /api/customers/{id}`: Remove um cliente pelo ID.

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- Um banco de dados (a API utiliza um banco de dados em memória para simplificar os testes)

## Como Executar a API

1. Clone o repositório:

   ```bash
   git clone [https://github.com/seuusuario/CustomerApi.git](https://github.com/jonathanrochac/Customer_API.git)
   cd CustomerApi

2. Restaure as dependências:

dotnet restore
3. Execute a aplicação:

dotnet run

4. Acesse a API no navegador ou através de ferramentas como Postman em http://localhost:5000/api/customers.

# #Testes
Os testes da API estão localizados na pasta CustomerApi.Tests. Para executar os testes, siga os passos abaixo:

Navegue até a pasta de testes:

cd CustomerApi.Tests

Execute os testes:
dotnet test
