using ArtOfUnitTesting.Interfaces;

namespace ArtOfUnitTesting.Implementers;

public class FileExtensionManager : IExtensionManager
{
    public bool IsValid(string name)
    {
        return File.Exists(name);
    }
}