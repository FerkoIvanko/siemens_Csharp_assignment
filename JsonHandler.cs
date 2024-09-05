using System;
using System.IO;
using Newtonsoft.Json;

namespace Siemens2
{
    public class JsonHandler
    {
        // Ukladanie objektu DirectoryDetails ako JSON súbor
        public void SaveJSONToFile(DirectoryDetails directoryInfo, string jsonFilePath)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(directoryInfo, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the JSON file: {ex.Message}");
            }
        }

        // Nová metóda pre načítanie JSON súboru a jeho deserializáciu do objektu DirectoryDetails
        public DirectoryDetails LoadJSONFromFile(string jsonFilePath)
        {
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string jsonString = File.ReadAllText(jsonFilePath);
                    DirectoryDetails directoryInfo = JsonConvert.DeserializeObject<DirectoryDetails>(jsonString);
                    return directoryInfo;
                }
                else
                {
                    Console.WriteLine("The specified JSON file does not exist.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the JSON file: {ex.Message}");
                return null;
            }
        }
    }
}
