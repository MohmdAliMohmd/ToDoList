# ToDoList Console Application

A simple console-based ToDo List application for managing tasks. Built with C# and .NET.

## Features

- **Add New Tasks**: Create tasks with descriptions.
- **Edit Existing Tasks**: Modify task descriptions.
- **Mark Tasks as Completed**: Track completion status with checkmarks.
- **Delete Tasks**: Remove tasks from the list.
- **View Tasks**: See all tasks with their IDs, descriptions, and completion status.
- **Error Handling**: Input validation and user-friendly error/success messages.

## Installation

1. **Prerequisites**:  
   Ensure [.NET SDK](https://dotnet.microsoft.com/download) is installed.

2. **Clone the Repository**:  
   ```bash
   git clone https://github.com/your-username/ToDoList.git
   cd ToDoList
   ```

3. **Run the Application**:  
   ```bash
   dotnet run
   ```

## Usage

### Main Menu
```
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
```

### Operations
1. **Add Task**  
   - Enter a task description (non-empty).  
   - Success: Green confirmation message.  

2. **Edit Task**  
   - Enter the task ID to edit.  
   - Provide a new description.  
   - Error if ID is invalid or description is empty.  

3. **Mark Task as Completed**  
   - Enter the task ID to mark.  
   - Completed tasks show `✓`.  

4. **Delete Task**  
   - Enter the task ID to delete.  

5. **Exit**  
   - Close the application.  

## Code Structure

### Classes
1. **`Task`**  
   - Properties: `ID`, `Description`, `IsCompleted`.  
   - Constructor initializes task details.  

2. **`TodoList`**  
   - Manages a list of `Task` objects.  
   - Core Methods:  
     - `_AddTask()`: Validates and adds tasks.  
     - `_ShowEditTaskWindow()`: Edits task descriptions.  
     - `_ShowMarkAsCompletedScreen()`: Updates completion status.  
     - `_ShowDeleteTaskScreen()`: Removes tasks.  
     - `_ShowToDoList()`: Displays all tasks.  

### Key Methods
- **`_GetTaskIdFromUser()`**: Validates task ID input.  
- **`_PerformMainMenuOptions()`**: Executes operations based on user choice.  
- **`_ShowErrorMessage()` / `_ShowSuccessMessage()`**: Color-coded console feedback.  

## Contributing
Contributions are welcome!  
1. Fork the repository.  
2. Create a feature branch.  
3. Submit a pull request.
