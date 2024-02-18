using CSharpFunctionalExtensions;
using JasperFx.CodeGeneration;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;
using Rinha.MMXXIV.Q1.Core.Clientes.Transferir.v1;
using Rinha.MMXXIV.Q1.Core.Common;
using Rinha.MMXXIV.Q1.Infrastructure;
using Rinha.MMXXIV.Q1.Infrastructure.Clientes;
using Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(
    options => { options.SerializerOptions.TypeInfoResolverChain.Insert(0, RinhaJsonSerializerContext.Default); });

builder.Services.AddSingleton<IConfigureMarten, MartenConfiguration>();
builder.Services.AddScoped<IReceberTransferirParaCliente, ReceberTransferirParaCliente>();
builder.Services.AddScoped(typeof(IEntityStore<>), typeof(MartenEntityStore<>));
builder.Services.AddMarten(builder.Configuration.GetConnectionString("Rinha") ?? throw new InvalidOperationException())
    .OptimizeArtifactWorkflow(TypeLoadMode.Static)
    .UseLightweightSessions()
    .InitializeWith<ClienteInitialData>()
    .AddAsyncDaemon(DaemonMode.HotCold);

var app = builder.Build();

var clientesApi = app.MapGroup("/clientes");

clientesApi.MapPost(
    "/{id:long}/transacoes",
    (long id, TransferirParaClienteRequest request, IReceberTransferirParaCliente useCase, CancellationToken ct) =>
        useCase.Executar(id, request, ct)
            .Finally(
                r => r switch
                {
                    { IsSuccess: true } => Results.Ok(r.Value),

                    { Error: ErroAoTransferir.ClienteNaoEncontrado } =>
                        Results.Problem("Cliente não encontrado", statusCode: StatusCodes.Status404NotFound),
                    { Error: ErroAoTransferir.TipoTransferênciaInválido } =>
                        Results.Problem("Tipo de transferência inválido"),
                    { Error: ErroAoTransferir.ValorNegativo } =>
                        Results.Problem("Transferência com valor negativo"),
                    { Error: ErroAoTransferir.ValorZerado } =>
                        Results.Problem("Transferência com valor zerado"),
                    { Error: ErroAoTransferir.DescriçãoVazia } =>
                        Results.Problem("Descrição vazia"),
                    { Error: ErroAoTransferir.DescriçãoMuitoLonga } =>
                        Results.Problem("Descrição muito longa"),
                    { Error: ErroAoTransferir.SaldoInsuficiente } =>
                        Results.Problem("Saldo insuficiente", statusCode: StatusCodes.Status422UnprocessableEntity),
                    { Error: ErroAoTransferir.LimiteInsuficiente } =>
                        Results.Problem("Limite insuficiente", statusCode: StatusCodes.Status422UnprocessableEntity),
                    { Error: ErroAoTransferir.ErroDesconhecido } =>
                        Results.Problem("Erro desconhecido"),

                    _ => Results.Problem(r.Error.ToString())
                }));

clientesApi.MapGet(
    "/{id:long}/extrato",
    (long id, IQuerySession session, CancellationToken ct) =>
        session.Query<ExtratoModel>()
            .FirstOrDefaultAsync(x => x.Id == id.AsCombGuid(), ct)
            .ToResultAsync(ErroAoObterExtrato.ClienteNaoEncontrado)
            .Finally(
                r => r switch
                {
                    { IsSuccess: true } => Results.Ok(r.Value.Data),

                    { Error: ErroAoObterExtrato.ClienteNaoEncontrado } =>
                        Results.Problem("Cliente não encontrado", statusCode: StatusCodes.Status404NotFound),

                    _ => Results.Problem(r.Error.ToString())
                }));

app.Run();
