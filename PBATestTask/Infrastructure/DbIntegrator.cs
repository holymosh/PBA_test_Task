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
                    break;
                case ConfiguredContext.User:
                    collection.AddEntityFrameworkSqlServer().AddDbContext<UserContext>(builder => builder.UseSqlServer(connectionString));
                    break;
            }
        }
    }
}
