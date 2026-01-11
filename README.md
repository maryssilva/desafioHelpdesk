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
  
##  Histórico de Tickets (TicketEvent)

Modelei a entidade `TicketEvent` com o objetivo de registrar o histórico de alterações de status dos tickets, sendo:

- status anterior
- novo status
- data da alteração
- atendente responsável

A lógica da criação do histórico foi implementada na service de `Ticket`, sendo acionada sempre que ocorre uma mudança de status em um chamado.
Por limitação de tempo para a finalização do desafio, a persistência completa do histórico não foi concluída, porém a arquitetura e as regras necessárias para sua implementação já estão definidas.

### Implementação prevista
O resultado final consistiria em:
- Garantir o mapeamento correto das chaves estrangeiras no Entity Framework
- Persistir o `TicketEvent` no mesmo fluxo transacional da atualização do ticket
- Disponibilizar um endpoint para consulta do histórico por ticket
