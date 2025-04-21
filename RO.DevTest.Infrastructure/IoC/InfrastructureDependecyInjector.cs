using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Handler.Interface;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Request;
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Validator;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Infrastructure.Abstractions;
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.Repositories;

namespace RO.DevTest.Infrastructure.IoC;

public static class InfrastructureDependecyInjector {
    /// <summary>
    /// Inject the dependencies of the Infrastructure layer into an
    /// <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to inject the dependencies into
    /// </param>
    /// <returns>
    /// The <see cref="IServiceCollection"/> with dependencies injected
    /// </returns>
    public static IServiceCollection InjectInfrastructureDependencies(this IServiceCollection services) {
        services.AddDefaultIdentity<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DefaultContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityAbstractor, IdentityAbstractor>();

        return services;
    }

    public static IServiceCollection InjectUserRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
    public static IServiceCollection ConfigureHandlers(this IServiceCollection services)
    {

        services.AddScoped<ICreateUserCommandHandler, CreateUserCommandHandler>();
        services.AddScoped<IDeleteUserCommandHandler, DeleteUserCommandHandler>();
        services.AddScoped<IGetUsersCommandHandler, GetUsersCommandHandler>();
        
        return services;
    }

    public static IServiceCollection ValidatorInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
        services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
        
        return services;
    }
}
