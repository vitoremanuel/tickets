# Desafio Backend #

Nesse desafio, a tarefa é implementar uma API REST que tenha os endpoints de um CRUD de Tickets do Trílogo. Eles deverão fazer parte da rota  _/api/tickets_.

Um Ticket consiste de uma ocorrência de algum problema, com os seguintes campos:

* Description: uma descrição do problema
* AuthorName: nome do autor do Ticket
* Date: data de criação do ticket

O uso de qualquer linguagem e/ou framework é livre, desde que os dados sejam persistidos em alguma base de dados.

Para dar início ao desafio, o candidato deve dar um fork no repositório e, ao fim do desenvolvimento, dar acesso ao usuário **_washington@trilogo.com.br_** ao seu repositório para análise do trabalho.

**Extras**

* Implementação em ASP.NET Core, com o uso de EF para persistência de dados.
* Utilização de um segundo ORM (Dapper, por exemplo) para a realização de leituras no banco de dados
* Implementação de um mecanismo de autorização (uso de JWT, por exemplo) para validar as chamadas aos endpoints
* Implementação de testes unitários
* Aplicação de boas práticas (KISS, DRY, SOLID etc.)

Os itens extras (opcionais) contarão positivamente na análise do seu desafio.

### POST `/api/tickets/`
Esse endpoint recebe um objeto JSON para a criação de um novo ticket

```json
{
   "Description":"Lâmpada queimada",
   "AuthorName":"Washington",
   "Date":"26/11/2015",
}
```

### PUT `/api/tickets/{id}`
Endpoint que realiza a alteração de um ticket de um determinado _id_

_FromForm_
```json
{
   "Description":"Lâmpada com mal contato",
   "AuthorName":"null", (optional)
   "Date":"null", (optional)
}
```

### DELETE `/api/tickets/{id}`
Realiza a deleção de um determinado ticket com _id_ passado como parâmetro

### GET `/api/tickets`
Lista todos os tickets cadastrados

```json
[
  {
   "Id":1,
   "Description":"Lâmpada queimada",
   "AuthorName":"Washington",
   "Date":"26/11/2019"
  },
  {
   "Id":2,
   "Description":"Pintar parede",
   "AuthorName":"Pedro",
   "Date":"12/12/2019"
  },
  {
   "Id":3,
   "Description":"Monitor com defeito",
   "AuthorName":"João",
   "Date":"07/01/2020"
  },
]
```

### Resolução do Desafio 

**Implementação**

* O projeto foi desenvolvido em C# utilizando ASP.NET Core.

**Autenticação** `/api/home/login/`

Autenticação foi implementada utilizando JWT. Para fazer o login pode utilizar o json abaixo:

```json
{
   "username":"admin",
   "password":"admin"
}
``` 

Ao logar um Token é retornado para ser utilizado como Bearer token para acessar os endpoints:
```json
{
  "user": {
    "id": 1,
    "username": "admin",
    "password": ""
  },
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFt..."
}
```

**Dados**

* Para persistência foi utilizado EntityFramework Core.
* Para leitura foi utilizado o Dapper.
* O Banco de Dados configurado foi o SQL Server.