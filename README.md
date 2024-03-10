# Desafio Técnico Eclipse Works

Este desafio técnico representa uma api de tarefas em .NET/C#.

Os requisitos funcionais estão em [Requisitos Eclipse Works](https://meteor-ocelot-f0d.notion.site/NET-C-5281edbec2e4480d98552e5ca0242c5b )

## Requisitos
- [Docker](https://www.docker.com/)
- Instalação local do [dotnet8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Introdução:

Esta solução contém o uso de :
- GETS
- POSTS
- Swagger
- Conectividade com SQL Server
- Entity Framework
- Ef Migration

Primeiro rode o comando do docker-compose para criar os containeres SQL Server e Api :

```
docker-compose build
```

E então rode :

```
docker-compose up
```

Não se preocupe em rodar o Entity Framework Migration, pois está sinalizado para rodar ao iniciar a Api.

A api estará disponível em [[localhost](http://localhost:8888:80)]

A api contém 3 usuários que possam ser utilizados para as funcionalidades.

-  Aline. Função PO.
-  Gustavo. Função Desenvolvedor.
-  Pedro. Função Gerente.

## Dúvidas com o Po ( Fase 2 ):

- Embora a remoção de projeto não foi incluída na listagem da api, a regra de deleção do projeto foi exigida.
- Quais os critérios das prioridades de tarefas?
- Quais os usuários que farão o uso da api?
- Edição e conclusão do projeto após a finalização das tarefas.

## Melhorias propostas ( Fase 3 ):

-  A inclusão de `docker compose` para orquestrar containeres de sql server e api, já implementado na solução.
-  Documentação mais detalhada da api com Swagger.
-  Criação de endpoint para mostrar logs de erros.
