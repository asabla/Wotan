using FluentValidation;

using Microsoft.Extensions.Options;

namespace Wotan.Backend.Api.Settings;

internal class FluentValidationOptions<TOptions> : IValidateOptions<TOptions>
    where TOptions : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string? _name;

    public FluentValidationOptions(
        IServiceProvider serviceProvider,
        string? name)
    {
        _serviceProvider = serviceProvider;
        _name = name;
    }

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        // Everything is fine, just return value
        if (string.IsNullOrWhiteSpace(_name) is false
            && _name.Equals(name) is false)
            return ValidateOptionsResult.Skip;

        ArgumentNullException.ThrowIfNull(options);

        using var scope = _serviceProvider.CreateAsyncScope();
        var validator = scope.ServiceProvider.GetRequiredService<IValidator<TOptions>>();

        var results = validator.Validate(options);

        // Everything went fine
        if (results.IsValid)
            return ValidateOptionsResult.Success;

        var typeName = options.GetType().Name;
        var errors = new List<string>();

        foreach (var r in results.Errors)
        {
            errors.Add($"Validation error: '{typeName}.{r.PropertyName}' "
                + $"with errors: '{r.ErrorCode}'");
        }

        return ValidateOptionsResult.Fail(errors);
    }
}