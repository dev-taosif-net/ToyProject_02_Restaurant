using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services )
    {
        var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(applicationAssembly));
        services.AddValidatorsFromAssemblies([applicationAssembly]).AddFluentValidationAutoValidation();

    }
}