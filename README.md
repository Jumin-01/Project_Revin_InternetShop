# Project_Revin_InternetShop
## Опис
Цей курсовий проєкт виконано студентом 1 курсу групи 612пст спеціальності 121-інженерія програмного забезпечення.  
В ході виконання курсового пректу було розроблено desktop-застосунок мовою C# з викристанням парадигми Об'єктно-орієнтованого програмування (ООП) та платформи Windows Presentation Foundation (WPF.Net).  
Також були використані такі тенології, як JSON, LinQ та інші.  

## Структура проєкту
### Класи предметної області
Назва           | Зміст 
----------------|----------------------
Shop.cs         | Моделювання об'єкту "Магазин"
User.cs         | Моделюання об'єкту "користувач"
Game.cs         | Моделювання об'єкту "Гра"
Collections.cs  | Абстрактний клас, що об'єднує загальні риси колекції
Catalog.cs      | Моделювання каталогів ігор
Library.cs      | Моделювання бібліотеки користувача
IPerson.cs      | Інтерфейс, що надає риси користувача
### Класи фнтерфейсу користувача
Назва           | Зміст 
----------------|----------------------
MainWindow      | Головне вікно застосунку
LoginWindow     | Вікно авторизації
ViewPage        | Сторінка перегляду каталогів
LibraryPage     | Сторінка перегляду бібліотеки
SearchPage      | Сторінка результатів пошуку ігор
GamePage        | Сторінка перегляду інформаціїї про гру
AdminViewPage   | Сторінка перегляду каталогів для адміністратора (може додати гру)
AdminGamePage   | Сторінка перегляду інформаціїї про гру (може редагуввати, видаляти)
RegistrationPage| Сторінка реєстрації
AutorizationPAge| Сторінка авторизації
## Важливо
Інформація про магазин  зберігається до JSON файлу "Shop" в корневій папці проєкту
