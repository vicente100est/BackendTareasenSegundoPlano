using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
            .AddSingleton<IFliesData, FliesData >();
    })
    .Build();

host.Run();
