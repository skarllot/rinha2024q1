using JasperFx.CodeGeneration;
using Marten;
using Marten.Events;
using Marten.Services.Json;
using Weasel.Core;

namespace Rinha.MMXXIV.Q1.Infrastructure;

public class MartenConfiguration : IConfigureMarten
{
    public void Configure(IServiceProvider services, StoreOptions options)
    {
        options.GeneratedCodeMode = TypeLoadMode.Static;
        options.DatabaseSchemaName = "docs";
        options.Events.DatabaseSchemaName = "events";
        options.Events.StreamIdentity = StreamIdentity.AsString;

        options.UseDefaultSerialization(
            EnumStorage.AsString,
            nonPublicMembersStorage: NonPublicMembersStorage.All,
            serializerType: SerializerType.SystemTextJson);
    }
}
