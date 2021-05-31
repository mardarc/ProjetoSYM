# 💻 ProjetoSYM
Projeto desenvolvido para participação em processo seletivo do Grupo SYM.

O Projeto consiste no gerenciamento de médicos e consultórios a serem cadastrados em um banco de dados.

## 🚀 Como executar o projeto

Este projeto é divido em duas partes:
1. Backend (pasta GrupoSYM) 
2. Frontend (pasta FRONT)

💡O Frontend precisa que o Backend esteja em execução para funcionar.

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [Node.js](https://nodejs.org/en/). 

Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

#### 🎲 Rodando o Backend (servidor)

```bash

# Clone este repositório
$ git clone <https://github.com/mardarc/ProjetoSYM> 

# Acesse a pasta do projeto no terminal/cmd
$ cd GrrupoSYM

# Vá para a pasta server (backend)
$ cd GrupoSYM

# Instale as dependências
$ dotnet-install

# Instale a dependencia do EntityFramwork
$ dotnet tool install --global dotnet-ef

# Para criar o banco de dados e as tabelas, execute o comando.
$ dotnet ef database update

# Execute a compilação do projeto
$ dotnet build

# Execute a aplicação em modo de desenvolvimento
$ dotnet run

# O servidor inciará na porta:5001 - acesse https://localhost:5001 

```

#### 🧭 Rodando a aplicação web (Frontend)

```bash
# Acesse a pasta do projeto no seu terminal/cmd
$ cd GrupoSYM

# Vá para a pasta da aplicação Front End
$ cd FRONT

# Instale as dependências
$ npm install
$ npm install http-server

# Execute a aplicação através do servidor http
$ http-server

# A aplicação será aberta na porta:8080 - acesse http://localhost:8080

💡 Para correta funcionalidade e conexão entre back end e front end. no arquivo FRONT\assets\app\config.js, altere o valor de LINKAPI para o endereço onde está sendo executado o back end.

```
## 🦸 Autor

 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/48459357?s=400&u=63f165a3060a3c95ef06714e50b9d61873b3d9fc&v=4" width="100px;" alt=""/>
 <br />
 <sub><b>Marlon Danilo</b></sub>
 <br />