using ForTestTasks.Patterns.Singleton;

namespace ForTestTasks;

public class Program
{
    private static CustomStringReader _stringReader;
    
    public static async Task Main(string[] args)
    {
        InitServices();

        Console.WriteLine("Enter path to file:");
        
        string? pathToFile = Console.ReadLine();
            
        await _stringReader.ReadFirstNonEmptyLineAsync(pathToFile);
    }

    private static void InitServices()
    {
        _stringReader = CustomStringReader.Instance;
    }
}