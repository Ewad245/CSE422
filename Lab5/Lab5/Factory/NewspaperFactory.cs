using Lab5.Models;

namespace Lab5.Factory
{
    public class NewspaperFactory : DocumentFactory
    {
        public override Document CreateDocument(string title, string id)
        {
            return new Newspaper { Title = title, Id = id, IsAvailable = true };
        }
    }
} 