--Aplicação para locação de imóveis--

--Essa aplicação foi desenvolvida utilizando .Net Core para o Back e Angular para o Front--

no diretório existem duas pastas separando o back e o front:

Na pasta de nome: "Front" se encontra o Projeto do front, uma interface desenvolvido em Angular.

Na pasta de nome: "Back" se encontra o Projeto do back, uma API desenvolvida em .Net Core.

--Tambem foi utilizada com critério de avaliação a API ViaCep para consulta do endereço via CEP como critério de avaliação--

--PARA RODAR O PROJETO--

Para o rodar o projeto do Front em Angular existem duas maneiras:

1 - Abra a URL: https://pablozagnoli.github.io/LocacaoDeImoveis/home
O projeto do front em Angular já está publicado no GitHub Pages e funcional.
Ao abrir a URL nenhum dado será exibido se a API no back não estiver rodando na porta 5000 do localHost. (Para roda a API siga para a etapa de execução do Back).

2 - Certifique-se de que você pussui o Angular-MSI instalado em seu computador. 
Clone o repósitorio abra a pasta do projeto do front com seu Terminal preferido e em seguida digite o o comando "ng serve".
este comando irá realizar a execução do projeto do front no seu localhost. Ao abrir o projeto no seu navegador nenhum dado será exibido se a API no back não estiver rodando na porta 5000 do localHost. (Para roda a API siga para a etapa de execução do Back).


Para o rodar o projeto do Back API em .NET:
Certifique-se de que você pussui o .NET instalado em seu computador. 
Clone o repósitorio abra a pasta do projeto do back com seu Terminal preferido e em seguida digite o comando "dotnet run".
este comando irá realizar a execução do projeto do back no seu localhost na porta 500 (Certifque-se de o projeto está rodando nessa porta). Após executar com o sucesso a API do back, você pode navegar e executar todas as funções do projet do Front em Angular.
