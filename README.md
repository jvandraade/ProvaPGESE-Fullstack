### 📚 Projeto: Sistema de Gestão de Processos Jurídicos - PGESE
---

Este projeto é uma aplicação web desenvolvida para a Procuradoria Geral do Estado de Sergipe (PGESE), com o objetivo de gerenciar processos jurídicos de forma eficiente, eficaz e mais organizada. A aplicação permite que procuradores e clientes acessem funcionalidades específicas de acordo com seu perfil, como consulta de processos, autenticação segura, cadastro de processos, etc...

### 🚀 Tecnologias Utilizadas

### Front-End

- Vue.js CLI (versão 3): Framework JavaScript para construção de interfaces modernas e reativas.
- Vue Router (versão 4): Gerenciamento de rotas no front-end.
- Axios (versão 1): Biblioteca para fazer requisições HTTP ao back-end.
- Bootstrap (versão 5): Framework CSS para estilização responsiva e componentes prontos.
- HTML5 & CSS3: Estrutura e estilização das páginas.

### Back-End

- ASP.NET Core (versão 8.0): Framework para construção de APIs robustas e escaláveis.
- C#: Linguagem de programação utilizada no back-end.
- Entity Framework Core (versão 6.x): ORM para gerenciamento do banco de dados.
- SQL Server Management Studio (SSMS): Ferramenta para gerenciamento do banco de dados SQL Server.
- JWT (JSON Web Tokens): Autenticação segura para usuários.

## Banco de Dados

- Microsoft SQL Server: Banco de dados relacional para armazenamento de dados.

### 🌟 Funcionalidades da aplicação

### Front-End (Vue.js)

- Login e Autenticação: Tela de login para procuradores e clientes, com redirecionamento para telas específicas.
- Home Pages: Telas iniciais personalizadas para cada tipo de usuário (cliente ou procurador).
- Navegação: Uso do Vue Router para gerenciar as rotas e transições entre páginas.
- Requisições HTTP: Integração com o back-end via Axios para autenticação e consumo de dados.

### Back-End (ASP.NET Core)

- Autenticação: Geração de tokens JWT para acesso seguro às rotas da API.
- CRUD de Usuários: Cadastro, leitura, atualização e exclusão de usuários (procuradores e clientes).
- Endpoints: Rotas para autenticação, consulta de processos e gerenciamento de usuários.
- Migrações: Configuração do banco de dados via Entity Framework Core.

### 🛠 Configuração do Projeto

Instalação: Front-End (Vue.js)
---
*Certifique-se de ter o Node.js instalado (versão 16.x ou superior).*

Instale as dependências do projeto:

npm install and vue create

*Executando o Projeto:*

Inicie o servidor de desenvolvimento:

cd .\pasta-do-projeto\. E depois npm run serve

Acesse a aplicação no navegador: http://localhost:8080.
---

### Rotas do Front-End:

- /: Tela de login.
- /home-cliente: Dashboard para clientes.
- /home-procurador: Dashboard para procuradores.
- /cadastro-usuario: Tela de cadastro de novos usuários.
- /lista-processos: Tela de visualização de processos.
- /processos-andamento: Tela de visualização de processos em andamento. (apenas para procurador, pois possui uma aba de edição dos processos).
- /outros-processos: Tela de visualização de processos de outros procuradores (apenas na dashboard do proucrador).
- /editar-perfil: Tela de edição de perfil.
- /processo-andamento-cliente: Tela de visualização de processos em andamento.
- /cadastro-processo: Tela de cadastro de novos processos (apenas na dashboard do procurador).


### Integração com o Back-End:

As requisições HTTP são feitas usando o Axios para os endpoints do back-end.

Exemplo de requisição de login:

const response = await api.post('/api/Auth/login', {
    CPF: this.cpf,
    Password: this.password,
});


### Back-End (ASP.NET Core)
Instalação:

*Certifique-se de ter o .NET SDK instalado (versão 6.x).*


Configuração do Banco de Dados:

No arquivo appsettings.json, configure a string de conexão com o SQL Server:

*Exemplo:* 

"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=PGESE;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}

*Execute as migrações para criar o banco de dados:*

- add-migrations createdatabase 


### Executando o Projeto:

Inicie o servidor:

A API estará disponível em: https://localhost:44350.


### Endpoints da API:


Autenticação:
---
POST /api/Auth/login: Autentica o usuário e retorna um token JWT.

Usuários:
---
GET /api/Usuario: Retorna todos os usuários.

GET /api/Usuario/{id}: Retorna um usuário específico.

POST /api/Usuario: Cria um novo usuário.

PUT /api/Usuario/{id}: Atualiza um usuário existente.

DELETE /api/Usuario/{id}: Exclui um usuário.


Processos Juridicos
---
POST /api/ProcessoJuridico: Insere os processos jurídicos.

GET /api/ProcessoJuridico: Retorna os processos jurídicos.

GET /api/ProcessoJuridico/{id}:  Retorna um processo jurídico específico.

PUT /api/ProcessoJuridico/{id}: Atualiza um processo jurídico.

DELETE /api/ProcessoJuridico/{id}: Deleta um processo jurídico.

POST /api/ProcessoJuridico/{numUnico}/Prazos: Insere o prazo de validação de quanto tempo até o fim do processo.

POST /api/ProcessoJuridico/{numUnico}/Documentos: Insere os documentos necessários para anexar junto ao processo.

POST /api/ProcessoJuridico/TransferirProcesso: Transfere um processo jurídico para outro procurador.


### Migrações:

Para criar uma nova migração:

*add-migration (nome-da-migracao)*


## Para aplicar as migrações ao banco de dados:

*update database*


### 🗂 Estrutura do Projeto

   ### Front-End

src/
- ├── assets/           # Imagens 
- ├── components/       # Componentes Vue.js reutilizáveis
- ├── router/           # Configuração das rotas com Vue Router
- ├── services/         # Configuração do Axios e chamadas à API
- └── App.vue           # Componente principal

 ### Back-End

src/
- ├── Controllers/      # Controladores da API
- ├── Data/             # Configuração do banco de dados e migrações
- ├── Domain/           # Entidades e interfaces
- ├── Services/         # Lógica de negócio e serviços
- ├── appsettings.json  # Configurações do projeto
- └── Program.cs        # Ponto de entrada da aplicação

