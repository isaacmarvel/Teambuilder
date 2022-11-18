# Teambuilder

    This is a Blazor site used to create and store pokemon teams. 
    
    It pulls pokemon data from the pokeapi(https://pokeapi.co/) and allows users to create a team of six pokemon based on that data, including moves, abilites, and held items.

    Once a team has been constructed, the team is sent to a SQLite database via EF Core, and the team data is pulled and displayed on the front page.
   
    PokeTeamBuilder.Console was just to mess around with api requests, and PokeTeamBuilder.Core contains my Pokemon class, as well as an api client that I didn't really end up using.
  
    Instructions to run: After cloning the repo, open PokeTeamBuilder.sln in Visual Studio. You should be able to just run PokeTeamBuilder.BlazorServer and be good to go!

     Code Louisville Features Incorporated:

    Connect to an external/3rd party API and read data into your app--I read data from the pokeApi
    Read data from an external file, such as text, JSON, CSV, etc and use that data in your application--I'm reading from a SQLite database I create
    Use a LINQ query to retrieve information from a data structure (such as a list or array) or file--line 92 on Index.razor features .Include(), which I believe is a LINQ query
    Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program--got plenty of lists

    I intend to continue work on this page, and hope to eventually add:

    The ability to choose pokemon's stats.
    A way to search through items and pokemon instead of having to scroll though long lists.
    Images of the pokemon to the front page.

    Eventually, it might also be nice to add:

    User authentication
    The ability to edit and delete teams one has already made.
    Create unit tests for the app


