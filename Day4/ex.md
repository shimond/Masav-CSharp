# Important: This project must be created as a **.NET Framework** project (not .NET Core).

# Exercise: Web API for a Simple Task Management System

## Objective
Build an ASP.NET Web API that manages a list of tasks (to-dos), demonstrating controllers, HTTP methods (GET, POST, PUT), and advanced attribute-based routing with `RoutePrefix` and `Route`.

## Requirements

1. **Create a `TasksController`**
	 - Use `[RoutePrefix("api/tasks")]` at the class level.

2. **Task Model**
	 - Create a `TaskItem` class with:
		 - `int Id`
		 - `string Title`
		 - `string Description`
		 - `bool IsCompleted`
		 - `DateTime? DueDate`

3. **Implement the following endpoints:**
	 - `GET api/tasks`  
		 Returns all tasks.
	 - `GET api/tasks/{id}`  
		 Returns a specific task by ID.
	 - `POST api/tasks`  
		 Adds a new task.
	 - `PUT api/tasks/{id}/complete`  
		 Marks a task as completed.
	 - `GET api/tasks/due/{year}/{month}`  
		 Returns all tasks due in a specific month and year.

	 Use `[Route]` attributes to define custom routes for each action.

4. **In-Memory Data**
	 - Use a static list to store tasks (no database).

5. **Bonus (Optional)**
	 - Add a `DELETE api/tasks/{id}` endpoint.
	 - Add validation: prevent adding tasks with empty titles or past due dates.
	 - Add a `GET api/tasks/completed` endpoint to return only completed tasks.

---
# Sample Initial Data (JSON)

```json
[
	{
		"Id": 1,
		"Title": "Finish Web API exercise",
		"Description": "Complete the implementation of all required endpoints.",
		"IsCompleted": false,
		"DueDate": "2026-01-15T17:00:00"
	},
	{
		"Id": 2,
		"Title": "Review attribute routing",
		"Description": "Read about RoutePrefix and Route attributes in ASP.NET.",
		"IsCompleted": false,
		"DueDate": "2026-01-12T12:00:00"
	},
	{
		"Id": 3,
		"Title": "Submit homework",
		"Description": "Upload the completed project to the course portal.",
		"IsCompleted": false,
		"DueDate": "2026-01-16T23:59:00"
	}
]
```

**Note:**  
Focus on using attribute routing and controller logic. No database is required.