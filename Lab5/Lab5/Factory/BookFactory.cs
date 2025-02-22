using Lab5.Models;

namespace Lab5.Factory
{
    public class BookFactory : DocumentFactory
    {
        public override Document CreateDocument(string title, string id)
        {
            return new Book { Title = title, Id = id, IsAvailable = true };
        }
    }
} 