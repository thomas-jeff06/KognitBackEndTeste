-------------------------------------------------------- KognitBackEndTeste -----------------------------------------------------------------------

Este projeto é uma API construída com ASP.NET Core para gerenciar usuários e carteiras financeiras. O objetivo principal é permitir o cadastro e exclusão de usuários e carteiras, além de fornecer a possibilidade de associar carteiras a usuários.

Tecnologias Utilizadas:
ASP.NET Core para a criação da API.
Entity Framework Core para interação com o banco de dados SQL Server.
Swagger para facilitar a documentação e testes da API.
SQL Server (instância local) para armazenamento dos dados.
Requisitos
.NET 6.0 ou superior: Para rodar o projeto.
SQL Server: Instância local configurada.
Visual Studio ou Visual Studio Code (com extensões para .NET Core).
Configuração do Banco de Dados

Configuração do Banco de Dados SQL Server:
Certifique-se de ter o SQL Server instalado em sua máquina. Caso não tenha, você pode instalar o SQL Server Express ou usar uma instância local.
Crie um banco de dados vazio no SQL Server.

Configuração da Conexão no Projeto:
Abra o arquivo appsettings.json.
Configure a string de conexão para o banco de dados local:
json
Copiar
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=Nome do BD;Trusted_Connection=True;"
}
Geração das Migrations:

Execute os seguintes comandos no Package Manager Console ou Terminal:

******** dotnet ef migrations add InitialCreate
******** dotnet ef database update

Estes comandos irão gerar as tabelas Users e Wallets no banco de dados configurado.

Execução do Projeto

Restaurar as dependências:
Se você clonou o repositório ou copiou os arquivos, execute o seguinte comando na raiz do projeto para restaurar as dependências:

******** dotnet restore

Executar o Projeto:

******** dotnet run ou apenas clickar em execultar no Visual Studio 2019/2022
Isso iniciará a aplicação e ela estará disponível por padrão no endereço http://localhost:5000 ou https://localhost:5001 (caso o HTTPS esteja habilitado).

Testando a API com Swagger:

Após rodar o projeto, você pode acessar a documentação da API usando o Swagger em, CASO SWAGGER NÃO INICIAR AUTOMATICAMENTE:
https://localhost:5001/swagger

Isso abrirá a interface interativa do Swagger, onde você pode testar todos os endpoints da API.

Endpoints da API

Usuários -------------------------------

POST /api/users: Cadastra um novo usuário.
DELETE /api/users/{id}: Exclui um usuário, desde que não tenha carteiras associadas.
GET /api/users/{id}: Obtém informações de um usuário pelo ID.

Carteiras -----------------------------

POST /api/wallets: Cadastra uma nova carteira.
GET /api/wallets/{id}: Obtém informações de uma carteira pelo ID.
GET /api/wallets/user/{userId}: Obtém a lista de carteiras de um usuário.
DELETE /api/wallets/{id}: Exclui uma carteira.

Testes
O projeto foi estruturado para permitir a realização de testes com Swagger.

Estrutura de Pastas
A estrutura do projeto é organizada da seguinte forma:

KognitBackEndTeste/
├── Controllers/         # Controllers da API
├── Properties/          # Configurações do projeto
├── Repositories/        # Repositórios para acesso aos dados
├── Services/            # Lógica de negócios da aplicação
├── Data/                # Contexto do Entity Framework Core
├── appsettings.json     # Configurações da aplicação
├── Program.cs           # Ponto de entrada da aplicação
├── KognitBackEndTeste.csproj  # Arquivo do projeto

OBS: não foi implementado tantas verificações de informações, como CFP Valido seguindo os padrões, apenas algumas verificações basicas...
