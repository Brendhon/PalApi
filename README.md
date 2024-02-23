<h1 align="center">DM113 - PalApi</h1>

Repositório para armazenar o projeto final da disciplina **DM113 - Desenvolvimento de serviço SOAP com WCF em C#**. O projeto consiste em um serviço de gerenciamento de Pals de Palworld e contém as seguintes funcionalidades:

- **Cadastro de Pals**: Criação de um novo Pal
- **Listagem de Pals**: Listagem de todos os Pals cadastrados
- **Busca de Pals**: Busca de um Pal específico
- **Atualização de Pals**: Atualização de um Pal específico
- **Exclusão de Pals**: Exclusão de um Pal específico

---

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- **[.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)**
- **[Swagger](https://swagger.io/)**
- **[SQLite](https://www.sqlite.org/index.html)**

---

## ⚙️ Como executar o projeto

### 💡 Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
**[Git](https://git-scm.com)** e **[.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)**. Além disto é bom ter um editor para trabalhar com o código como **[Visual Studio Code](https://code.visualstudio.com/)**.

Clone o repositório do projeto

```bash
git clone https://github.com/Brendhon/PalApi.git
```

---

### ⚽ Rodando o projeto 

Para rodar o projeto, siga os passos abaixo:

```bash
# Acesse a pasta do projeto no terminal/cmd
cd PalApi

# Execute o comando para baixar as dependências do projeto
dotnet restore

# Execute o comando para rodar o projeto com build
dotnet run
```

O servidor inciará na porta:5265 - acesse <http://localhost:5265>

---

### 👀 Observações

- Foi adicionado na raiz do projeto o arquivo `DM113.postman_collection.json` que contém as requisições para testar o servidor.
- É possível acessar o swagger do projeto através do link <http://localhost:5265/swagger/index.html>

---

## 👥 Autor

<h4>
<img style="border-radius: 5%; margin-right: 30px" src="https://avatars.githubusercontent.com/Brendhon" width="120px;" alt="Avatar"/><br>
Brendhon Moreira
</h4>


[![Linkedin Badge](https://img.shields.io/badge/-Brendhon-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/brendhon-moreira)](https://www.linkedin.com/in/brendhon-moreira)

<h4>
<img style="border-radius: 5%; margin-right: 30px" src="https://avatars.githubusercontent.com/u/50179542?v=4" width="120px;" alt="Avatar Aguinaldo"/><br>
Aguinaldo de Souza Júnior
</h4>


[![Linkedin Badge](https://img.shields.io/badge/-Aguinaldo-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/aguinaldo-fs)](https://www.linkedin.com/in/aguinaldo-fs)

---

### 📝 License
[![License](https://img.shields.io/github/license/Brendhon/Pokedex?style=plastic)](http://badges.mit-license.org)
