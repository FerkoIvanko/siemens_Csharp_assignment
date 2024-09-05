namespace DirectoryExplorer
{
    public class DirectoryDetails
    {
        public string Name { get; set; }
        public List<FileDetails> Files { get; set; } = new List<FileDetails>();
        public List<DirectoryDetails> Subdirectories { get; set; } = new List<DirectoryDetails>();
    }

    public class FileDetails
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
