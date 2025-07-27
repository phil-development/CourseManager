# 📘 CourseManager API

API RESTful desenvolvida em **.NET 8**, com **Entity Framework Core** e **SQL Server**, para gerenciamento de **usuários**, **cursos** e seus relacionamentos.  
Seguindo **boas práticas** com **arquitetura em camadas**, **padrão Repository** e endpoints **semânticos (RESTful)**.

---

## ✅ **Tecnologias Utilizadas**

- **.NET 8** (ASP.NET Core Web API)
- **Entity Framework Core (Code-First)**
- **SQL Server**
- **Arquitetura em Camadas + Padrão Repository**
- **Swagger (OpenAPI)** para documentação

---

## ✅ **Arquitetura do Projeto**

```
CourseManager/
├── CourseManager.API/               # Controllers, Program.cs e Swagger
├── CourseManager.Application/       # DTOs e Services (regras de negócio)
├── CourseManager.Domain/            # Entidades e Interfaces dos Repositories
└── CourseManager.Infrastructure/    # DbContext, Migrations e Repositories
```

---

## ✅ **Configuração**

### **Pré-requisitos**
- .NET 8 instalado
- SQL Server instalado e configurado
- Connection String ajustada em `appsettings.json`

Exemplo (`CourseManager.API/appsettings.json`):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=phil-notebook;Database=CourseManagerDB;User Id=sa;Password=Admin2113;TrustServerCertificate=True;"
}
```

### **Rodar Localmente**

1. Restaurar pacotes:
   ```bash
   dotnet restore
   ```
2. Aplicar migrations (caso ainda não tenha criado o banco):
   ```bash
   dotnet ef database update -p CourseManager.Infrastructure -s CourseManager.API
   ```
3. Rodar a API:
   ```bash
   dotnet run --project CourseManager.API
   ```
4. Acessar no navegador:
   ```
   http://localhost:5211/swagger
   ```

---

## ✅ **Endpoints**

### **1. Users**

| Método | Endpoint          | Descrição              |
|--------|-------------------|------------------------|
| GET    | `/api/users`      | Lista todos os usuários |
| GET    | `/api/users/{id}` | Obtém um usuário por ID |
| POST   | `/api/users`      | Cria um novo usuário   |
| PUT    | `/api/users/{id}` | Atualiza um usuário    |
| DELETE | `/api/users/{id}` | Remove um usuário      |

#### **Exemplo de Request - POST**
```json
{
  "userLogin": "john.doe",
  "userPassword": "123456",
  "cpf": "12345678901",
  "fullName": "John Doe",
  "birthDate": "1990-05-12"
}
```

---

### **2. UserDetails (Integrado ao Users)**

| Método | Endpoint                          | Descrição                          |
|--------|-----------------------------------|------------------------------------|
| GET    | `/api/users/{userId}/details`     | Obtém detalhes do usuário          |
| POST   | `/api/users/{userId}/details`     | Cria detalhes para o usuário       |
| PUT    | `/api/users/{userId}/details`     | Atualiza detalhes do usuário       |

#### **Exemplo de Request - POST**
```json
{
  "cpf": "12345678901",
  "address": "Rua Exemplo, 123",
  "phone": "11999999999"
}
```

---

### **3. Courses**

| Método | Endpoint           | Descrição               |
|--------|--------------------|-------------------------|
| GET    | `/api/courses`     | Lista todos os cursos   |
| GET    | `/api/courses/{id}`| Obtém um curso por ID   |
| POST   | `/api/courses`     | Cria um novo curso      |
| PUT    | `/api/courses/{id}`| Atualiza um curso       |
| DELETE | `/api/courses/{id}`| Remove um curso         |

#### **Exemplo de Request - POST**
```json
{
  "courseName": "ASP.NET Core",
  "courseDescription": "Curso avançado de ASP.NET Core"
}
```

---

### **4. UserCourses (Integrado ao Users)**

| Método | Endpoint                                      | Descrição                          |
|--------|-----------------------------------------------|------------------------------------|
| GET    | `/api/users/{userId}/courses`                 | Lista cursos de um usuário         |
| POST   | `/api/users/{userId}/courses`                 | Adiciona curso ao usuário          |
| DELETE | `/api/users/{userId}/courses/{courseId}`      | Remove um curso do usuário         |

#### **Exemplo de Request - POST**
```json
{
  "courseId": 2
}
```

---

## ✅ **Objetivos Futuros**

### **1) 🔐 Autenticação e Autorização**
- Implementar **JWT (JSON Web Token)** com roles e claims
- Perfis de acesso (Administrador, Aluno, Instrutor)

### **2) 🐳 Padronizar Ambiente com Docker**
- Criar **docker-compose** para subir **API + Banco (SQL Server)** em um único comando

### **3) 📈 Escalar Estrutura do Sistema**
- **Gestão de Cargos/Perfis** (Administrador, Instrutor, Aluno)
- **Responsáveis por cursos** (Instrutores vinculados a cursos)
- **Carga horária e descrição detalhada dos cursos**
- **Histórico de progresso do aluno nos cursos**
- **Certificação ao concluir cursos**

### **4) ✅ Testes e Qualidade**
- Testes unitários e de integração (xUnit)
- Configuração de CI/CD para build e testes automáticos

---

## ✅ **Boas Práticas e Decisões Técnicas**

✔ **Arquitetura em camadas** separando responsabilidades  
✔ **Padrão Repository** para desacoplamento da camada de dados  
✔ **Atualização automática do campo `UpdatedAt` em updates**  
✔ **Endpoints RESTful e semânticos** (relacionamentos dentro dos endpoints principais)  

---

## ✅ **Licença**

MIT License.

---

# 📌 **Autor**

Desenvolvido por **Filipe Vilarino** – 2025.
