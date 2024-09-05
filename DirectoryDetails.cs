using System.Collections.Generic;

namespace Siemens2
{
    public class DirectoryDetails
    {
        public string Name { get; set; }
        public List<FileDetail> Files { get; set; }
        public List<DirectoryDetails> SubDirectories { get; set; }
    }

    public class FileDetail
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
