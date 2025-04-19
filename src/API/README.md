# 🧠 Projeto para Revisão de Conhecimento

Este projeto foi criado com o objetivo de revisar e reforçar conhecimentos em desenvolvimento de APIs utilizando **.NET 8**, **Entity Framework Core**, **MySQL** e princípios como **Clean Code** e **Clean Architecture**.

---

## 📌 Objetivos

- Praticar a estruturação de uma Web API moderna com ASP.NET Core.
- Integrar com banco de dados MySQL usando o EF Core e o pacote Pomelo.
- Implementar autenticação com JWT.
- Aplicar Swagger para documentação interativa da API.
- Escrever testes unitários para controllers e serviços.
- Utilizar boas práticas de organização e arquitetura em camadas.

---

## 🧱 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Swagger / Swashbuckle](https://swagger.io/tools/swagger-ui/)
- [MySQL](https://www.mysql.com/)
- [Visual Studio Code](https://code.visualstudio.com/)

---

🧱 Estrutura de Pastas Recomendada

```
src/
│
├── Core/                             # Camada de domínio (regras de negócio puras)
│   ├── Entities/
│   │   └── Personagem.cs             # Entidade do domínio
│   ├── Interfaces/
│   │   ├── IPersonagemRepository.cs # Interface do repositório
│   │   └── IAuthService.cs          # Interface do serviço de autenticação
│   └── Enums/                        # (opcional) Enums usados no domínio
│
├── Application/                      # Casos de uso da aplicação
│   ├── Services/
│   │   ├── AuthService.cs            # Serviço de autenticação (JWT)
│   │   └── PersonagemService.cs     # Lógica de negócio de personagens
│   └── DTOs/
│       ├── Auth/
│       │   └── LoginRequestDTO.cs
│       └── Personagem/
│           └── PersonagemDTO.cs
│
├── Infrastructure/                   # Infraestrutura
│   ├── Persistence/
│   │   ├── AppDbContext.cs          # DbContext do EF
│   │   └── Migrations/              # Migrations EF
│   ├── Repositories/
│   │   └── PersonagemRepository.cs  # Implementação do repositório
│   └── Identity/
│       └── JwtTokenGenerator.cs     # Classe de geração de token
│
├── API/                              # Interface externa
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   └── PersonagemController.cs
│   ├── Middlewares/
│   └── Program.cs
│
└── Shared/                           # Configurações e utilitários compartilhados
    └── Configuration/
        └── JwtSettings.cs
```


## 🔐 Autenticação JWT

- O login é realizado via `AuthController`, que gera um token JWT válido.
- A classe `JwtTokenGenerator` implementa a lógica de criação do token.
- O token é utilizado nos headers para autenticação de endpoints protegidos.

---

## ✅ Funcionalidades

- Login com JWT
- CRUD de personagens
- Proteção de rotas com autorização via token
- Organização em camadas respeitando Clean Architecture

---

## 👨‍💻 Autor

Victor Rodrigues dos Santos  
Pleno Developer • C# • Python💡

---
