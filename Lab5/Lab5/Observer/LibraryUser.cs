namespace Lab5.Observer
{
    public class LibraryUser : ILibraryObserver
    {
        public string Name { get; set; }
        public void Update(string message)
        {
            Console.WriteLine($"Notification for {Name}: {message}");
        }
    }
} 