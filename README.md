--Aplicação para locação de imóveis--

--Essa aplicação foi desenvolvida utilizando .Net Core para o Back e Angular para o Front--

No diretório existem duas pastas separando o back e o front:

Na pasta de nome: "Front" se encontra o Projeto do front, uma interface desenvolvida em Angular.

Na pasta de nome: "Back" se encontra o Projeto do back, uma API desenvolvida em .Net Core.

Tambem estão contidos na pasta Raiz deste projeto o arquivo: "ScriptsSql.txt" contendo o Script de Criação da tabela do banco de dados MySql.

--Tambem foi utilizada como critério de avaliação a API ViaCep para consulta do endereço via CEP--

--PARA RODAR O PROJETO--

Para o rodar o projeto do Front em Angular existem duas maneiras:

1 - Abra a URL: https://pablozagnoli.github.io/LocacaoDeImoveis/home
O projeto do front em Angular já está publicado no GitHub Pages e funcional.
Ao abrir a URL nenhum dado será exibido se a API no back não estiver rodando na porta 5000 do localHost. (Para rodar a API siga para a etapa de execução do Back).

2 - Certifique-se de que você pussui o Angular-MSI instalado em seu computador. 
Clone o repósitorio, abra a pasta do projeto do front com seu Terminal preferido e em seguida digite o comando "ng serve".
este comando irá realizar a execução do projeto do front no seu localhost. Ao abrir o projeto no seu navegador nenhum dado será exibido se a API no back não estiver rodando na porta 5000 do localHost. (Para rodar a API siga para a etapa de execução do Back).


Para o rodar o projeto do Back API em .NET:

Certifique-se de que você pussui o .NET e MySql instalado em seu computador.
Abra seu banco de dados MySql e execute o scripts contidos no Arquivo "ScriptsSql.txt" que está localizado na pasta raiz deste projeto. 
Clone o repósitorio, abra a pasta do projeto do back com seu editor de textos favorito, navegue até o arquivo: "Repository.cs" edite o valor da variável: "connString" e preencha com valor da sua string de conexão com o banco de dados MySql. Exemplo de string de conexão: "Server=localhost;Database=SeuBancoDeDados;Uid=SeuUsuario;Pwd=SuaSenha#". Em seguida abra na pasta raiz do projeto do Back o seu Terminal preferido e em seguida digite o comando "dotnet run".
este comando irá realizar a execução do projeto do back no seu localhost na porta 5000 (Certifque-se de que o projeto está rodando nessa porta). Após executar com sucesso a API do back, você poderá navegar e executar todas as funções do projet do Front em Angular.
