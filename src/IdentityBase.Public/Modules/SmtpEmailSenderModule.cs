namespace IdentityBase.Public
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using ServiceBase.Modules;
    using ServiceBase.Notification.Email;
    using ServiceBase.Notification.Smtp;

    public class SmtpEmailSenderModule : IModule
    {
        public void ConfigureServices(
            IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IEmailService, DefaultEmailService>();

            services.AddSingleton(configuration
                .GetSection("Email").Get<DefaultEmailServiceOptions>());

            services.AddScoped<IEmailSender, SmtpEmailSender>();

            services.AddSingleton(configuration
                .GetSection("Email:Smtp").Get<SmtpOptions>());
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
