namespace BiggestFilesPrinter;

public class PathService
{
    public static (PathService PathService, string Path) GetMaybe()
    {
        return (new PathService(), String.Empty);
    }
}

public static class PathServiceExtensions
{
    public static (PathService PathService, string Path)
        FromArgs(this (PathService PathService, string Path) maybe, string[] args)
    {
        if (!Path.IsPathFullyQualified(maybe.Path))
        {
            var path = args.Any() ? args.Single() : string.Empty;
            return (new PathService(), path);
        }

        return maybe;
    }

    public static (PathService PathService, string Path)
        FromSettings(this (PathService PathService, string Path) maybe, Settings settings)
    {
        if (!Path.IsPathFullyQualified(maybe.Path))
        {
            var path = settings.DefaultFolder;
            return (new PathService(), path);
        }

        return maybe;
    }

    public static (PathService PathService, string Path)
        FromConsole(this (PathService PathService, string Path) maybe)
    {
        if (!Path.IsPathFullyQualified(maybe.Path))
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

            return (new PathService(), path);
        }

        return maybe;
    }

    public static string Unwrap(this (PathService PathService, string Path) maybe)
    {
        return maybe.Path;
    }
}




