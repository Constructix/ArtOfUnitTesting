using ArtOfUnitTesting.Interfaces;
namespace ArtOfUnitTesting;
public class LogAnalyser
{
    private  IExtensionManager Manager { get; init; }
    public LogAnalyser(IExtensionManager manager)
    {
        Manager = manager;
    }
    public bool IsValidLogFileName(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("File name is missing.");
        }
        return Manager.IsValid(fileName);
    }
}