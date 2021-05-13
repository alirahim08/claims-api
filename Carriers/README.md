# ASP.NET Core microservices solution

## What is this? 
This is a transportation claims application developed using a 
microservices architetcure with apis developed in asp.net core web api 
and hosted in docker containers.

## How do setup it up?
To run the database in docker
```
cd Carriers
docker-compose -f docker-compose-mysql.yml up
```

After running the database, run the exe project `Carriers.Databases.MySql` to create the database


To shutdown the db
```
Press Ctrl+C
docker-compose -f docker-compose-mysql.yml down
```

## How do I build this?
Install docker desktop for windows
https://docs.docker.com/docker-for-windows/install/

OR 
Install docker desktop for mac
https://docs.docker.com/docker-for-mac/

To build the web api container using docker-compose
```
docker-compose build
```

To build the web api container using docker
```
docker build -t carriers:0.1 .
```


## How do I run this?
```
docker-compose up -d
```

http://localhost:8080/healthcheck

## How do I shut this down?
```
docker-compose down
```
