# CastGroupTest 
## Esse projeto foi desenvolvido em .NET Core 6 (ASPNET Core)

Dispodição dos projeto.

1 - Há uma solução chamado CastGro;
2 - Compondo a solução temos a API (WebApi), Client (Razor Pages) e o projeto de Testes.

## Como rodar o sistema:
- Utilizei o docker para geração das imagens.
- Cada projeto possui um Dockerfile.
- Na raiz do projeto existe um arquivo docker-cmpose.yml
- Ao rodar o comando docker-compose up -d deveria ser criado o banco de dados SQL, e as imagens da API e Client (Porém está com problema)
_**Atualização> Realizando o docker build individualmente as imagens são criadas normalmente (TODO: Verificar docker-compose.yml)



## O que deveria ser feito:

| Status | Atividade |
| ------ | ------ |
| OK | Criar solução Visual Studio |
| OK | Versionar e gerenciar o projeto com Github |
| OK | Criar API Rest |
| OK | Consumir o serviço de CEP do correio |
| OK | Disponibilizar endpoint para usar o serviço de CEP dos correios |
| OK | Utilizar a lib RestSharp |
| OK | Criar um CRUD para contas e disponibilizar os endpoints |
| OK | Utilizar o Entity Framework |
| OK | Criar base de dados Code First |
| OK | Criar banco de dados local SQL Server - Utilizei Docker |
| OK | Criar projeto de testes |
| OK | Criar testes para API |
| Não | Criar teste para Client |
| OK | Criar projeto Client em MVC Razor Pages |
| OK | Criar tela de listagem pegando dados da API |
| Não | Criar tela de Inserção |
| Não | Criar tela de Edição |
| Não | Criar tela para remoção |
| OK | Criar Dockerfile da API |
| OK | Criar Dockerfile do Client |
| OK | Criar Criar Docker Compose para subir Base Dados, API e Client |
| Não | Sistema funcionando ao utilizar o Docker Compose |
| OK | Criar projeto Client em MVC Razor Pages |



## Quais os problemas do projeto:
- Não foi possível desenvolver as telas de edição, inserção e remoção das contas. Contudo, o código para realizar essas funções foi feito, ficou faltando a parte visual.
- Não consegui fazer os testes para o Client.
- Ao rodar docker compose up para subir as aplicações está ocorrendo erro em relação ao projeto de teste, infelizmente não tive tempo para fazer a correção.

## Quais os problemas do projeto:
- Corrigir os problemas e finalizar a parte visual.
