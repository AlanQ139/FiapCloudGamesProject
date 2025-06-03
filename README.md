Objetivo do Projeto
FiapCloudGamesAPI

API RESTful desenvolvida como parte do projeto Tech Challenge da FIAP. Seu objetivo é permitir o gerenciamento de usuários e uma biblioteca de jogos, com funcionalidades de autenticação, cadastro, listagem e controle de acesso baseado em perfis de usuário.
Prover uma API para cadastro de usuários e gerenciamento de jogos digitais, com autenticação JWT e roles de acesso (“Admin” e “Usuário”).

Tecnologias Utilizadas

* ASP.NET Core 9
* C#
* Entity Framework Core + SQLite
* Swagger (Swashbuckle)
* JWT Bearer Authentication
* xUnit + Moq (testes unitários)

Como Executar o Projeto

1. Clone o repositório:

git clone https://github.com/seu-usuario/FiapCloudGamesProject.git


2. Navegue até a pasta do projeto e aplique as migrations:

cd FiapCloudGamesProject

dotnet ef database update


3. Rode o projeto:

dotnet run


4. Acesse o Swagger na URL:

https://localhost:7240/swagger


Autenticação JWT
Utilize o endpoint POST /api/auth/login para obter um token JWT

Testes Unitários
Os testes foram implementados com xUnit e Moq.
Como Executar

cd FiapCloudGamesAPI.Tests

dotnet test