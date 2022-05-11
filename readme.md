Запуск проекта 

docker-compose up
launchUrl : http://localhost:20000/API

Авторизация

ResourceOwnerPassword
Username: username
Password: password
ClientId:  frontend
ClientSecrets: secret
AllowedScopes: api

ClientCredentials
ClientId:  swagger
ClientSecrets: secret
AllowedScopes: api

Защищены контроллеры 

ListItemController

В базе данных присутствуют тестовые данные

Основные возможости 

GetCheckLists(Guid UserId) - получить все списки, доступные данному пользователю
GetCheckListById(Guid UserId, int CheckListId) - получить список по Id, если у пользователя есть доступ
AddCheckList(AddCheckListModel model) - добавить список (название, описание (по желанию), дата создания (автоматически))
ShareCheckList(ShareCheckListModel model) - поделиться списком (дать право reader пользователью, если он есть в системе)
UpdateCheckList(UpdateCheckListModel model) - изменить список (название, описание (по желанию), дата изменения (автоматически))
DeleteCheckList(Guid UserId, int CheckListId) - удалить список, если у пользователя есть доступ и право creator

Дополнительные возможности

Создание, изменение и удаление набора строк (items) у каждого списка (контент, дата создания (автоматически), стоимость (по желанию))
Изменение статуса каждой стоки (marked/unmarked)
Создание, изменение и удаление статусов для строк (удалено из API)
Создание, изменение и удаление прав у пользователей списков (удалено из API)

Планируется

Добавить создание аккаунтов и авторизацию для пользователей
Получать неявно GUID пользователя при работе со списками
Написать тесты
Сделать клиентское приложение
