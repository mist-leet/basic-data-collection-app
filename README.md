Тестовое задание на вакансию "Стажер на корпоративные WEB-решения(тех. поддержка корпоративного портала на базе MS SharePoint и web приложений)"

Приложение реализовано на базе Microsoft ASP.NET MVC.
Дополнительно из NuGet Packages установлено EntityFramework.

Реализована система авторизации и аутентификации (basic-data-collection-app/TraineeDataCollection/TraineeDataCollection/Providers/CustomRoleProvider.cs)

Для удобства тестирования при инициализации базы данных создается два пользователя:
1. Администратор. (login: admin, password: admin) с правами администратора
2. Пользователь. (login: user, password: user) без прав администратора

Реализованный функционал:
1. Возможности пользователя:
* Возможность создания формы (одну, не более)
* Возможность редактирования формы
* Возможность удаления формы
2. Возможности администратора:
* Просмотр всех форм
* Внесение изменения во все формы
* Удаление любых форм
3. Любой пользователь, у которого есть доступ к ресурсу может зарегистрироваться как пользователь
4. Незарегистрированные пользователи не имеют доступ к возможностям, кроме возможности зарегистрироваться
  
  
