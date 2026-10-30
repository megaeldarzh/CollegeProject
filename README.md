# CollegeManagement

Учебное веб-приложение для управления колледжем на **.NET 8** и **ASP.NET Core Razor Pages**.

## Возможности

- модели `Person`, `Student`, `Teacher`, `Group`, `Subject`;
- демонстрация `public`, `private`, `protected`, `internal`, `protected internal` и `private protected`;
- проверка возраста студента от 15 до 70 лет;
- управление студентами, преподавателями и учебными группами;
- электронный журнал с оценками от 2 до 5;
- учёт посещаемости и расчёт статистики;
- демонстрационная авторизация администратора;
- SQLite и Entity Framework Core;
- русскоязычный интерфейс Razor Pages.

## Запуск

Требуется .NET 8 SDK.

```powershell
dotnet restore .\CollegeManagement\CollegeManagement.csproj
dotnet run --project .\CollegeManagement\CollegeManagement.csproj
```

Откройте адрес из вывода команды в браузере. При первом запуске SQLite-файл `college-management.db` и демонстрационные записи создаются автоматически.

## Демонстрационная авторизация

- логин: `admin`
- пароль: `admin123`

Пароль не хранится в модели пользователя: приложение сравнивает SHA-256-хеш.

## Основные страницы

- `/` — главная;
- `/Students` — студенты;
- `/Teachers` — преподаватели;
- `/Groups` — группы;
- `/Grades` — электронный журнал;
- `/Attendance` — посещаемость;
- `/Login` — авторизация;
- `/Admin` — административная панель.

## GitHub

Не добавляйте в репозиторий файлы `*.db`, `bin`, `obj`, локальные настройки и реальные секреты. Для публикации:

```powershell
git add .
git commit -m "Завершено приложение управления колледжем"
git push
```
