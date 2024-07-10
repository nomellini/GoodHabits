# GoodHabits
## Adaptado para usar PostgreSQL

Para criar o container banco de dados usando  o docker, abra um command na pasta onde está o `docker-compose.yml` e rode o comando abaixo  

`docker compose -d`  

subir a api rodando o projeto GoodHabits.Service.

para testar a api, deve-se usar o postman, e chamar a url:  
http://localhost:5100/api/Habits

em Headers, adicione 'tenant' um dos valores encontrados no appsettings:
* AscendTech - usa seu proprio database
* Bluewave - usa seu proprio database
* CloudSphere e Datastream compartilham o mesmo database
* Nomellini  usa um próprio

para adicionar mais Tenants, primeiro editar o appsettings.json

Para visualizar os databases, use o pgAdmin, que subiu junto no docker  
`http://localhost:5050` 

login e senha estão no docker-compose.yml

não esqueca de regitrar o servidor Postgres, para o pgAdmin, ele fica no host "postgresql_database" e não no localhost.
Add new server.  
Aba General:  
Name = Local  
  
Aba Connection:
Host :postgresql_database  
login e senha no docker-file.   
Save Password


