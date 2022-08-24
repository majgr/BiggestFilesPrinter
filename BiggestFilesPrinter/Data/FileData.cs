using System;
namespace BiggestFilesPrinter;

public record FileData
{
    public string Path { get; init; } = "";
    public long Size { get; init; }
    public string SizeFormatted
    {
        get
        {
            var sizeFormats = new string[] { "", "K", "M", "G", "T" };
            var sizeIndex = 0;
            var size = (decimal)Size;
            while (size >= 1000m && sizeIndex < sizeFormats.Length)
            {
                size = size / 1024m;
                sizeIndex++;
            }

            return String.Format($"{{0:0.00}} {sizeFormats[sizeIndex]}B", size);
        }
    }
}

