using Lab5.Models;

namespace Lab5.Factory
{
    public class MagazineFactory : DocumentFactory
    {
        public override Document CreateDocument(string title, string id)
        {
            return new Magazine { Title = title, Id = id, IsAvailable = true };
        }
    }
} 