using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;

namespace Spectre.Cli.Internal
{
    [Description("Displays the CLI library version")]
    [SuppressMessage("Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Injected")]
    internal sealed class VersionCommand : Command<VersionCommand.Settings>
    {
        private readonly IAnsiConsole _writer;

        public VersionCommand(IConfiguration configuration)
        {
            _writer = configuration?.Settings?.Console ?? AnsiConsole.Console;
        }

        public sealed class Settings : CommandSettings
        {
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var version = typeof(VersionCommand)?.Assembly?.GetName()?.Version?.ToString();
            version ??= "?";

            _writer.Write($"Spectre.Cli version {version}");

            return 0;
        }
    }
}
