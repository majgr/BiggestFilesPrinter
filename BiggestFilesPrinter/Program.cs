// See https://aka.ms/new-console-template for more information
using BiggestFilesPrinter;

var padSize = 10;
var consoleWidth = 80;
var getFormattedRow = (string size, string path) => $"{size.PadRight(padSize)}| {path}";

var settings = SettingsService.Get();
var path = PathService
    .GetFromArgs(args)
    .IfEmptyGetFromSettings(settings)
    .IfEmptyGetFromConsole()
    .Unwrap();

var filesData = FileService.Get(path);
var top = filesData
    .OrderByDescending(f => f.Size)
    .Take(settings.ResultsCount);

Console.Clear();
Console.WriteLine(getFormattedRow("Size", "Path"));
Console.WriteLine(string.Concat(Enumerable.Repeat("-", consoleWidth)));

foreach (var fileData in top)
{
    Console.WriteLine(getFormattedRow(fileData.SizeFormatted, fileData.Path));
}




