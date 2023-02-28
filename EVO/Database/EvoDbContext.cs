using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace Xname.EVO.Database;

[DbConfigurationType(typeof(MySqlEFConfiguration))]
internal sealed class EvoDbContext : DbContext
{
    public DbSet<Stats> Stats { get; set; }
    
    public DbSet<Rank> Ranks { get; set; }
    
    public DbSet<Rarity> Rarities { get; set; }

    public DbSet<Achievement> Achievements { get; set; }
    
    public DbSet<RankUnlock> RankUnlocks { get; set; }

    public DbSet<RankPreference> RankPreferences { get; set; }

    public EvoDbContext() : base(Plugin.Config.Database.ConnectionString)
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}