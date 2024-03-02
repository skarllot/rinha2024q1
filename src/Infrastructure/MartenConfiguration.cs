using JasperFx.CodeGeneration;
using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Marten.Services.Json;
using Rinha.MMXXIV.Q1.Core.Clientes;
using Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato;
using Weasel.Core;

namespace Rinha.MMXXIV.Q1.Infrastructure;

public class MartenConfiguration : IConfigureMarten
{
    public void Configure(IServiceProvider services, StoreOptions options)
    {
        options.AutoCreateSchemaObjects = AutoCreate.None;
        options.GeneratedCodeMode = TypeLoadMode.Static;
        options.DatabaseSchemaName = "docs";
        options.Events.DatabaseSchemaName = "stream";
        options.Events.StreamIdentity = StreamIdentity.AsGuid;

        options.UseDefaultSerialization(
            EnumStorage.AsString,
            casing: Casing.CamelCase,
            nonPublicMembersStorage: NonPublicMembersStorage.All,
            serializerType: SerializerType.SystemTextJson);

        options.Schema.For<ExtratoModel>()
            .Identity(r => r.Id)
            .DocumentAlias("extrato")
            .DatabaseSchemaName("projections");

        options.Projections.LiveStreamAggregation<Cliente>();
        options.Projections.Add<ObterExtratoProjection>(ProjectionLifecycle.Async);
    }
}
