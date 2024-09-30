# Gestão de Ocorrências

Projeto Web de Gestão de Ocorrências usando ASP.Net Core Web App, que se comunica com um projeto Web Api.

## Status
Desenvolvido

## Conceitos e Requisitos Propostos
- Lógica de programação
- Conceitos de orientação a objetos
- Conceitos e prática de design patterns
- DDD
- Clean Code
- SOLID
- Bibliotecas de front-end: JS, Knockout.js, Razor, Bootstrap, jQuery
- Conceitos e práticas de OCR (neste caso, EF)
- Integração com banco de dados (neste caso, SQLite)
- Testes Unitários (Não desenvolvidos devido ao tempo escasso para o projeto)

## Técnicas, Arquitetura Padrões e Abordagens aplicadas
- Arquitetura em Camadas
- Arquitetura MVC
- Arquitetura e abordagens Domain-Driven Design (DDD)
- Design Patterns (Repository)
- Injeção de Dependências (Singleton e Scoped)
- Herança
- Polimorfismo
- Interfaces
- Generic Class
- Princípios SOLID
- Práticas Clean Code

## O que foi desenvolvido?
O front-end, desenvolvido em HTML, Razor, Knockout, Bootstrap e AJAX, faz integração com uma API que se conecta a um banco de dados SQLite. Este banco de dados é gerado e autogerenciado pela aplicação através da tecnologia Fluent Migration, que tem como principal objetivo o versionamento do mesmo através de scripts e mapeamentos. A geração do banco é realizada na primeira execução da aplicação.

## Execução do Projeto
Baixar o projeto em uma estação local utilizando o Visual Studio (preferencialmente 2019):
1. Abra a Solution contendo o conjunto de projetos que integram o projeto.
2. Clique com o botão direito sobre a solution e selecione "Set Startup Project...".
3. Selecione "Multiple startup projects" e altere para a opção "Start" nos projetos "GestaoOcorrenciasApi" e "GestaoOcorrenciasApp".
4. Compile a solution e rode o projeto com F5 ou Ctrl + F5 (Debug).

## Pré-Requisitos
É necessário que a estação que executará o projeto contenha o Microsoft .NET Core SDK 5.0 instalado.

## Base de Dados
A base de dados é gerada com o nome **gestao-ocorrencia_db.sqlite** no diretório:

C:\Users\marco\AppData\Roaming\GestaoOcorrencias.Application
Acessado pela aplicação através de:
Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LegalScraper.Application");

O gerenciador de base de dados utilizado para este caso é o SQLite Studio (muito leve) disponível em: [SQLite Studio](https://sqlitestudio.pl/).

## Tecnologias Utilizadas
- Microsoft.NetCore 5.0
- Asp.Net Core Web App 5.0
- Dependency Injection
- Entity Framework Core
- SQLite Core 
- Fluent Migration
- Swashbuckle Swagger
- Newtonsoft.Json
- SQLite
- Razor
- Knockout
- JavaScript
- Bootstrap
- Web API

## Autor
👤 **Marco Manhães Júnior**  
GitHub: [MarcoManhaes](https://github.com/MarcoManhaes)  
LinkedIn: [marco-manhaes](https://linkedin.com/in/marco-manhaes)
