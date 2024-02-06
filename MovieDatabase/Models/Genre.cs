
@using MovieDatabase.Models;
@model List<MovieDatabase.Models.Genre>

<h2>Genre Details: </ h2 >
< hr />
< h3 > Films in this genre: </ h3 >

@if(@Model.Films.Count == 0)
{
    < p > There are no films added to this genre yet.</ p >
}
else
{
    < ul >
    @foreach(Film film in Model.Films)
        {
            < li > @Html.ActionLink($"{film.Name}", "Details", "Films", new { id = film.FilmId }) </ li >
        }
    </ ul >
}
...
< p > @Html.ActionLink("Edit genre", "Edit", new { id = Model.GenreId }) </ p >
< p > @Html.ActionLink("Delete genre", "Delete", new { id = Model.GenreId }) </ p >
< p > @Html.ActionLink("Back to genre list", "Index") </ p >