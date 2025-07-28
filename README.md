# 📘 CourseManager API

API RESTful desenvolvida em **.NET 9**, com **Entity Framework Core** e **SQL Server**, para gerenciamento de **usuários**, **cursos** e seus relacionamentos.  
Seguindo **boas práticas** com **arquitetura em camadas**, **padrão Repository** e endpoints **semânticos (RESTful)**.

---

## ⚡ **Tecnologias Utilizadas**

- **.NET 9** (ASP.NET Core Web API)
- **Entity Framework Core (Code-First)**
- **SQL Server**
- **Arquitetura em Camadas + Padrão Repository**
- **Swagger (OpenAPI)** para documentação
- **Docker + Docker Compose** para ambiente padronizado

---

## 🗂️ **Arquitetura do Projeto**

```
CourseManager/
├── CourseManager.API/               # Controllers, Program.cs e Swagger
├── CourseManager.Application/       # DTOs e Services (regras de negócio)
├── CourseManager.Domain/            # Entidades e Interfaces dos Repositories
└── CourseManager.Infrastructure/    # DbContext, Migrations e Repositories
```

---

## ⚙️ **Configuração**

### ✅ **Pré-requisitos**
- 🟦 **.NET 9** instalado (para rodar localmente, opcional com Docker)
- 🐳 **Docker e Docker Compose** instalados

### 🔗 **Connection String**
Por padrão, o projeto já vem configurado para o **banco do container Docker**.  
Se quiser usar **localmente**, altere a string no arquivo `appsettings.json`:

#### **Padrão (Docker)** ✅
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=sqlserver,1433;Database=CourseManagerDB;User Id=sa;Password=Admin@123;TrustServerCertificate=True;"
}
```

#### **Para uso local (sem Docker)**
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=ServerName;Database=CourseManagerDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
}
```

---

## 🐳 **Rodar com Docker (Recomendado)**

1. **Subir os containers (API + SQL Server):**
   ```bash
   docker-compose up -d --build
   ```

2. **Acessar a API no navegador:**
   👉 [http://localhost:8080/swagger](http://localhost:8080/swagger)

3. **Conectar no SQL Server via SSMS (opcional):**
   - 🖥️ **Servidor**: `localhost,1433`
   - 👤 **Usuário**: `sa`
   - 🔑 **Senha**: `Admin@123`

4. **Parar os containers:**
   ```bash
   docker-compose down
   ```

---

## 💻 **Rodar Localmente (Sem Docker)**

1. **Restaurar pacotes:**
   ```bash
   dotnet restore
   ```

2. **Aplicar migrations:**
   ```bash
   dotnet ef database update -p CourseManager.Infrastructure -s CourseManager.API
   ```

3. **Rodar a API:**
   ```bash
   dotnet run --project CourseManager.API
   ```

4. **Acessar no navegador:**
   👉 [http://localhost:5211/swagger](http://localhost:5211/swagger)

---

## 📡 **Endpoints Principais**

### 👤 **Users**

| Método | Endpoint          | Descrição              |
|--------|-------------------|------------------------|
| GET    | `/api/users`      | Lista todos os usuários |
| GET    | `/api/users/{id}` | Obtém um usuário por ID |
| POST   | `/api/users`      | Cria um novo usuário   |
| PUT    | `/api/users/{id}` | Atualiza um usuário    |
| DELETE | `/api/users/{id}` | Remove um usuário      |

#### 🔗 **Exemplo de Request - POST**
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

### 🏠 **UserDetails (Integrado ao Users)**

| Método | Endpoint                          | Descrição                          |
|--------|-----------------------------------|------------------------------------|
| GET    | `/api/users/{userId}/details`     | Obtém detalhes do usuário          |
| POST   | `/api/users/{userId}/details`     | Cria detalhes para o usuário       |
| PUT    | `/api/users/{userId}/details`     | Atualiza detalhes do usuário       |

#### 🔗 **Exemplo de Request - POST**
```json
{
  "cpf": "12345678901",
  "address": "Rua Exemplo, 123",
  "phone": "11999999999"
}
```

---

### 📘 **Courses**

| Método | Endpoint           | Descrição               |
|--------|--------------------|-------------------------|
| GET    | `/api/courses`     | Lista todos os cursos   |
| GET    | `/api/courses/{id}`| Obtém um curso por ID   |
| POST   | `/api/courses`     | Cria um novo curso      |
| PUT    | `/api/courses/{id}`| Atualiza um curso       |
| DELETE | `/api/courses/{id}`| Remove um curso         |

#### 🔗 **Exemplo de Request - POST**
```json
{
  "courseName": "ASP.NET Core",
  "courseDescription": "Curso avançado de ASP.NET Core"
}
```

---

### 🎓 **UserCourses (Integrado ao Users)**

| Método | Endpoint                                      | Descrição                          |
|--------|-----------------------------------------------|------------------------------------|
| GET    | `/api/users/{userId}/courses`                 | Lista cursos de um usuário         |
| POST   | `/api/users/{userId}/courses`                 | Adiciona curso ao usuário          |
| DELETE | `/api/users/{userId}/courses/{courseId}`      | Remove um curso do usuário         |

#### 🔗 **Exemplo de Request - POST**
```json
{
  "courseId": 2
}
```

---

## 🚀 **Objetivos Futuros**

### 🔐 **Autenticação e Autorização**
- Implementar **JWT (JSON Web Token)** com roles e claims
- Perfis de acesso (Administrador, Aluno, Instrutor)

### 🐳 **Padronizar Ambiente com Docker**
✅ **Concluído** – API e SQL Server já executando via **docker-compose**

### 📈 **Escalar Estrutura do Sistema**
- **Gestão de Cargos/Perfis** (Administrador, Instrutor, Aluno)
- **Responsáveis por cursos** (Instrutores vinculados a cursos)
- **Carga horária e descrição detalhada dos cursos**
- **Histórico de progresso do aluno nos cursos**
- **Certificação ao concluir cursos**

### 🧪 **Testes e Qualidade**
- Testes unitários e de integração (xUnit)
- Configuração de CI/CD para build e testes automáticos

---

## ✅ **Boas Práticas e Decisões Técnicas**

✔ **Arquitetura em camadas** separando responsabilidades  
✔ **Padrão Repository** para desacoplamento da camada de dados  
✔ **Endpoints RESTful e semânticos** (relacionamentos dentro dos endpoints principais)  
✔ **Migrations aplicadas automaticamente ao iniciar a API**

---

## 📝 **Licença**

Este projeto está sob a licença **MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais informações.

---

# 👨‍💻 **Autor**

Desenvolvido por **Filipe Vilarino** – 2025.
