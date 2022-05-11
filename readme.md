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

StateController
ListItemController

В базе данных присутствуют тестовые данные

Возможости 

GetCheckLists(Guid UserId) - получить все списки, доступные данному пользователю
GetCheckListById(Guid UserId, int CheckListId) - получить список по Id, если у пользователя есть доступ
    Task AddCheckList(AddCheckListModel model);
    Task ShareCheckList(ShareCheckListModel model);
    Task UpdateCheckList(UpdateCheckListModel model);
    Task DeleteCheckList(Guid UserId, int CheckListId);