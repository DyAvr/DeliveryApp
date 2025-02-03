# DeliveryApp
## Общее описание
DeliveryApp – веб-приложение для приёма заказов на доставку.

## Технологии

Backend: ASP.NET 9 </br>
Database: PostgreSQL </br>
ORM: EF </br>
Frontend: ASP.NET MVC </br>
Валидация: FluentValidation </br>
Архитектура: Clean Architecture, DDD, CQRS via MediatR </br>
Контейнеризация: Docker </br>

## Инструкция по запуску

1. Установите Docker.
2. В корневой папке выполните команду:
    ```BASH
    docker-compose up -d
    ```
3. Запустите приложение.

## Инструкция по добавлению миграции

В корневой папке выполнить команды:
```BASH
dotnet tool install --global dotnet-ef
```
```BASH
dotnet ef migrations add НазваниеМиграции ^
  --project .\src\Versta.DeliveryApp.Infrastructure ^
  --startup-project .\src\Versta.DeliveryApp.Web ^
  --output-dir Persistence\Migrations
```

