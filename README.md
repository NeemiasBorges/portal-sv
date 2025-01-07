# 🌍 Portal de Seguro Viagem

## 📝 Visão Geral

Apresento um portal de seguros de viagem, composta por um backend .NET Core 8.0 e um frontend moderno em React. O sistema oferece funcionalidades CRUD para clientes e um chatbot inteligente baseado em LLM para auxiliar usuários com informações sobre seguros

# 📊 Status do projeto

> [!NOTE]
> ☁️ Em Deploy

---

# 🚀 Resultado

> [!IMPORTANT]
> 🛰️ Em Deploy

> [!CAUTION]
> ⛔ Após a apresentação e testes o projeto será excluído da azure para não gerar custo

## 🖥️ Ambientes Disponíveis

> **IMPORTANTE**: Para facilitar os testes e avaliaçao

> Credenciais padrão para acesso:
>
> - Email: admin@admin.com
> - Senha: admin

| Ambiente               | URL                                                               | Disponível até |
| ---------------------- | ----------------------------------------------------------------- | -------------- |
| Documentação (Swagger) | [Link]()                                                          | 10/01/2025     |
| API do Modelo LLM      | [Link](https://huggingface.co/mistralai/Mistral-7B-Instruct-v0.3) | Indefinido     |
| Interface Web          | [Link]()                                                          | 10/01/2025     |
| Portal de Logs         | [Link]()                                                          | 10/01/2025     |

## 🏗️ Arquitetura da Solução

- Arquitetura em camadas

### Componentes Principais

- **API Backend**: Gerencia todas as operações
- **Serviço de Chatbot**: Processa interações com usuários usando LLM
- **Serviço de Clientes**: Gerencia operações CRUD de clientes
- **Azure Blob Storage**: Armazena informações sobre destinos e preços
- **Frontend React**: Interface web

### Pontos Interessantes

- Integração com Azure
  - API hospedada como aplicação na nuvem
  - Através do arquivo no Blob Storage, conseguimos:
    - Implementar cálculo dinâmico de preços por pessoa com ajustes baseados em variáveis como saúde e idade
    - Facilitar o gerenciamento de preços e informações, pois qualquer alteração necessária pode ser feita diretamente no arquivo, sem necessidade de modificar o código
- Testes Unitários
  - Integração com fluxos de CI/CD para garantir a qualidade das entregas através de testes automatizados
- Categorização Inteligente via LLM
  - Para otimizar o gerenciamento das conversas, implementamos categorização automática via LLM
  - Facilita o direcionamento dos contatos via chats para os departamentos apropriados:
  - Exemplos
    - Problemas técnicos → Time de Suporte
    - Preços e cotações → Consultores
    - Alteração de apólices → Time Fiscal
    - Entre outros direcionamentos conforme o contexto

## 🚀 Stack Tecnológica

### Backend

- **Framework Principal**: ASP.NET Core 8.0
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server 22
- **Armazenamento**: Azure Blob Storage
- **Qualidade de Código**: SonarQube
- **Testes**: xUnit
- **IA**: API Hugging Face

### Frontend

- **Framework**: React 18.3.1
- **Build Tool**: Vite 5.4.1
- **Estilização**: TailwindCSS 3.4.17

## 📡 API Endpoints

### Autenticação

- `POST /api/v1/auth`: Gera token JWT para autenticação

### Chatbot

- `POST /api/v1/Chatbot`: Envia mensagem para processamento
- `PUT /api/v1/Chatbot`: Atualiza histórico da conversa
- `GET /api/v1/Chatbot`: Recupera histórico completo
- `POST /api/v1/Chatbot/cria-historico`: Cria novo registro de conversa

### Clientes

- `POST /api/v1/Cliente`: Cadastra novo cliente
- `GET /api/v1/Cliente`: Lista todos os clientes
- `PATCH /api/v1/Cliente`: Atualiza dados do cliente
- `GET /api/v1/Cliente/{id}`: Recupera cliente específico
- `DELETE /api/v1/Cliente/{id}`: Remove cliente

## 📂 Estrutura do Projeto

### Backend

```
backend/
├─ Domain/
│  ├─ Controllers/v1/
│  ├─ Entity/
│  ├─ Exceptions/
├─ Infra/
│  ├─ Connection/
│  ├─ Migration/
│  ├─ Repository/
│  ├─ Utils/
├─ Services/
│  ├─ Cliente/
│  ├─ Chatbot/
│  ├─ DTO/
│  ├─ Token/
└─ Tests/
```

### Frontend

```
frontend/
├─ public/
├─ src/
│  ├─ assets/
│  ├─ components/
│  │  ├─ Animated/
│  │  ├─ Chatbot/
│  │  ├─ Form/
│  │  ├─ Header/
│  │  └─ Sidebar/
│  ├─ context/
│  ├─ hooks/
│  └─ pages/
```

## 🚀 Guia de Instalação

### Configuração do Backend

1. **Clone o repositório**:

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```

2. **Configure o ambiente**:

- Ajuste a string de conexão do SQL Server em `appsettings.json`
- Configure as credenciais do Azure Storage
- Atualize outras variáveis de ambiente necessárias

3. **Prepare o ambiente .NET**:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

### Configuração do Frontend

1. **Instale as dependências**:

```bash
cd frontend
npm install
```

2. **Configure o ambiente**:
   Crie um arquivo `.env` na raiz do frontend com:

```plaintext
VITE_REACT_APP_BASE_URL=<URL do backend>
VITE_REACT_APP_PAGE_SIZE=<itens por página>
VITE_REACT_APP_FIRST_PAGE=<página inicial>
VITE_REACT_APP_API_VERSION=<versão da API>
```

3. **Inicie o desenvolvimento**:

```bash
npm run dev
```

## 🌟 Funcionalidades Principais

### Gestão de Clientes

- Cadastro completo de informações
- Atualização de dados
- Consulta e listagem
- Remoção segura de registros

### Chatbot Inteligente

- Respostas contextualizadas sobre seguros
- Categorização automática de conversas
- Histórico completo de interações

## 👥 Autor

<div align="center">
  <a href="https://github.com/NeemiasBorges" target="_blank">
    <img src="https://avatars.githubusercontent.com/u/51499704?v=4" width="115" alt="Foto de perfil de Neemias Borges">
  </a>
  <br>
  <a href="https://github.com/NeemiasBorges">
    <img src="https://img.shields.io/badge/Neemias%20Borges-F6C953?style=for-the-badge&logo=phoenixframework&logoColor=%23FD4F00" alt="Badge Neemias Borges">
  </a>
  <a href="https://www.linkedin.com/in/neemias-borges/">
    <img src="https://img.shields.io/badge/LinkedIn-Neemias%20Borges-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" alt="LinkedIn Neemias Borges">
  </a>
</div>

## Licença 📄

Licença MIT

## Contato 📧

neemiasb.dev@gmail.com
