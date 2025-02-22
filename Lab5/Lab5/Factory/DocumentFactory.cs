using Lab5.Models;

namespace Lab5.Factory
{
    public abstract class DocumentFactory
    {
        public abstract Document CreateDocument(string title, string id);
    }
} 