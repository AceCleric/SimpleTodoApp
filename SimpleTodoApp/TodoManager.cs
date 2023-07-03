using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SimpleTodoApp
{

    public class TodoManager
    {

        private static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            while (!string.IsNullOrEmpty(currentDirectory))
            {
                string[] files = Directory.GetFiles(currentDirectory, "*.csproj");

                if (files.Length > 0)
                {
                    return currentDirectory;
                }

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            throw new Exception("Project root directory not found.");
        }


        public void SaveTodos(List<Todo> todos)
        {
            string json = JsonConvert.SerializeObject(todos, Formatting.Indented);
            string projectRootDirectory = GetProjectRootDirectory();
            string filePath = Path.Combine(projectRootDirectory, "todos.json");

            File.WriteAllText(filePath, json);
            Console.WriteLine("File saved successfully.");
            Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());
        }
    }

}