using System;

namespace BiggestFilesPrinter;

public class Settings
{
    public const string AppSettings = "AppSettings";

    public string DefaultFolder { get; set; } = "";
    public int ResultsCount { get; set; } = 100;
}

