namespace BPMCase.DataAccess.Context
{
    public interface IEntityQueryProvider
    {
        IQueryable<T> Query<T>()
           where T : class;
    }
}
