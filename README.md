# Agenda Blue API

O código é um exemplo de CRUD de uma agenda e faz parte do teste da Blue Tecnologia.

## Construção
---
### Pré requisitos
* .Net 6
* AutoMapper 12
* EntityFrameworkCore 6

##### Outros pacotes na aplicação
* AutoMapper.Extensions.Microsoft.DependencyInjection 
* EntityFrameworkCore.Tools
* Pomelo.EntityFrameworkCore.MySql
* Pomelo.EntityFrameworkCore.MySql.Design
* Swashbuckle.AspNetCore

##### Banco de dados e migrations

Se preferir, crie uma base de dados chamada `AgendaBlueApi`
~~~mysql
create database AgendaBlueApi;
~~~
Apos configurar a string de conexão em `appsettings.json` na raiz da aplicação, crie a migração e aplique conforme os comandos abaixo no Console do Gerenciador de Pacotes:
~~~pm
add-migration MigracaoInicial
~~~

~~~pm
update-database
~~~

##### Endpoints da API
Os endpoints e requisitos de chamadas estão especificados na documentação `Swagger` contida na aplicação.
