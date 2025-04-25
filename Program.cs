using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{

    internal class Program
    {


        public class Task
        {
            public int ID { get; set; }
            public string Description { get; set; }
            public bool IsCompleted { get; set; }

            public Task(int ID, string Description, bool IsCompleted = false)
            {
                this.ID = ID;
                this.Description = Description;
                this.IsCompleted = IsCompleted;
            }
        }
        public class TodoList
        {
            List<Task> _ToDoList;
            int _ID { get; set; }
            public TodoList()
            {
                _ToDoList = new List<Task>();
                _ID = 0;
            }
            int _GetNewTaskID()
            {
                if (!_ToDoList.Any())
                    return 1;
                else
                    return _ToDoList.Max(Task => Task.ID) + 1;
            }
            void _AddTask(string Description)
            {
                if (string.IsNullOrWhiteSpace(Description))
                {
                    _ShowErrorMessage("Description cannot be empty!");
                    return;
                }

                _ToDoList.Add(new Task(_GetNewTaskID(), Description));

                _ShowSuccessMessage("Task added successfully!");
            }
            void _ShowMarkAsCompletedScreen()
            {

                byte SelectedID;
                string ErrorMessage = string.Empty;
                while (true)
                {
                    Console.Clear();
                    _ShowToDoList();
                    _ShowErrorMessage(ErrorMessage);

                    SelectedID = _GetTaskIdFromUser("Mark as Completed");
                    if (SelectedID != 0)
                    {
                        Task SelectedTask = _ToDoList.Find(t => t.ID == SelectedID);
                        if (SelectedTask == null)
                        {
                            ErrorMessage = $"Ensure the ID there is no Task With ID : {SelectedID}";
                            continue;
                        }

                        SelectedTask.IsCompleted = true;
                        _ShowSuccessMessage("Task marked as completed!");
                    }
                    _Continue();
                    Console.Clear();
                    break; ;
                }

            }
            void _Continue()
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            void _ShowDeleteTaskScreen()
            {

                byte SelectedID;
                string ErrorMessage = string.Empty;
                while (true)
                {
                    Console.Clear();
                    _ShowToDoList();
                    _ShowErrorMessage(ErrorMessage);

                    SelectedID = _GetTaskIdFromUser("Delete");
                    if (SelectedID != 0)
                    {

                        Task SelectedTask = _ToDoList.Find(t => t.ID == SelectedID);
                        if (SelectedTask == null)
                        {
                            ErrorMessage = $"Ensure the ID there is no Task With ID : {SelectedID}";
                            continue;
                        }

                        _ToDoList.Remove(SelectedTask);
                        _ShowSuccessMessage("Task deleted successfully!");
                    }
                    _Continue();
                    Console.Clear();
                    break; ;
                }

            }
            private byte _GetTaskIdFromUser(string action)
            {
                while (true)
                {
                    Console.Write($"Enter Task ID to {action} (0 to cancel): ");
                    if (byte.TryParse(Console.ReadLine(), out byte id))
                        return id;

                    _ShowErrorMessage("Invalid input. Numbers only!");
                }
            }
            void _ShowEditTaskWindow()
            {
                byte SelectedID;
                string ErrorMessage = string.Empty;
                while (true)
                {
                    Console.Clear();
                    _ShowToDoList();
                    _ShowErrorMessage(ErrorMessage);
                    SelectedID = _GetTaskIdFromUser("Edit");
                    if (SelectedID != 0)
                    {

                        Task SelectedTask = _ToDoList.Find(t => t.ID == SelectedID);
                        if (SelectedTask == null)
                        {
                            ErrorMessage = $"Ensure the ID there is no Task With ID : {SelectedID}";
                            continue;
                        }

                        Console.WriteLine($"Current Description: {SelectedTask.Description}");
                        Console.Write("New Description: ");
                        string NewDescription = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(NewDescription))
                        {
                            Console.Clear();
                            _ShowErrorMessage("Description cannot be empty!");
                            return;
                        }

                        SelectedTask.Description = NewDescription;
                        _ShowSuccessMessage("Task updated successfully!");
                    }
                    _Continue();
                    Console.Clear();
                    break; ;
                }
            }
            void _ShowToDoList()
            {
                if (!_ToDoList.Any())
                {
                    _ShowErrorMessage("No Tasks found.");
                    return;
                }
                Console.WriteLine("================ Your Todolist:================");
                foreach (Task t in _ToDoList)
                {
                    char IsCompletedMark = (t.IsCompleted) ? '✓' : ' ';
                    Console.WriteLine($"{t.ID}[{IsCompletedMark}] {t.Description}");
                }
                Console.WriteLine("==============================================");
            }
            void _ShowMainMenu()
            {
                _ShowToDoList();
                Console.WriteLine("Todo List Application:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Edit Task");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
            }
            void _ShowErrorMessage(string Message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Message);
                Console.ResetColor();
            }
            void _ShowSuccessMessage(string Message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Message);
                Console.ResetColor();
            }
            enum enOperation { AddTask = 1, EditTask = 2, MarkAsCompleted = 3, DleteTask = 4, Exit = 5 }
            byte _GetMainMenuOperation()
            {
                byte Operation = 2;

                Console.Write("Enter Your Choice[1 to 5]: ");
                string InPut = Console.ReadLine();

                if (InPut.Length == 1 && char.IsDigit(InPut[0]))
                {
                    if (Byte.TryParse(InPut, out Operation) && Operation < 6 && Operation > 0)
                        return Operation;
                }
                return 0;
            }
            bool _PerformMainMenuOptions(enOperation operation)
            {
                Console.Clear();
                switch (operation)
                {
                    case enOperation.AddTask:
                        _ShowAddTaskScreen();
                        return true;

                    case enOperation.EditTask:
                        _ShowEditTaskWindow();
                        return true;

                    case enOperation.MarkAsCompleted:
                        _ShowMarkAsCompletedScreen();
                        return true;

                    case enOperation.DleteTask:
                        _ShowDeleteTaskScreen();
                        return true;

                    case enOperation.Exit:
                        return false;

                    default:
                        _ShowErrorMessage("Invalid input. Please enter a number between [1 and 5]?");
                        return true;
                }

            }
            void _ShowAddTaskScreen()
            {
                Console.WriteLine("=========== Adding new Task ===========");
                Console.Write("Task Description:");
                string Description = Console.ReadLine();
                _AddTask(Description);
            }

            public void Run()
            {
                while (true)
                {
                    enOperation ChoicedOperation;
                    do
                    {
                        _ShowMainMenu();
                        ChoicedOperation = (enOperation)_GetMainMenuOperation();

                    } while (_PerformMainMenuOptions(ChoicedOperation));

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

        }

        static void Main(string[] args)
        {
            TodoList t = new TodoList();
            t.Run();
        }
    }
}
