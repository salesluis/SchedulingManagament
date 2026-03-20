# SchedulingManagament API

## 🎯 Visão Geral

API de agendamento para estabelecimentos, profissionais, serviços, clientes e consultas. Resolve gerenciamento de:
- abertura/fechamento de estabelecimentos
- cadastro/atualização de usuários, clientes e profissionais
- cadastro/atualização de serviços
- relacionamento profissional-serviço
- agendamento/cancelamento/conclusão de consultas

---

## 🏗️ Arquitetura e Padrões Utilizados

- Domínio: DDD leve (Entidades, Value Objects, Builders)
- Infra: Entity Framework Core (ORM) + Mappings Fluent API
- Repositório genérico `IRepository<T>`, especializações `IAppointmentRepository`, `IProfessionalRepository`, etc.
- Unit of Work: `IUnitOfWork` + `UnitOfWork` para `SaveChangesAsync()`
- Camadas separadas: `Application`, `Domain`, `Infra`
- Padrões: Repository, Unit of Work, Builder

---

## 📂 Estrutura de Pastas e Camadas

- `SchedulingManagament.Application`
  - DTOs (contratos de transporte)
- `SchedulingManagament.Domain`
  - `Entities` (modelo de negócio)
  - `ValueObjects` (`Email`, `Money`)
  - `Contracts` (`IRepository`, `IUnitOfWork`, `TenantEntity`)
  - `Builders` (`AppointmentBuilder`)
- `SchedulingManagament.Infra`
  - `Data` (`SchedulingManagementDbContext`, mappings, `UnitOfWork`)
  - `Repositories` (implementações `Repository<T>`, `AppointmentRepository`, etc.)

---

## 🔐 Autenticação e Autorização

- Neste código não há implementação de middleware de autenticação/autorização.
- Recomendado:
  - JWT Bearer (`Authorization: Bearer {token}`)
  - escopos: `establishment:read`, `appointment:write`, etc.
  - política de multi-tenant por `EstablishmentId` em `TenantEntity`

---

## 🚀 Endpoints (Agrupados por Domínio)

> Observação: não há controllers no código disponível; endpoints abaixo são design natural do domínio e devem ser implementados respeitando contratos.

### Establishments
- `GET /establishments`
- `GET /establishments/{id}`
- `POST /establishments`
- `PUT /establishments/{id}`
- `DELETE /establishments/{id}`

### Users
- `GET /users`
- `GET /users/{id}`
- `POST /users`
- `PUT /users/{id}`
- `DELETE /users/{id}`

### Clients
- `GET /clients`
- `GET /clients/{id}`
- `POST /clients`
- `PUT /clients/{id}`
- `DELETE /clients/{id}`

### Professionals
- `GET /professionals`
- `GET /professionals/{id}`
- `POST /professionals`
- `PUT /professionals/{id}`
- `DELETE /professionals/{id}`

### Services
- `GET /services`
- `GET /services/{id}`
- `POST /services`
- `PUT /services/{id}`
- `DELETE /services/{id}`

### ProfessionalServices (vínculo)
- `GET /professional-services`
- `POST /professional-services`
- `PUT /professional-services/{id}`
- `DELETE /professional-services/{id}`

### Appointments
- `GET /appointments`
- `GET /appointments/{id}`
- `GET /appointments/by-professional/{professionalId}`
- `GET /appointments/by-client/{clientId}`
- `GET /appointments/by-establishment/{establishmentId}`
- `POST /appointments`
- `PUT /appointments/{id}`
- `DELETE /appointments/{id}`
- `POST /appointments/{id}/cancel`
- `POST /appointments/{id}/complete`

---

## 📦 Modelos Principais

### DTOs (Application)

- `CreateAppointmentDto`, `UpdateAppointmentDto`, `ResponseAppointmentDto`
- `CreateClientDto`, `UpdateClientDto`, `ResponseClientDto`
- `CreateEstablishmentDto`, `UpdateEstablishmentDto`, `RespondeEstablishmentDto`
- `CreateProfessionalDto`, `UpdateProfessionalDto`, `ProfessionalDto`
- `CreateServiceDto`, `UpdateServiceDto`, `ServiceDto`
- `CreateUserDto`, `UpdateUserDto`, `UserDto`
- `CreateProfessionalServiceDto`, `UpdateProfessionalServiceDto`, `ProfessionalServiceDto`

### Entities (Domain)

- `Establishment` (Id, Name, Slug, IsActive, collections)
- `User` (Id, Name, Email, PhoneNumber)
- `Client` (TenantEntity: EstablishmentId, UserId?, Name, PhoneNumber)
- `Professional` (TenantEntity: EstablishmentId, UserId, DisplayName, IsActive)
- `Service` (TenantEntity: EstablishmentId, Name, DurationInMinutes, PriceInReal, Color, Description, IsActive)
- `ProfessionalService` (TenantEntity, ProfessionalId, ServiceId)
- `Appointment` (TenantEntity, ProfessionalId, ServiceId, ClientId, date/hora/status/observações)

### Value Objects

- `Email` (validação de formato)
- `Money` (inteiro, representando valor em centavos/real)

---

## ⚠️ Tratamento de Erros e Status Codes

- Não há middleware de erro em código fornecido.
- Padrão recomendado:
  - `200 OK`, `201 Created`, `204 No Content`
  - `400 Bad Request` (validação DTO)
  - `401 Unauthorized` (autenticação ausente/inválida)
  - `403 Forbidden` (sem permissão)
  - `404 Not Found` (entity não localizada)
  - `500 Internal Server Error` (exceção não tratada)
- Uso recomendado: `ProblemDetails` (RFC 7807) via `UseExceptionHandler`.

---

## ✅ Boas Práticas e Observações

- Injeção de dependência nativa .NET para `DbContext`, repos e UoW.
- Repositório genérico para CRUD simples; especializações para Queries de negócio.
- Entidades com comportamento (`Update`, `Activate`, `Deactivate`, `Cancel`, `Complete`).
- Mappings no `OnModelCreating` com `IEntityTypeConfiguration<T>`.
- Potencial de adicionar `AutoMapper`, `FluentValidation`, `HealthChecks`, `MediatR`.

---

## 🛠️ Como Rodar Localmente

1. Clone:
   - `git clone <repo>`
   - `cd SchedulingManagament/src`
2. Restaurar:
   - `dotnet restore`
3. Ajustar `appsettings.Development.json` (connection string SQL Server/Postgre):
   - exemplo:
     - `"ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=scheduling;User Id=sa;Password=...;" }`
4. Executar:
   - `dotnet run --project SchedulingManagament.Infra` (ou host project se adicionar)
5. Swagger:
   - `https://localhost:{port}/swagger/index.html` (quando host implementado)
6. Migrations:
   - `dotnet ef migrations add Initial --project SchedulingManagament.Infra --startup-project <app>`
   - `dotnet ef database update --project SchedulingManagament.Infra --startup-project <app>`

---

## 💡 Sugestões de Melhoria (Opcional)

1. Adicionar camada `API` com `Controllers` e rotas REST, documentadas no Swagger.
2. Injete `FluentValidation` + `ProblemDetails` global para retornos consistentes.
3. Corrigir `AppointmentMapping` (`TotalClients` não existe em `Appointment`).
4. Incluir autenticação JWT e controle de tenant `EstablishmentId` por claims.


> Observação final: o código entregue já contém base arquitetural forte, é preciso apenas materializar contrato HTTP (controllers/services) e políticas de segurança para virar API de produção.
