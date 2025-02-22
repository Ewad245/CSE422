public interface IReaderRepository
{
    Reader GetById(string id);
    void Add(Reader reader);
    void Update(Reader reader);
    IEnumerable<Reader> GetAll();
} 