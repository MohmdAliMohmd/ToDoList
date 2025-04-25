ToDoList Console Application
A simple console-based ToDo List application for managing tasks. Built with C# and .NET.

Features
Add New Tasks: Create tasks with descriptions.

Edit Existing Tasks: Modify task descriptions.

Mark Tasks as Completed: Track completion status with checkmarks.

Delete Tasks: Remove tasks from the list.

View Tasks: See all tasks with their IDs, descriptions, and completion status.

Error Handling: Input validation and user-friendly error/success messages.

Installation
Prerequisites:
Ensure .NET SDK is installed.

Clone the Repository:

bash
git clone [https://github.com/your-username/ToDoList.git](https://github.com/MohmdAliMohmd/ToDoList)
cd ToDoList
Run the Application:

bash
dotnet run
Usage
Main Menu
================ Your Todolist:================
1[✓] Sample Task 1
2[ ] Sample Task 2
==============================================

Todo List Application:
1. Add Task
2. Edit Task
3. Mark Task as Completed
4. Delete Task
5. Exit
Operations
Add Task

Enter a task description (non-empty).

Success: Green confirmation message.

Edit Task

Enter the task ID to edit.

Provide a new description.

Error if ID is invalid or description is empty.

Mark Task as Completed

Enter the task ID to mark.

Completed tasks show ✓.

Delete Task

Enter the task ID to delete.

Exit

Close the application.

Code Structure
Classes
Task

Properties: ID, Description, IsCompleted.

Constructor initializes task details.

TodoList

Manages a list of Task objects.

Core Methods:

_AddTask(): Validates and adds tasks.

_ShowEditTaskWindow(): Edits task descriptions.

_ShowMarkAsCompletedScreen(): Updates completion status.

_ShowDeleteTaskScreen(): Removes tasks.

_ShowToDoList(): Displays all tasks.

Key Methods
_GetTaskIdFromUser(): Validates task ID input.

_PerformMainMenuOptions(): Executes operations based on user choice.

_ShowErrorMessage() / _ShowSuccessMessage(): Color-coded console feedback.

Contributing
Contributions are welcome!

Fork the repository.

Create a feature branch.

Submit a pull request.
