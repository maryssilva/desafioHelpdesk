# Helpdesk API

API REST desenvolvida em ASP.NET Core para gerenciamento de chamados, clientes e atendentes, seguindo arquitetura em camadas e boas práticas de desenvolvimento.

---

##  Arquitetura

O projeto foi estruturado utilizando separação de responsabilidades por pastas:

- **Controllers** – Exposição dos endpoints HTTP
- **Services** – Regras de negócio
- **Repositories** – Acesso a dados
- **Models** – Entidades do domínio
- **Data** – Contexto do Entity Framework

---

##  Modelagem

Entidades principais:

- **Agent** (atendente)
- **Customer** (cliente)
- **Ticket** (chamado)
- **TicketEvent** (histórico de alterações de status)

<img width="817" height="537" alt="Helpdesk drawio" src="https://github.com/user-attachments/assets/547c818b-8b82-41e0-b627-d98ed9458371" />

---

##  Tecnologias Utilizadas

- .NET 7
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Visual Studio Core
- Swagger (OpenAPI)

---

##  Como Executar

1. Clone o repositório
2. Configure a connection string no `appsettings.json`
3. Execute as migrations:
   ```bash
   Update-Database
4. Rode a aplicação
5. Acesse o Swagger: https://localhost:{porta}/swagger

##  Regras de Negócio

- Tickets podem ter apenas os status: Open, Resolved, Closed
- Ao mudar para Resolved, a data de resolução é registrada
- Ao mudar para Closed, a data de fechamento é registrada
- Alterações de status geram registros no histórico (TicketEvent)

##  Testes

- Todos os endpoints principais foram testados via Swagger.
