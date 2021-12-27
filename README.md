1. customize your local db connection in connectionstring (appsettings.json) in this project I use SQL Server
2. run migration => add-migration "Initial-Migration" (running in package manager console)
3. update the db => update-database (running in package manager console)
4. run the the project => it will also execute seeding data
5. (for unit testing) open View - Test Explorer then Run All Tests

if you find any dificulties feel free to contact me on fcnura@gmail.com. thank you
