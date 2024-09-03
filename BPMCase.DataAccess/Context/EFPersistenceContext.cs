using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCase.DataAccess.Context
{
    public class EFPersistenceContext : IPersistenceContext
    {
        public EFPersistenceContext(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }
        public DbContext DbContext { get; }

        public object Find(Type entityType, params object[] keyValues)
        {
            return DbContext.Find(entityType, keyValues);
        }

        public object Find(Type entityType, IEnumerable<object> keyValues)
        {
            return DbContext.Find(entityType, keyValues);
        }

        public ValueTask<object> FindAsync(Type entityType, params object[] keyValues)
        {
            return DbContext.FindAsync(entityType, keyValues);
        }

        public ValueTask<object> FindAsync(Type entityType, IEnumerable<object> keyValues)
        {
            return DbContext.FindAsync(entityType, keyValues);
        }

        public ValueTask<object> FindAsync(
            Type entityType,
            IEnumerable<object> keyValues,
            CancellationToken cancellationToken)
        {
            return DbContext.FindAsync(entityType, keyValues, cancellationToken);
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return DbContext.Set<T>();
        }

        public void Attach(object entity)
        {
            DbContext.Attach(entity);
        }

        public void Update(object entity)
        {
            DbContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<object> entities)
        {
            DbContext.UpdateRange(entities);
        }

        public void UpdateRange(params object[] entities)
        {
            DbContext.UpdateRange(entities);
        }

        public void Add(object entity)
        {
            DbContext.Add(entity);
        }

        public void AddRange(IEnumerable<object> entities)
        {
            DbContext.AddRange(entities);
        }

        public void AddRange(params object[] entities)
        {
            DbContext.AddRange(entities);
        }

        public void Remove(object entity)
        {
            DbContext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<object> entities)
        {
            DbContext.RemoveRange(entities);
        }

        public void RemoveRange(params object[] entities)
        {
            DbContext.RemoveRange(entities);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<(bool success, int count)> SaveChangesWithCatchAsync(CancellationToken cancellationToken = default)
        {
            int changes = 0;
            try
            {
                changes = await DbContext.SaveChangesAsync(cancellationToken);
                return (true, changes);
            }
            catch (Exception ex)
            {
                return (false, changes);
            }
        }

        public async Task SaveChangesWithCatchAndThrowAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DbContext GetContext()
        {
            return DbContext;
        }

        public object? Find(object?[]? keyValues)
        {
            throw new NotImplementedException();
        }

        public InternalEntityEntry? FindEntry<TKey>(TKey keyValue)
        {
            throw new NotImplementedException();
        }

        public InternalEntityEntry? FindEntry<TProperty>(IProperty property, TProperty propertyValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InternalEntityEntry> GetEntries<TProperty>(IProperty property, TProperty propertyValue)
        {
            throw new NotImplementedException();
        }

        public InternalEntityEntry? FindEntry(IEnumerable<object?> keyValues)
        {
            throw new NotImplementedException();
        }

        public InternalEntityEntry? FindEntry(IEnumerable<IProperty> properties, IEnumerable<object?> propertyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InternalEntityEntry> GetEntries(IEnumerable<IProperty> properties, IEnumerable<object?> propertyValues)
        {
            throw new NotImplementedException();
        }

        public ValueTask<object?> FindAsync(object?[]? keyValues, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Load(INavigation navigation, InternalEntityEntry entry, LoadOptions options)
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(INavigation navigation, InternalEntityEntry entry, LoadOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable Query(INavigation navigation, InternalEntityEntry entry)
        {
            throw new NotImplementedException();
        }

        public object[]? GetDatabaseValues(InternalEntityEntry entry)
        {
            throw new NotImplementedException();
        }

        public Task<object[]?> GetDatabaseValuesAsync(InternalEntityEntry entry, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
