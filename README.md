# Moofi

#### by Noah Kise, Ravin Fisher & Kim Robinson

### A C# ASP.NET Mvc Application with EFCore and MySQL

#### This app will allow a user to:
- Create, Read, Update Delete an Actor
- Create, Read, Update, Delete a Film
- Attach a movie to an actor
- Attach an actor to a movie
- Delete the relationship of movie/actor
- Search for actor by name
- Search for film by name
- See list of genres, film by genre

![sql relationship diagram](./MovieDatabase/wwwroot/assets/images/sql_design.png)

## Stretch Goals
Done
* Add model validation for Film.Name and Actor.Name
* Property added-if movie has been watched, can set true at creation or update in Film Details
* Create Seeded Genre Entity with 1:M relationship to Film

TODO
* Create TVShow Entity with relationship to Actor (and Genre?) Have streaming service as a property of TVShow
* CSS Styling - cards for detail pages?
* Make API call on home page for giphy

## Known Bugs
- in Edit Film, the 24 hr clock is displayed.