Objetivo do Projeto
FiapCloudGamesAPI

API RESTful desenvolvida como parte do projeto Tech Challenge da FIAP. Seu objetivo é permitir o gerenciamento de usuários e uma biblioteca de jogos, com funcionalidades de autenticação, cadastro, listagem e controle de acesso baseado em perfis de usuário.
Prover uma API para cadastro de usuários e gerenciamento de jogos digitais, com autenticação JWT e roles de acesso (“Admin” e “Usuário”).



Objetivos



\- Cadastro e autenticação de usuários.

\- CRUD de jogos digitais.

\- Controle de acesso baseado em roles.

\- Publicação em nuvem com CI/CD e monitoramento.



Tecnologias Utilizadas


\- ASP.NET Core 9

\- C#

\- Entity Framework Core + SQL Azure

\- Swagger (Swashbuckle)

\- JWT Bearer Authentication

\- Docker

\- GitHub Actions (CI/CD)

\- Azure App Service

\- Azure SQL Database

\- Application Insights (monitoramento)

\- xUnit + Moq (testes unitários)


Como Executar o Projeto

1. Clone o repositório:

git clone https://github.com/seu-usuario/FiapCloudGamesProject.git



2\. Configure a connection string com o banco local ou use variável de ambiente

ConnectionStrings\_\_DefaultConnection



2. Navegue até a pasta do projeto e aplique as migrations:

cd FiapCloudGamesProject

dotnet ef database update --project Infrastructure



3. Rode o projeto:

dotnet run --project FiapCloudGamesAPI



4. Acesse o Swagger na URL:

https://localhost:7240/swagger (local)

ou

http://localhost:5238/swagger/index.html





Autenticação JWT
Utilize o endpoint POST /api/auth/login para obter um token JWT



Testes Unitários
Os testes foram implementados com xUnit e Moq.
Como Executar

cd FiapCloudGamesAPI.Tests

dotnet test



Deploy em Nuvem

A aplicação está publicada no Azure App Service como um container Docker.



Pipeline de CI/CD configurado via GitHub Actions:



Build e push da imagem Docker para o Docker Hub privado.



App Service configurado para detectar nova imagem automaticamente



Link da API em produção

https://fiap-cloud-games-api3-gva8fcbwdbcrexar.brazilsouth-01.azurewebsites.net/swagger/index.html


Monitoramento

A aplicação utiliza Application Insights (Azure) para monitoramento de performance e falhas.



Métricas como tráfego, erros e tempo de resposta são coletadas em tempo real.

