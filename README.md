<h1 align="center">Products Dapper</h1>

## :computer: Projeto

Repositório com projeto desenvolvido para fins acadêmicos para representar uma WebAPI, o objetivo é simular uma lista de `Produtos` e aplicar um CRUD básico para revisar conceitos referentes a comunicação com banco de dados usando 
[Dapper](https://dapperlib.github.io/Dapper/) de uma mais organizada.

## :white_check_mark: Decisões Técnicas

Foram tomadas algumas decisões técnicas durante o desenvolvimento da aplicação, mesmo criando um projeto simples o propósito foi aplicar boas práticas visando código com qualidade e uma estrutura organizada caso o projeto recebar futuras modicações.

- `IConnectionDataBase`: essa interface genérica foi criada para realizar a comunicação com o banco de dados, nesse projeto foi utilizado o [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) caso um dia for necessário alterar para outra base de dados essa estrutura vai permitir essa mudança de uma maneira mais flexível.

- `Repository Pattern`: este padrão tem a responsabilidade de centralizar a lógica de acesso aos dados, seguindo uma ideia similar a da interface `IConnectionDataBase` a adição desse padrão tem objetivo de aplicar uma estrutura mais flexível para qualquer mudança necessária.

- `Service Pattern`: esse padrão foi adicionado para separar a camada de regra de negócio das demais camadas do projeto, assim dispõe de flexibilidade para a criação de testes, manutenção de código e na reutilização por outras partes do projeto. 

## :heavy_check_mark: Recursos Utilizados

- ``.NET 6``
- ``ASP.NET``
- ``C#``
- ``Dapper``
- ``SQL Server``
- ``Swagger``

## :floppy_disk: Clonar Repositório

```git clone https://github.com/pauloamjdeveloper/dotnet-products-dapper.git```

## Author
:boy: [Paulo Alves](https://github.com/pauloamjdeveloper)
