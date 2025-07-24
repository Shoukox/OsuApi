using Microsoft.Extensions.Logging.Console;

namespace OsuApi.Logging;

internal class CustomConsoleFormatterOptions : ConsoleFormatterOptions
{
    public string? CustomPrefix { get; set; }
}