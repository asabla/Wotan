using Microsoft.Extensions.Options;

namespace Wotan.Backend.Api.Settings;

internal static class SettingsValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateAPISettings<TOptions>(
        this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(
                serviceProvider: provider,
                name: optionsBuilder.Name));

        return optionsBuilder;
    }
}