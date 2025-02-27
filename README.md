# Controle Financeiro 💰📊

Sistema para gerenciamento financeiro pessoal, permitindo o cadastro de categorias e transações, além da visualização de um resumo mensal e anual dos gastos conforme renda e despesas.

## 🚀 Tecnologias Utilizadas

- **Back-end:** .NET (C#), Entity Framework Core, SQLite/PostgreSQL
- **Front-end:** React (TypeScript), Vite, Tailwind CSS
- **Autenticação:** JWT
- **Arquitetura:** MVC (Model-View-Controller)

## 📌 Funcionalidades

- ✅ Cadastro de **categorias** e **transações**
- 📊 Consulta detalhada de **gastos mensais e anuais**
- 🔍 Filtros avançados: data, valor mínimo/máximo, categoria, descrição
- 🔐 Sistema de **autenticação e autorização** via JWT
- 🎨 Interface moderna e responsiva

## 🎯 Como Executar o Projeto

### 🔧 Pré-requisitos
- Node.js e npm/yarn
- .NET SDK
- Banco de dados SQLite/PostgreSQL

### 🖥️ Configuração do Back-end
```sh
# Clone o repositório
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

# Configure as variáveis de ambiente
cp .env.example .env

# Instale as dependências
dotnet restore

# Execute as migrações do banco de dados
dotnet ef database update

# Inicie o servidor
dotnet run
```

### 🌐 Configuração do Front-end (em construção)
```sh
cd frontend

# Instale as dependências
npm install

# Inicie o projeto
npm run dev
```

## 🛠 Melhorias Futuras
- 📊 Dashboard interativo com gráficos
- 📆 Importação/exportação de transações
- 📱 Aplicativo mobile (React Native)

## 📄 Licença
Este projeto está sob a licença MIT. Sinta-se à vontade para utilizá-lo e contribuir! 🚀

---
💡 **Dúvidas ou sugestões?** Abra uma issue ou envie um PR! 😊

