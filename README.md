# Nome da API

Descrição breve da API.

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas e tecnologias instaladas:

- .NET Core SDK
- SQL Server (ou outro banco de dados compatível)

## Configuração do Banco de Dados

1. Configure a string de conexão no arquivo `appsettings.json` para apontar para o seu banco de dados SQL Server.
2. Execute as migrações para criar o banco de dados e as tabelas: `dotnet ef database update`.

## Instalação

1. Clone este repositório: `git clone https://github.com/leonardooliveirati/RotaViagem.API`
2. Navegue até o diretório da API: `cd RotaViagem.API`

## Uso

1. Inicie a API: `dotnet run`
2. Acesse os endpoints da API através de um cliente HTTP ou uma aplicação frontend.

## Endpoints

- `/api/rotas`: CRUD para gerenciar as rotas.
- `/api/rotas/melhor-rota?origem={origem}&destino={destino}`: Endpoint para encontrar a melhor rota entre dois pontos.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob a [Licença XYZ](link-para-licenca).
