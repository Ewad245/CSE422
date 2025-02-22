using System;
using System.Collections.Generic;

public class InMemoryReaderRepository : IReaderRepository
{
    private readonly Dictionary<string, Reader> _readers = new();

    public InMemoryReaderRepository()
    {
        // Add sample data
        AddSampleReaders();
    }

    public Reader GetById(string id)
    {
        if (_readers.TryGetValue(id, out var reader))
            return reader;
        throw new KeyNotFoundException($"Reader with ID {id} not found");
    }

    public void Add(Reader reader)
    {
        if (string.IsNullOrEmpty(reader.Id))
            reader.Id = Guid.NewGuid().ToString();
        
        _readers[reader.Id] = reader;
    }

    public void Update(Reader reader)
    {
        if (!_readers.ContainsKey(reader.Id))
            throw new KeyNotFoundException($"Reader with ID {reader.Id} not found");
        
        _readers[reader.Id] = reader;
    }

    public IEnumerable<Reader> GetAll()
    {
        return _readers.Values;
    }

    private void AddSampleReaders()
    {
        var readers = new[]
        {
            new Reader { Id = "1", Name = "John Doe" },
            new Reader { Id = "2", Name = "Jane Smith" },
            new Reader { Id = "3", Name = "Bob Johnson" }
        };

        foreach (var reader in readers)
        {
            Add(reader);
        }
    }
} 