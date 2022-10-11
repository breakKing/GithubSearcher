# GithubSearcher (тестовое задание)

В процессе разработки были использованы следующие технологии:

1. [MediatR](https://github.com/jbogard/MediatR "Репозиторий с исходным кодом MediatR") (реализация паттернов MediatR и CQRS)
2. [ErrorOr](https://github.com/amantinband/error-or "Репозиторий с исходным кодом ErrorOr") (реализация размеченного множества ошибки и данных)
3. [FastEndpoints](https://fast-endpoints.com/ "Официальный сайт FastEndpoints") (реализация паттерна REPR)
4. [Entity Framework Core](https://learn.microsoft.com/ru-ru/ef/core/ "Документация по EF Core") (ORM)
5. [Npgsql](https://www.npgsql.org/ "Официальный сайт Npgsql") (Провайдер EF Core для PostgreSQL)
6. [Newtonsoft JSON](https://www.newtonsoft.com/json "Официальный сайт Newtonsoft JSON") (работа с JSON-объектами)

Процесс обработки запроса к Rest API осуществляется следующим образом:

1. Запрос валидируется соответствующим валидатором и попадает в нужный endpoint (валидаторы и endpoints находятся в проекте Web).
2. Endpoint создаёт нужный запрос или команду для медиатра и отправляет ему (handlers находятся в проекте Application).
3. Handler взаимодействует с одним или нескольким элементами инфраструктуры из проекта Infrastructute, а также доменными сущностями из проекта Domain, и возвращает в endpoint ответ.
4. Endpoint формирует нужный ответ для клиента и отдаёт его.
