using BackgroundJobs.API.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.SqlServer;

namespace BackgroundJobs.API.Configuration;

public static class HangfireConfig
{

    public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services, IWebHostEnvironment hostingEnvironment, IConfiguration config)
    {

        if (hostingEnvironment.IsDevelopment())
        {
            // Indica que o o Hangfire irá criar suas tabelas no SQL Server
            services.AddHangfire(configuration => configuration.UseMemoryStorage());
        }
        else
        {
            // Indica que o o Hangfire irá criar suas tabelas no SQL Server
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(config.GetConnectionString("SQLServerCs"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
        }

        services.AddHangfireServer();

        return services;
    }

    public static WebApplication UseHangfireConfiguration(this WebApplication app)
    {

        // Indica que está aplicação é o servidor        
        app.MapHangfireDashboard();

        // Delayed jobs - Faz o agendamento (irá ser processado daqui 7 dias)
        BackgroundJob.Schedule(() => Console.WriteLine("Schedule!"), TimeSpan.FromDays(7));

        // Fire-and-forget jobs - Inicia imediatamente 
        var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
        // Continuation - Processa tarefa 'filha' depois da tarefa 'pai' (indicada pelo jodID)
        BackgroundJob.ContinueWith(jobId, () => Console.WriteLine("Continuation!"));

        // Recurring jobs - Faz o agendamento recorrente do processo (diário)
        RecurringJob.AddOrUpdate(() => Console.WriteLine("AddOrUpdate!"), Cron.Daily);

        RecurringJob.AddOrUpdate<DeleteProductsJob>(x => x.DoWork(), Cron.Minutely);
        BackgroundJob.Enqueue<SendNotificationJob>(x => x.DoWork());
        BackgroundJob.Schedule<UnsubscribeUserJob>(x => x.DoWork(), TimeSpan.FromMinutes(1));

        return app;
    }
}


