using JasperFx.CodeGeneration;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Oakton;
using Rinha.MMXXIV.Q1.Infrastructure;
using Rinha.MMXXIV.Q1.Infrastructure.Clientes;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(
    (b, s) =>
    {
        s.AddSingleton<IConfigureMarten, MartenConfiguration>();

        s.AddMarten(b.Configuration.GetConnectionString("Rinha") ?? throw new InvalidOperationException())
            .OptimizeArtifactWorkflow(TypeLoadMode.Static)
            .UseLightweightSessions()
            .InitializeWith<ClienteInitialData>()
            .AddAsyncDaemon(DaemonMode.HotCold);
    });

builder.ApplyOaktonExtensions();

var app = builder.Build();

app.RunOaktonCommandsSynchronously(args);
