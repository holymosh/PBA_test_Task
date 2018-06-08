using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public interface IDbContextWrapper
    {
        DbContext Context { get; }
    }

    public class ContextWrapper : IDbContextWrapper
    {
        public ContextWrapper(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; }
    }
}