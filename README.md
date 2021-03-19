# Factory Manager

#### Database program for keeping track of Engineers and Machines

#### By Jonah Johansen

* * *

## Technologies Used

* C#
* Entity Framework Core
* .NET v5.0
* ASP NET Core MVC
* MySQL
* Git and GitHub
* ASP NET Razor
* CSS Bootstrap

## Description
This App keeps a many-many relationship between Engineers and Machines for keeping track of a factory. Create, Edit, Delete, and View both machines and engineers and add and remove relations between any machine and engineer.
* * *

## Setup/Installation

* .Net 5.0 is required to build and execute this program.
* MySql is required to connect the webserver to a Database
* VS Code is recommended to edit project and build appsettings.json but any text editor will do the same task.


* Download Repo from github or clone using ```git clone {gitURL}```

<ins>Creating ```appsettings.json```</ins>  
appsettings.json is used to connect webserver to the sql server.
* Create file ```appsettings.json``` in ```~/Factory/```.
* Copy into appsettings.json this blurb replacing username and password with your sql database details.
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=jonah_johansen;uid=[YourUserAccount];pwd=[YourPassword];"
  }
}
```

<ins>Creating Database</ins>
* Run ```dotnet ef database drop``` in the case database already exists (Will drop any databases named ```jonah_johansen```)
* Run ```dotnet ef database update``` to add database to MySql Server

<ins>Starting Web Server from Terminal:</ins>
* Navigate from root directory to ```~/Factory/``` and run command ```dotnet restore``` to download and build project dependencies.
* To Run Program: While in ```~/Factory/``` run command ```dotnet run```. Program should compile and execute in terminal. If successful terminal will display the url for the Page. (Note url for https is not secure and will redirect to http)
* Open page in browser using url given in terminal. Default: ```http://localhost:5000/```.


* * *

## Known Bugs

*none tracked at this time*

* * *

## License:
> *&copy; Jonah Johansen, 2021*

Licensed under [MIT license](https://mit-license.org/)

* * *

## Contact Information
_Jonah Johansen: [Email](johansenjonah+git@gmail.com)_