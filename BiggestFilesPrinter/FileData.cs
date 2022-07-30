using System;
namespace BiggestFilesPrinter;

public record FileData
{
    public string Path { get; init; }
    public long Size { get; init; }
    public string SizeFormatted
    {
        get
        {
            if (Size < 100)
            {
                return Size.ToString();
            }

            var currentSize = Size / 1024m;
            if (currentSize < 1000m)
            {
                return String.Format("{0:0.00} KB", currentSize);
            }

            currentSize = currentSize / 1024m;
            if (currentSize < 1000m)
            {
                return String.Format("{0:0.00} MB", currentSize);
            }

            currentSize = currentSize / 1024m;
            if (currentSize < 1000m)
            {
                return String.Format("{0:0.00} GB", currentSize);
            }

            currentSize = currentSize / 1024m;
            return String.Format("{0:0.00} TB", currentSize);
        }
    }
}

