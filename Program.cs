using System;
using System.IO;

namespace Siemens2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter a command: ");
                    Console.WriteLine("'scan' to explore a directory, 'load' to load from a JSON file, or 'exit' to quit.");
                    string command = Console.ReadLine().ToLower();

                    if (command == "exit")
                    {
                        Console.WriteLine("Exiting the program...");
                        break;
                    }

                    if (command == "scan")
                    {
                        Console.WriteLine("Enter the directory path: ");
                        string directoryPath = Console.ReadLine();

                        if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
                        {
                            Console.WriteLine("Invalid directory path.");
                            continue;
                        }

                        // Explore directory
                        DirectoryScanner scanner = new DirectoryScanner();
                        DirectoryDetails directoryDetails = scanner.ExploreDirectory(directoryPath);

                        // Print directory structure
                        Console.WriteLine("Directory Structure: ");
                        scanner.PrintDirectoryTree(directoryDetails);

                        // Save to JSON
                        Console.WriteLine("Enter the path to save the JSON file (or leave blank to skip): ");
                        string jsonFilePath = Console.ReadLine();

                        if (!string.IsNullOrEmpty(jsonFilePath))
                        {
                            JsonHandler jsonHandler = new JsonHandler();
                            jsonHandler.SaveJSONToFile(directoryDetails, jsonFilePath);
                            Console.WriteLine($"Directory structure saved to {jsonFilePath}");
                        }
                        else
                        {
                            Console.WriteLine("Skipped saving JSON file.");
                        }
                    }
                    else if (command == "load")
                    {
                        // Load from JSON
                        Console.WriteLine("Enter the JSON file path to load: ");
                        string jsonFilePath = Console.ReadLine();

                        if (!File.Exists(jsonFilePath))
                        {
                            Console.WriteLine("Invalid file path.");
                            continue;
                        }

                        JsonHandler jsonHandler = new JsonHandler();
                        DirectoryDetails directoryDetails = jsonHandler.LoadJSONFromFile(jsonFilePath);

                        if (directoryDetails != null)
                        {
                            Console.WriteLine("Loaded directory structure from JSON:");
                            DirectoryScanner scanner = new DirectoryScanner();
                            scanner.PrintDirectoryTree(directoryDetails);
                        }
                        else
                        {
                            Console.WriteLine("Failed to load directory structure.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unknown command. Please enter 'scan', 'load', or 'exit'.");
                    }

                    Console.WriteLine("\n--------------------------------------\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
