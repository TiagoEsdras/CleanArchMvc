# Clean Architecture ASP .NET Core com C#
## _Clean Architecture na prática_

Esse projeto consiste na construção de uma aplicação ASP .NET Core MVC e uma API, aplicando os conceitos de Clean Architecture, princípios SOLID, REST, JWT, Identity e boas práticas de programação, conhecimentos adquiridos durante o estudo do curso [Clean Architecture Essencial - ASP .NET Core com C#
 | UDEMY](https://www.udemy.com/course/clean-architecture-essencial-asp-net-core-com-c).

## Resumo

Clean Architecture é uma arquitetura de software proposta por Robert Cecil Martin (ou Uncle Bob) que tem por objetivo padronizar e organizar o código desenvolvido, favorecer a sua reusabilidade, assim como independência de tecnologia.

Na arquitetura tradicional de camadas existe um acoplamento forte entre as elas, de forma que, para substituir uma camada por exemplo de banco de dados seria necessário alterar outras camadas, trazendo uma difícil manutenibilidade do sistema.

Uncle Bob então elaborou a Clean Architecture, visando um fácil entendimento do sistema e que seja ágil as mudança, conforme as necessidades encontradas no amadurecimento do software. Assim é possível desenvolver encapsulando toda a lógica de negócios, de forma intrinsecamente testável, independentemente do restante da infraestrutura.

A ideia principal por trás do conceito é que as abstrações não devem depender de detalhes, e sim os detalhes devem depender de abstrações. 

Uma vantagem da Clean Architecture em comparação com as arquiteturas tradicionais de três camadas, se dá pelo fato de poder definir estes componentes de infraestrutura em um momento posterior, assim como removê-los ou substituí-los com uma complexidade reduzida. Em outras palavras, é possível projetar aplicativos com menor acoplamento e independentes de detalhes técnicos de implementação, como bancos de dados e estruturas.

Dentre as principais regras do Clean Architecture, deve-se ter maior atenção ao fato que podemos mover as dependências apenas dos níveis externos para os internos, conforme as setas apresentadas na clássica imagem abaixo.

<p align="center">
 <img alt="Clean Architecture" src="https://i.ibb.co/TW5FycD/clean.png" width="500">
</p>

Com isso, os códigos nas camadas internas não precisam ter conhecimento necessariamente das funções nas camadas externas. Os níveis mais internos não podem mencionar as variáveis, funções e classes que existem nas camadas externas.

Partindo do princípio de que esta regra de dependência está sendo bem aplicada, esta separação de camadas visa poupar os desenvolvedores de problemas futuros com a manutenção do software. Deixando, inclusive, o sistema completamente testável, pois as regras de negócios podem ser validadas sem a necessidade da interface do usuário, banco de dados, servidor ou qualquer outro elemento externo. 

Outro ponto de extrema relevância, por ser uma arquitetura de software amplamente independente, é que a princípio se pode fazer a substituição da interface do usuário sem que isso reflita no resto do sistema. 

Assim como é possível trocar o banco de dados, por exemplo, de Oracle ou SQL Server, por Mongo, DynamoDB ou qualquer outro, pois suas regras de negócios não estão vinculadas ao banco de dados, facilitando a troca destes componentes caso tenham se tornado obsoletos ou por qualquer outra necessidade de negócio/técnica sem encontrar maiores dificuldades.

## O Projeto

O projeto foi dividido em camadas de acordo com as regras da Clean Architecture para que as dependências sejam apenas dos níveis externos para os internos

<p align="center">
 <img alt="Representação do projeto CleanArchMvc" src="https://i.ibb.co/HhxGySW/Clean-Architecture.jpg" width="500">
</p>

### CleanArchMvc.API e CleanArchMvc.WebUI

Camada que representa a interface por onde usuário interage com o sistema.
Essa camada faz a inversão da dependência do projeto CleanArchMvc.Application para acessar os serviços.
Nesses projetos existem somente a depêndencia do projeto CleanArchMvc.Infra.IoC.

### CleanArchMvc.Application

Camada que implementou o CQRS (padrão de mediator).
Essa camada faz a inversão da dependência do projeto CleanArchMvc.Infra.Data para acessar os repositórios.
Nesse projeto existe somente a dependência do projeto CleanArchMvc.Domain.

### CleanArchMvc.Domain

Camada que representa as entidades do sistema.
Nesse projeto não existe dependências de acordo com as regras da Clean Architecture.

### CleanArchMvc.Infra.Data

Camada responsável por acessar/conectar e fazer operações no banco de dados.
Nesse projeto existe somente a dependência do projeto CleanArchMvc.Domain.

### CleanArchMvc.Infra.IoC

Camada que auxilia nas configurações de injeção de dependências para outros projetos não ferirem a regra da Clean Architecture.
Nesse projeto existe a dependência dos projetos CleanArchMvc.Application, CleanArchMvc.Domain e CleanArchMvc.Infra.Data.

### CleanArchMvc.Domain.Tests

Esse projeto realiza os testes de entidade representadas no CleanArchMvc.Domain

## Tecnologias Utilizadas

Aqui estão as tecnologias utlilizadas no projeto:

* C#
* .NET 5.0
* AspNet WebAPI
* AspNet MVC
* EntityFrameworkCore
* SqlServer
* Identity
* JwtBearer
* MediatR
* AutoMapper
* Swagger
* xUnit
* FluentAssertions

## Requisitos Necessários

Para rodar esse projeto você precisará de:

* Visual Studio 
* SDK .NET - Versão 5.0.4
* Sql Server
* Windows 

## Como Usar

* Clone esse repositório usando o comando abaixo:
 ```
 git clone git@github.com:TiagoEsdras/CleanArchMvc.git
```

* Abra o arquivo CleanArchMvc.sln

* Defina o projeto CleanArchMvc.API ou CleanArchMvc.WebUI como o projeto startup

* Edite o arquivo appsettings.json do projeto CleanArchMvc.API e CleanArchMvc.WebUI, e susbtistua a ConnectionStrings pela string de conexão do seu computador

* Abra o Package Manager Console e rode o seguinte comando para criar o banco de dados e rodar as migrations:
```
  Update-Database
```
 

## Autor
 
[@TiagoEsdras](https://www.linkedin.com/in/tiagoesdras/)
 
