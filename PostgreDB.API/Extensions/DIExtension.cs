using PostgreDB.DataAccess.Infrastructures;
using PostgreDB.DataAccess.Repositories;

namespace PostgreDB.API.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection RegisterAllDI(this IServiceCollection services) 
        {
            #region Infrastructures
            services.AddScoped(typeof(IDBFactory), typeof(DBFactory));
            #endregion

            #region Repositories
            services.AddScoped<IPostgreSQLRepository, PostgreSQLRepository>();
            #endregion
            return services;
        }
    }
}
