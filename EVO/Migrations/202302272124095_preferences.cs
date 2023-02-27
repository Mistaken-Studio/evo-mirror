using System.Data.Entity.Migrations;

namespace Xname.EVO.Migrations;

public partial class Preferences : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.RankPreferences",
            c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    Rank_Id = c.Int(),
                })
            .PrimaryKey(t => t.UserId)
            .ForeignKey("dbo.Ranks", t => t.Rank_Id)
            .Index(t => t.Rank_Id);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.RankPreferences", "Rank_Id", "dbo.Ranks");
        DropIndex("dbo.RankPreferences", new[] { "Rank_Id" });
        DropTable("dbo.RankPreferences");
    }
}
