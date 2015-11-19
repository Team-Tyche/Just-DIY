# Team Tyche #

###### Repository link: https://github.com/Team-Tyche/Just-DIY

## Team members: ##

- Михаела Енчева (dentia)
- Андрей Бояджиев (ahansb)
- Николай Карагьозов (newmast)
- Кирил Борисов (borisov.kiril76)
- Вероника Велкова (Nicca)

## Description ##

For this teamwork assignment we have developed SPA web application. The project is title JustDIY, which stand for Just do it yourself. The goal of the application is to teach people how to build cool gadgets and write software for them. Everybody has a choice - they can either create tutorials on a subject they are proficient in or browse the ones provided from others. All the content in the application is user-generated. All guides fall into two different categories - software and hardware. Currently every guide provides a written description, but there is room for improvement as it could be extended to support video tutorials.

## Class diagram ##

![Image of Types class diagram](http://puu.sh/lrgVH/8a7e4c87b2.png)

## Endpoints ##

| HTTP Method | Web service endpoint  | Description                                                           |
|-------------|-----------------------|-----------------------------------------------------------------------|
| PUT         | api/backup/users      | Backs up the users table in Dropbox.                                  |
| PUT         | api/backup/projects   | Backs up the projects table in Dropbox.                               |
| PUT         | api/backup/votes      | Backs up the votes table in Dropbox.                                  |
| PUT         | api/backup/favourites | Backs up the favourites table in Dropbox.                             |
| GET         | api/category/{id}     | Returns the category with the requested id.                           |
| GET         | api/favourites        | Returns the favourite projects of the current user.                   |
| POST        | api/favourites/{id}   | Adds project with requested id to the current user's favourites.      |
| DELETE      | api/favourites/{id}   | Removes project with requested id from the current users favourites.  |
| GET         | api/identifyme        | Returns the current user's id.                                        |
| GET         | api/projectsby/{id}   | Returns the projects of the used with id equal to {id}.               |
| GET         | api/projectsby        | Return the current user's projects.                                   |
| GET         | api/projects          | Returns all projects.                                                 |
| GET         | api/projects/{id}     | Returns the project with the requested id.                            |
| POST        | api/projects          | Creates a new projects, with data taken from the body of the request. |
| DELETE      | api/projects/id       | Deletes the project with the requested id.                            |
| POST        | api/votes             | Votes for the project with info taken from the body of the request.   |
