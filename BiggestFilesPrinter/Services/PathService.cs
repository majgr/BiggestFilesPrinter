namespace BiggestFilesPrinter;

public class PathService
{
    public static string Get(string[] args, Settings settings)
    {
        var path = args.Any() ? args.Single() : string.Empty;
        if (!Path.IsPathFullyQualified(path))
        {
            path = settings.DefaultFolder;
            if (!Path.IsPathFullyQualified(path))
            {
                Console.WriteLine("Please, provide path:");
                path = Console.ReadLine();
                while (!Path.IsPathFullyQualified(path))
                {
                    Console.Clear();
                    Console.WriteLine($"'{path}' is not correct. ");
                    Console.WriteLine("Please, provide path:");
                    path = Console.ReadLine();
                }
            }
        }

        return path;
    }
}

