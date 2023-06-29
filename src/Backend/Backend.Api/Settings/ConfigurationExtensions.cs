using FluentValidation;

namespace Wotan.Backend.Api.Settings;

internal static class ConfigurationExtensions
{
    public static WebApplicationBuilder APIConfigurationSetup(
        this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: true,
                reloadOnChange: true);

        // Validate loaded configuration with custom validator
        builder.Services.AddScoped<IValidator<ApiSettings>, ApiSettingsValidator>();
        builder.Services.AddOptions<ApiSettings>()
            .BindConfiguration(nameof(ApiSettings))
            .ValidateAPISettings()
            .ValidateOnStart();

        return builder;
    }
}