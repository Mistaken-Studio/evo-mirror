using System.Data.Entity;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;

namespace Xname.EVO.Database;

[DbConfigurationType(typeof(MySqlEFConfiguration))]
internal sealed class EvoDbContext : DbContext
{
    public DbSet<EvoStats> EvoStats { get; set; }

    public EvoDbContext() : base(Plugin.Config.Database.ConnectionString)
    {
    }
    
}