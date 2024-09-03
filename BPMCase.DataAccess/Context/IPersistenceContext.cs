using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BPMCase.DataAccess.Context
{
    public interface IPersistenceContext : IEntityQueryProvider, IEntityFinder
    {
        void Attach(object entity);

        void Add(object entity);

        void AddRange(IEnumerable<object> entities);

        void AddRange(params object[] entities);

        void Update(object entity);

        void UpdateRange(IEnumerable<object> entities);

        void UpdateRange(params object[] entities);

        void Remove(object entity);

        void RemoveRange(IEnumerable<object> entities);

        void RemoveRange(params object[] entities);

        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<(bool success, int count)> SaveChangesWithCatchAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task SaveChangesWithCatchAndThrowAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbContext GetContext();
    }
}
