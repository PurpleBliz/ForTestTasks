namespace ForTestTasks.Patterns.Singleton;

public class CustomStringReader
{
    private static CustomStringReader? _instance;
    
    private static readonly object LockObj = new object();
    
    private CustomStringReader()
    {
    }
    
    public static CustomStringReader Instance
    {
        get
        {
            lock (LockObj)
            {
                return _instance ??= new CustomStringReader();
            }
        }
    }
    
    public async Task ReadFirstNonEmptyLineAsync(string pathToFile)
    {
        try
        {
            var lines = await File.ReadAllLinesAsync(pathToFile);
            
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                
                Console.WriteLine($"[StringReader.ReadFirstNonEmptyLineAsync]: Line: {line}");
                
                break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[StringReader.ReadFirstNonEmptyLineAsync]: Unknown error: {ex.Message}");
        }
    }
}