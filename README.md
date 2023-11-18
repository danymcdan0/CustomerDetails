# CustomerDetails
This is my submission for the Ardonagh Software Programming Test, taking 4 hours to function at its current sate.

My approach for the task was to first create an API project (ASP.NET Core Web API) followed by creating a front end UI project (ASP.NET Core Web App Model-View-Controller) to consume the API in the same solution.
While I could have been able to keep both functionalities in one standalone ASP.NET Core Web App MVC, the reasoning behind separating into separate projects is that this makes the solution more modular making it possible to extend both of these projects without affecting the other. I also beleive it to be a standard practice, such as Yahoo's weather API and it's web site.

There are currently 4 RESTful endpoints  in the API: 
- /api/customer -> GET to show all customers
- /api/customer/{id} ->GET to show a single customer by id
- /api/customer -> POST to create a customer
- /api/customer/{id} -> PATCH to edit a customer
The extra GET endpoint (/api/customer/{id}) was implemented for the Web app to be able to display previous data to the user while editing.

There was a use of DTOs, ViewModels with an Automapper to be able to convert between different objects.
Further the repository pattern was implemented to handle all of the inmemory database calls, separating concerns of the logic and end points.

# Issues found:
- The validation currently only works on the API side, informing where the user made an error in the response. There are no validation messages given to the user on the Web App side, but if anything is entered wrong the API does not make the users changes to its database.
- There is no back/cancel button in the edit and create on the Web App side.
- No validation check specifically to see if BOTH numbers and characters were entered into the Post Code.
- Currently no error checks or custom made re-direction if a customer Id does not exist.

# Future Improvements:
- Error handling (Focused on working code with functionality first hence no time to implement).
- Validation on the Web App side with dialogue.
- Adding cancel buttons for the edit and create pages (simple fix, just outside the timeframe).
