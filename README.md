# Sistema Autenticação C#

Sistema de autenticação desenvolvido com o template de web api do .NET CORE.

O projeto usa jsonwebtoken para formalizar a autenticação, e definir os Roles de cada usuário, permitindo assim acessos a usuários específicos.

## Requisições

<br>

### POST /usuario/login
Retorna um usuário e seu respectivo token se o username e senha estiverem corretos

#### Login correto:
![image](https://user-images.githubusercontent.com/89602176/193726387-5a291274-f65c-4ef7-b26a-8f8575cc957a.png)

#### Login incorreto:
![image](https://user-images.githubusercontent.com/89602176/193726416-55c9ed2b-b4cf-4253-8507-ef0fa4e56a99.png)

<br>

### GET /usuario/autenticado
Retorna uma mensagem com o nome do usuário autenticado:

![image](https://user-images.githubusercontent.com/89602176/193726855-2ef4b0bf-73f2-42fd-9216-714bcfb80524.png)

<br>

### GET /usuario/gerente
Retorna uma mensagem, desde que o Role do usuário seja igual a "Gerente"

![image](https://user-images.githubusercontent.com/89602176/193727062-ecff830c-0f95-4207-bf7c-18f689d79e64.png)

Se o usuário autenticado não tiver o Role "Gerente", o acesso será negado

![image](https://user-images.githubusercontent.com/89602176/193727198-7637314a-d15c-495f-aa7a-8f1c70de98a5.png)

<br>

### GET /usuario/funcionarios
Retorna uma mensagem para o usuário autenticado, desde que ele seja ou "Gerente" ou "Auxiliar"

![image](https://user-images.githubusercontent.com/89602176/193727426-db9619e3-1d9f-4a82-97ed-e6902d1b6409.png)

## Execução

Para executar a aplicação, basta clonar ou baixar o repositório, e rodar dentro da pasta o comando `dotnet run`. A aplicação estará disponível para requisições no endereço `https://localhost:7182`


