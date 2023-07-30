# M03S02

Construção de uma aplicação Back-End para revisão do módulo de .Net

### Visual Studio

Abra o visual studio e selecione a opção Criar um novo Projeto

![Alt text](/images/image-3.png)

selecione o template API chamada ASP.NET CORE WEB API

![Alt text](/images/image-4.png)

Seleciona o diretório, mude o nome da solucão e mude o nome do projeto

Ex.
1. Diretório  C:\<SeuRepo>
2. Nome da solução PrimeiroSolucao 
3. Nome do projeto PrimeiroSolucao.API 

![Alt text](/images/image-5.png)

Configuração do projeto

![Alt text](/images/image-6.png)

Criar o projeto

![Alt text](/images/image-7.png)

### VS Code

Add conteudo do vs code

# Comandos git 

## Branches

Comando                          | Detalhe
| :---                           | :---
git branch                       | Lista as branches locais
git branch <nome-da-branch>      | Cria uma nova branch
git checkout <nome-da-branch>    | Muda para a branch especificada
git checkout -b <nome-da-branch> | Cria e muda para uma nova branch

## Commits

Comando                               | Detalhe
| :---                                | :---
git status                            | Mostra o estado atual das mudanças no diretório de trabalho
git add <arquivo>                     | Adiciona um arquivo específico para a área
git add . ou git add -A               | Adiciona todos os arquivos modificados para a área 
git commit -m "Mensagem do commit"    | Cria um novo commit com as mudanças na área
git commit -a -m "Mensagem do commit" | Adiciona automaticamente todas as alterações conhecidas ao índice e cria um commit

## Atualização e Sincronização

Comando     | Detalhe
| :---      | :---
git fetch   | Obtém informações atualizadas do repositório remoto sem incorporar as alterações no diretório de trabalho local
git pull    | Atualiza o repositório local com as alterações do repositório remoto
git push    | Envie os commits locais para o repositório remoto

# Merge e Rebase:

Comando                      | Detalhe
| :---                       | :---
git merge  <nome-da-branch>  | Faz a fusão de uma branch na branch atual
git rebase <nome-da-branch>  | Reaplica commits em cima de outra branch

## O projeto

Após baixar o projeto, você pode abrir com o `Visual Studio` ou com o `VS Code`.
<br>
As tecnologias utilizadas:
* .Net com C#
* SQL Server


# **Comandos utilizados**
### Visual Studio

* Selecion o Tools (Ferramenta) 

![Alt text](/images/image.png)

* Depois entre na opção Package Manager Console

![Alt text](/images/image-1.png)

* Será aberto um terminal para executar os comandos

![Alt text](/images/image-2.png)


* Add-Migration InitialCreate
* Update-Database

### VS Code

#### No `VS Code` pode ser necessário instalar o EF: dotnet tool install --global dotnet-ef


* dotnet ef migrations add InitialCreate 
* dotnet ef database update
