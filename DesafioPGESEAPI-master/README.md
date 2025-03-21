### DesafioPGESEAPI

Este é o repositório da API do Desafio da PGE-SE.
---

### Arquitetura da API
---
A API está estruturada seguindo a Arquitetura em Camadas (Layered Architecture), separando as responsabilidades da seguinte maneira:

- Presentation Layer (Controllers) → Contém os Controllers responsáveis pelas rotas da API.
- Application Layer (Services) → Contém as regras de negócios e serviços.
- Domain Layer (Entities & Interfaces) → Define as entidades do domínio e as interfaces dos repositórios.
- Infrastructure Layer (Repositories & Persistence) → Implementação do acesso aos dados e persistência.
