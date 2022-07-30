// See https://aka.ms/new-console-template for more information
using BiggestFilesPrinter;

var padSize = 10;
var consoleWidth = 80;

var settings = SettingsService.Get();
var path = PathService.Get(args, settings);
var filesData = FileService.Get(path);
var top = filesData
    .OrderByDescending(f => f.Size)
    .Take(settings.ResultsCount);

Console.Clear();
Console.WriteLine($"{"Size".PadRight(padSize)}| Path");
Console.WriteLine(string.Concat(Enumerable.Repeat("-", consoleWidth)));

foreach (var fileData in top)
{
    var sizePadded = fileData.SizeFormatted.PadRight(padSize);
    Console.WriteLine($"{sizePadded}| {fileData.Path}");
}




