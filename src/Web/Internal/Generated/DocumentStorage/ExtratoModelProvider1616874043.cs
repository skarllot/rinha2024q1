// <auto-generated/>
#pragma warning disable
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertExtratoModelOperation1616874043
    public class UpsertExtratoModelOperation1616874043 : Marten.Internal.Operations.StorageOperation<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertExtratoModelOperation1616874043(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select projections.mt_upsert_extrato(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpsertExtratoModelOperation1616874043
    
    
    // START: InsertExtratoModelOperation1616874043
    public class InsertExtratoModelOperation1616874043 : Marten.Internal.Operations.StorageOperation<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertExtratoModelOperation1616874043(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select projections.mt_insert_extrato(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: InsertExtratoModelOperation1616874043
    
    
    // START: UpdateExtratoModelOperation1616874043
    public class UpdateExtratoModelOperation1616874043 : Marten.Internal.Operations.StorageOperation<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateExtratoModelOperation1616874043(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select projections.mt_update_extrato(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpdateExtratoModelOperation1616874043
    
    
    // START: QueryOnlyExtratoModelSelector1616874043
    public class QueryOnlyExtratoModelSelector1616874043 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyExtratoModelSelector1616874043(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel Resolve(System.Data.Common.DbDataReader reader)
        {

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = _serializer.FromJson<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = await _serializer.FromJsonAsync<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyExtratoModelSelector1616874043
    
    
    // START: LightweightExtratoModelSelector1616874043
    public class LightweightExtratoModelSelector1616874043 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>, Marten.Linq.Selectors.ISelector<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightExtratoModelSelector1616874043(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = _serializer.FromJson<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = await _serializer.FromJsonAsync<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightExtratoModelSelector1616874043
    
    
    // START: IdentityMapExtratoModelSelector1616874043
    public class IdentityMapExtratoModelSelector1616874043 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>, Marten.Linq.Selectors.ISelector<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapExtratoModelSelector1616874043(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = _serializer.FromJson<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = await _serializer.FromJsonAsync<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapExtratoModelSelector1616874043
    
    
    // START: DirtyTrackingExtratoModelSelector1616874043
    public class DirtyTrackingExtratoModelSelector1616874043 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>, Marten.Linq.Selectors.ISelector<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingExtratoModelSelector1616874043(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = _serializer.FromJson<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document;
            document = await _serializer.FromJsonAsync<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingExtratoModelSelector1616874043
    
    
    // START: QueryOnlyExtratoModelDocumentStorage1616874043
    public class QueryOnlyExtratoModelDocumentStorage1616874043 : Marten.Internal.Storage.QueryOnlyDocumentStorage<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyExtratoModelDocumentStorage1616874043(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyExtratoModelSelector1616874043(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: QueryOnlyExtratoModelDocumentStorage1616874043
    
    
    // START: LightweightExtratoModelDocumentStorage1616874043
    public class LightweightExtratoModelDocumentStorage1616874043 : Marten.Internal.Storage.LightweightDocumentStorage<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightExtratoModelDocumentStorage1616874043(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightExtratoModelSelector1616874043(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: LightweightExtratoModelDocumentStorage1616874043
    
    
    // START: IdentityMapExtratoModelDocumentStorage1616874043
    public class IdentityMapExtratoModelDocumentStorage1616874043 : Marten.Internal.Storage.IdentityMapDocumentStorage<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapExtratoModelDocumentStorage1616874043(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapExtratoModelSelector1616874043(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: IdentityMapExtratoModelDocumentStorage1616874043
    
    
    // START: DirtyTrackingExtratoModelDocumentStorage1616874043
    public class DirtyTrackingExtratoModelDocumentStorage1616874043 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingExtratoModelDocumentStorage1616874043(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertExtratoModelOperation1616874043
            (
                document, Identity(document),
                session.Versions.ForType<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingExtratoModelSelector1616874043(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: DirtyTrackingExtratoModelDocumentStorage1616874043
    
    
    // START: ExtratoModelBulkLoader1616874043
    public class ExtratoModelBulkLoader1616874043 : Marten.Internal.CodeGeneration.BulkLoader<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid> _storage;

        public ExtratoModelBulkLoader1616874043(Marten.Internal.Storage.IDocumentStorage<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY projections.mt_doc_extrato(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_extrato_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into projections.mt_doc_extrato (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_extrato_temp.\"id\", mt_doc_extrato_temp.\"data\", mt_doc_extrato_temp.\"mt_version\", mt_doc_extrato_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_extrato_temp left join projections.mt_doc_extrato on mt_doc_extrato_temp.id = projections.mt_doc_extrato.id where projections.mt_doc_extrato.id is null)";

        public const string OVERWRITE_SQL = "update projections.mt_doc_extrato target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_extrato_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_extrato_temp as select * from projections.mt_doc_extrato limit 0";


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }

    }

    // END: ExtratoModelBulkLoader1616874043
    
    
    // START: ExtratoModelProvider1616874043
    public class ExtratoModelProvider1616874043 : Marten.Internal.Storage.DocumentProvider<Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato.ExtratoModel>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public ExtratoModelProvider1616874043(Marten.Schema.DocumentMapping mapping) : base(new ExtratoModelBulkLoader1616874043(new QueryOnlyExtratoModelDocumentStorage1616874043(mapping)), new QueryOnlyExtratoModelDocumentStorage1616874043(mapping), new LightweightExtratoModelDocumentStorage1616874043(mapping), new IdentityMapExtratoModelDocumentStorage1616874043(mapping), new DirtyTrackingExtratoModelDocumentStorage1616874043(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: ExtratoModelProvider1616874043
    
    
}
