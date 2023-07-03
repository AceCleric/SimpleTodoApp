// This is a simple Todo application
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Globalization;

namespace SimpleTodoApp
{
   public class Program
    {
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Welcome to the simple Todo application!");

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\ts - Show todos");
                Console.WriteLine("\tc - Create todo");

                string userActionInput = Console.ReadLine();

                var ProgramInstance = new Program();
                ProgramInstance.processUserAction(userActionInput);

                Console.WriteLine("Would you like to close the Todos app? Yes or No");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    continue;
                }
                break;
            }
        }

        private void processUserAction(string input)
        {
            if (input == "s")
            {
                Console.WriteLine("Here are all your todos");

                Console.WriteLine("Would you like to perform an action? Yes or No");
                string performActionAnswer = Console.ReadLine().ToLower();

                if (performActionAnswer == "yes")
                {
                    Console.WriteLine("\tu - Which todo would you like to pick?");

                    Console.WriteLine("\tu - Update todo");
                    Console.WriteLine("\tf - Finish todo");
                    Console.WriteLine("\td - Delete todo");

                }

            }
            else if (input == "c")
            {
                Console.WriteLine("Let's Create your todo!");

                Console.WriteLine("What is the title of your todo?");
                string title = Console.ReadLine();

                Console.WriteLine("What is the description of your todo?");
                string description = Console.ReadLine();

                List<Todo> todos = new List<Todo>();
                todos.Add(new Todo { Title = title, Description = description });

                TodoManager todoManager = new TodoManager();
                todoManager.SaveTodos(todos);

        
            }
            else
            {
                Console.WriteLine("Invalid option inserted! Please try again!");
            }
        }
    }
}