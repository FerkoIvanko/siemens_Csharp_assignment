using System;
using System.IO;
using System.Collections.Generic;

namespace Siemens2
{
    public class DirectoryScanner
    {
        public DirectoryDetails ExploreDirectory(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"The directory {path} does not exist.");

            var directoryInfo = new DirectoryInfo(path);

            var directoryDetails = new DirectoryDetails
            {
                Name = directoryInfo.Name,
                Files = new List<FileDetail>(),
                SubDirectories = new List<DirectoryDetails>()
            };

            foreach (var file in directoryInfo.GetFiles())
            {
                directoryDetails.Files.Add(new FileDetail
                {
                    Name = file.Name,
                    Extension = file.Extension
                });
            }

            foreach (var subDirectory in directoryInfo.GetDirectories())
            {
                directoryDetails.SubDirectories.Add(ExploreDirectory(subDirectory.FullName));
            }

            return directoryDetails;
        }

        // Method to print the directory tree
        public void PrintDirectoryTree(DirectoryDetails directoryDetails, string indent = "")
        {
            Console.WriteLine(indent + directoryDetails.Name);

            foreach (var file in directoryDetails.Files)
            {
                Console.WriteLine(indent + "  ├── " + file.Name);
            }

            foreach (var subDirectory in directoryDetails.SubDirectories)
            {
                Console.WriteLine(indent + "  └── " + subDirectory.Name);
                PrintDirectoryTree(subDirectory, indent + "    "); // Recursive call with increased indentation
            }
        }
    }
}
