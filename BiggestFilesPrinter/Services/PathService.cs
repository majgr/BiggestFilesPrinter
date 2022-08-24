namespace BiggestFilesPrinter;

public class PathService
{
    public static (PathService PathService, string Path) GetFromArgs(string[] args)
    {
        var path = args.Any() ? args.Single() : string.Empty;
        return (new PathService(), path);
    }
}

public static class PathServiceExtensions
{
    public static (PathService PathService, string Path) IfEmptyGetFromSettings(this (PathService PathService, string Path) option, Settings settings)
    {
        if (!Path.IsPathFullyQualified(option.Path))
        {
            var path = settings.DefaultFolder;
            return (option.PathService, path);
        }

        return option;
    }

    public static (PathService PathService, string Path) IfEmptyGetFromConsole(this (PathService PathService, string Path) option)
    {
        if (!Path.IsPathFullyQualified(option.Path))
        {
            Console.WriteLine("Please, provide path:");
            var path = Console.ReadLine();
            while (string.IsNullOrEmpty(path) || !Path.IsPathFullyQualified(path))
            {
                Console.Clear();
                Console.WriteLine($"'{path}' is not correct. ");
                Console.WriteLine("Please, provide path:");
                path = Console.ReadLine();
            }

            return (option.PathService, path);
        }

        return option;
    }

    public static string Unwrap(this (PathService PathService, string Path) option)
    {
        return option.Path;
    }
}




