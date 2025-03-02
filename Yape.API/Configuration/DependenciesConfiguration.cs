using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Yape.Application.Interfaces;
using Yape.Application.Services;
using Yape.Infrastructure.Interfaces;
using Yape.Infrastructure.Client;
using Yape.Infrastructure.Factories;
using Yape.Transversal.Mappings;

namespace Yape.API.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<CallClient>();
            services.AddScoped<EmailClient>();
            services.AddScoped<SmsClient>();
            services.AddScoped<WhatsAppClient>();

            services.AddScoped<INotificationSenderFactory, NotificationSenderFactory>();

            return services;
        }
    }
}
