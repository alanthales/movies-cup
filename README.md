# Projeto Movies Cup

Os arquivos do backend e frontend estão em suas respectivas pastas.

## Instalação e uso

* Baixar este repositório ou cloná-lo.
* Instalar as depências se necessário (frontend).
* Rodar os testes unitários.
* Rodar a aplicação.

## Backend

Para rodar os testes unitários entrar na pasta **Test** e rodar o comando `dotnet test`.

Para rodar a aplicação entrar na pasta **Api** e rodar o comando `dotnet run`.

### Observações

Rodar a aplicação com o `dotnet run` fará com que apenas a *api* entre em execução. Para que aplicação completa rode com este comando, você deve *buildar* o `frontend` seguindo os comandos abaixo e em seguida copiar o contéudo da pasta `frontend\build` para dentro da pasta `backend\Api\wwwroot`.

## Frontend

Instalar as dependências com o comando `npm install` ou `yarn install`.

Para rodar os testes unitários `npm test` ou `yarn test`.

Para rodar a aplicação `npm start` ou `yarn start`. Certifique de *startar* o `backend`.

Para *buildar* o projeto execute `npm run build` ou `yarn run build`, o diretório `build` será gerado na raiz deste projeto.
