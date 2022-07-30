using System;
namespace BiggestFilesPrinter;

public class FileService
{
    public static List<FileData> Get(string path)
    {
        var folder = new DirectoryInfo(path);
        var fileData = folder.GetFiles().Select(f => new FileData() { Path = f.FullName, Size = f.Length }).ToList();
        foreach (var subfolder in folder.EnumerateDirectories())
        {
            fileData.AddRange(Get(subfolder.FullName));
        }

        return fileData;
    }
}

