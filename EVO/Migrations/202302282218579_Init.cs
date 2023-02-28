namespace Xname.EVO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Requirement = c.String(unicode: false),
                        Flags = c.Int(nullable: false),
                        InOneRound = c.Boolean(nullable: false),
                        Rank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ranks", t => t.Rank_Id)
                .Index(t => t.Rank_Id);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Color = c.String(unicode: false),
                        Rarity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rarities", t => t.Rarity_Id)
                .Index(t => t.Rarity_Id);
            
            CreateTable(
                "dbo.Rarities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Color = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RankPreferences",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Ranks", t => t.RankId, cascadeDelete: true)
                .Index(t => t.RankId);
            
            CreateTable(
                "dbo.RankUnlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(unicode: false),
                        RankId = c.Int(nullable: false),
                        TimeUnlocked = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ranks", t => t.RankId, cascadeDelete: true)
                .Index(t => t.RankId);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        WarheadStart = c.Int(nullable: false),
                        WarheadStop = c.Int(nullable: false),
                        Escaped = c.Int(nullable: false),
                        PlayedClass0 = c.Int(nullable: false),
                        PlayedClass1 = c.Int(nullable: false),
                        PlayedClass2 = c.Int(nullable: false),
                        PlayedClass3 = c.Int(nullable: false),
                        PlayedClass4 = c.Int(nullable: false),
                        PlayedClass5 = c.Int(nullable: false),
                        PlayedClass6 = c.Int(nullable: false),
                        PlayedClass7 = c.Int(nullable: false),
                        PlayedClass8 = c.Int(nullable: false),
                        PlayedClass9 = c.Int(nullable: false),
                        PlayedClass10 = c.Int(nullable: false),
                        PlayedClass11 = c.Int(nullable: false),
                        PlayedClass12 = c.Int(nullable: false),
                        PlayedClass13 = c.Int(nullable: false),
                        PlayedClass15 = c.Int(nullable: false),
                        PlayedClass16 = c.Int(nullable: false),
                        PlayedClass17 = c.Int(nullable: false),
                        PlayedClass18 = c.Int(nullable: false),
                        PlayedClass19 = c.Int(nullable: false),
                        PlayedClass20 = c.Int(nullable: false),
                        TimePlayedClass0 = c.Single(nullable: false),
                        TimePlayedClass1 = c.Single(nullable: false),
                        TimePlayedClass2 = c.Single(nullable: false),
                        TimePlayedClass3 = c.Single(nullable: false),
                        TimePlayedClass4 = c.Single(nullable: false),
                        TimePlayedClass5 = c.Single(nullable: false),
                        TimePlayedClass6 = c.Single(nullable: false),
                        TimePlayedClass7 = c.Single(nullable: false),
                        TimePlayedClass8 = c.Single(nullable: false),
                        TimePlayedClass9 = c.Single(nullable: false),
                        TimePlayedClass10 = c.Single(nullable: false),
                        TimePlayedClass11 = c.Single(nullable: false),
                        TimePlayedClass12 = c.Single(nullable: false),
                        TimePlayedClass13 = c.Single(nullable: false),
                        TimePlayedClass15 = c.Single(nullable: false),
                        TimePlayedClass16 = c.Single(nullable: false),
                        TimePlayedClass17 = c.Single(nullable: false),
                        TimePlayedClass18 = c.Single(nullable: false),
                        TimePlayedClass19 = c.Single(nullable: false),
                        TimePlayedClass20 = c.Single(nullable: false),
                        KilledClass0 = c.Int(nullable: false),
                        KilledClass1 = c.Int(nullable: false),
                        KilledClass2 = c.Int(nullable: false),
                        KilledClass3 = c.Int(nullable: false),
                        KilledClass4 = c.Int(nullable: false),
                        KilledClass5 = c.Int(nullable: false),
                        KilledClass6 = c.Int(nullable: false),
                        KilledClass7 = c.Int(nullable: false),
                        KilledClass8 = c.Int(nullable: false),
                        KilledClass9 = c.Int(nullable: false),
                        KilledClass10 = c.Int(nullable: false),
                        KilledClass11 = c.Int(nullable: false),
                        KilledClass12 = c.Int(nullable: false),
                        KilledClass13 = c.Int(nullable: false),
                        KilledClass15 = c.Int(nullable: false),
                        KilledClass16 = c.Int(nullable: false),
                        KilledClass17 = c.Int(nullable: false),
                        KilledClass18 = c.Int(nullable: false),
                        KilledClass19 = c.Int(nullable: false),
                        KilledClass20 = c.Int(nullable: false),
                        KilledByDecontamination = c.Int(nullable: false),
                        KilledByNuke = c.Int(nullable: false),
                        KilledByFalldown = c.Int(nullable: false),
                        KilledBySCP207 = c.Int(nullable: false),
                        KilledBySCP330 = c.Int(nullable: false),
                        KilledByDisruptor = c.Int(nullable: false),
                        KilledByJailbird = c.Int(nullable: false),
                        GeneratorActivated = c.Int(nullable: false),
                        DamageDoneToSCPS = c.Int(nullable: false),
                        DamageDone = c.Int(nullable: false),
                        Used914 = c.Int(nullable: false),
                        UsedIntercom = c.Int(nullable: false),
                        UsedMicrohid = c.Int(nullable: false),
                        Used268 = c.Int(nullable: false),
                        Used500 = c.Int(nullable: false),
                        UsedAdrenaline = c.Int(nullable: false),
                        UsedMedkits = c.Int(nullable: false),
                        UsedPainkillers = c.Int(nullable: false),
                        FiredBullets = c.Int(nullable: false),
                        MissedBullets = c.Int(nullable: false),
                        Headshots = c.Int(nullable: false),
                        CuffedPlayers = c.Int(nullable: false),
                        TimesCuffed = c.Int(nullable: false),
                        DamageTaken = c.Int(nullable: false),
                        SCP079Blackouts = c.Int(nullable: false),
                        SCP079ExpierienceCollected = c.Int(nullable: false),
                        PocketEscapes = c.Int(nullable: false),
                        SCP106Captured = c.Int(nullable: false),
                        SCP049Revived = c.Int(nullable: false),
                        SCP173NecksSnapped = c.Int(nullable: false),
                        ItemsPickedUp = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        DoorsOpened = c.Int(nullable: false),
                        RoundsPlayed = c.Int(nullable: false),
                        Used207 = c.Int(nullable: false),
                        Thrown018 = c.Int(nullable: false),
                        GrenadesThrown = c.Int(nullable: false),
                        FlashesThrown = c.Int(nullable: false),
                        SCP079Kills = c.Int(nullable: false),
                        SCP079Assists = c.Int(nullable: false),
                        Taken330 = c.Int(nullable: false),
                        Used330 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RankUnlocks", "RankId", "dbo.Ranks");
            DropForeignKey("dbo.RankPreferences", "RankId", "dbo.Ranks");
            DropForeignKey("dbo.Achievements", "Rank_Id", "dbo.Ranks");
            DropForeignKey("dbo.Ranks", "Rarity_Id", "dbo.Rarities");
            DropIndex("dbo.RankUnlocks", new[] { "RankId" });
            DropIndex("dbo.RankPreferences", new[] { "RankId" });
            DropIndex("dbo.Ranks", new[] { "Rarity_Id" });
            DropIndex("dbo.Achievements", new[] { "Rank_Id" });
            DropTable("dbo.Stats");
            DropTable("dbo.RankUnlocks");
            DropTable("dbo.RankPreferences");
            DropTable("dbo.Rarities");
            DropTable("dbo.Ranks");
            DropTable("dbo.Achievements");
        }
    }
}
