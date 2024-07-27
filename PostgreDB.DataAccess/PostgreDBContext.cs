using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostgreDB.DataAccess.DomainConfig;
using PostgreDB.Model.DomainModels;
using System.Reflection.Emit;

namespace PostgreDB.DataAccess
{
    public class PostgreDBContext : IdentityDbContext<Users>
    {
        private readonly string schema;
        public PostgreDBContext(IConfiguration configuration, DbContextOptions<PostgreDBContext> options) : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "DbContextOptions must not be null.");
            }
            if (configuration.GetSection("DbSchema") == null || configuration.GetSection("DbSchema").GetSection("pgSchema2").Value == null)
            {
                throw new ArgumentNullException(nameof(options), "Schema must not be null.");
            }
            schema = configuration.GetSection("DbSchema").GetSection("pgSchema2").Value ?? "";
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(schema);
            builder.ApplyConfiguration(new DateMapConfig());
            //this.Database.SqlQueryRaw<string>("test").ToList();
        }
        public DbSet<DateMaps> DateMaps { get; set; }
        public DbSet<GLIndex> GLIndexs { get; set; }
        public DbSet<GLIndexDetail> GLIndexDetails { get; set; }
        public DbSet<GLIndexPost> GLIndexPost { get; set; }
    }
}
