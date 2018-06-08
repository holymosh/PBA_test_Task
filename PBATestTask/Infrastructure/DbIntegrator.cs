using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Common;

namespace Infrastructure
{
    public class DbIntegrator
    {
        public void  AddDb(IServiceCollection collection,string connectionString, ConfiguredContext context)
        {
            switch (context)
            {
                case ConfiguredContext.Department:
                    collection.AddEntityFrameworkSqlServer().AddDbContext<DepartmentContext>(builder => builder.UseSqlServer(connectionString));
                    collection.AddScoped<IDbContextWrapper, ContextWrapper>(serviceProvider => new ContextWrapper((DepartmentContext)serviceProvider.GetService(typeof(DepartmentContext))));
                    break;
                case ConfiguredContext.User:
                    collection.AddEntityFrameworkSqlServer().AddDbContext<UserContext>(builder => builder.UseSqlServer(connectionString));
                    collection.AddScoped<IDbContextWrapper, ContextWrapper>(serviceProvider => new ContextWrapper((UserContext)serviceProvider.GetService(typeof(UserContext))));
                    break;
            }
        }
    }
}
