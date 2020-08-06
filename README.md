# basic-data-collection-app
Тестовое задание на вакансию "Стажер на корпоративные WEB-решения(тех. поддержка корпоративного портала на базе MS SharePoint и web приложений)"

Приложение реализовано на базе Microsoft ASP.NET MVC
Дополнительно из NuGet Packages установлено EntityFramework.

Реализована система авторизации и аутентификации (basic-data-collection-app/TraineeDataCollection/TraineeDataCollection/Providers/CustomRoleProvider.cs)

Для удобства тестирования при инициализации базы данных создается два пользователя:
1. Администротор. (login: admin, password: admin) с правами администратора
2. Пользователь. (login: user, password: user) без прав администратора
