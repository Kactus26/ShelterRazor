Web приложение созданное с использованием технологии Razor Page. Была релизована передача данных через TempData; валидация данных форм; View Component со своей логикой, переиспользуемой на разных страницах; передача данных(id) в адресной строке. Подключена база данных Entity Framework SQL Server, в сочетании с паттерном Repository. В нём реализованы все CRUD операции и использованы все виды связей между таблицами. Также здесь применяется AutoMapper для преобразования объектов, Dependency Injection, DTO и MVC.

После установки репозитория, вам понадобится Docker. Запустите его, откройте консоль и пропишите в ней 

```
docker-compose up --build
```
Подождите окончания установки, откройте сайт по адресу localhost:8081 и наслаждайтесь!


_____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

The web application is created using Razor Page technology. Data transfer via TempData has been implemented; form data validation; View Component with its own logic, reusable on different pages; data (id) transmission in the address bar. SQL Server Entity Framework database is connected, in combination with the Repository pattern. It implements all CRUD operations and uses all types of relationships between tables. Also, AutoMapper is applied here for object transformation, Dependency Injection, DTO, and MVC.

After installing the repository, you will need Docker. After downloading it, open the console and write in it

```
docker-compose up --build
```
Wait for the installation to finish, open the site at localhost:8081 and enjoy!

![image](https://github.com/Kactus26/ShelterRazor/assets/143936467/e016706e-9b74-420e-9680-1d2d10dcc8fe)
![image](https://github.com/Kactus26/ShelterRazor/assets/143936467/e41d0017-b65b-4221-9637-dbb12c6eddef)
![image](https://github.com/Kactus26/ShelterRazor/assets/143936467/077d9b03-066f-4a4b-8ce7-a91cd6bee170)
