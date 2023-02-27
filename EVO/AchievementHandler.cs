using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using PluginAPI.Core;
//using System.Linq.Dynamic.Core;
using Xname.EVO.Database;

namespace Xname.EVO;

public class AchievementHandler
{
    internal static void UpdateAchievements()
    {
        _achievements.Clear();
        using var db = new EvoDbContext();
        foreach (Achievement achievement in db.Achievements.Include(x=>x.Rank).AsNoTracking())
        {
            try
            {
                achievement.RequirementFunc = achievement.Requirement != null ? DynamicExpressionParser.ParseLambda<Stats, bool>(_config, false, achievement.Requirement).Compile() : _ => true;
                _achievements.Add(achievement);
            }
            catch (Exception e)
            {
                Log.Error($"Failed to parse requirement for achievement {achievement.Name} ({achievement.Id})");
                Log.Error(achievement.Requirement);
                Log.Error(e.Message);
            }
        }
        Log.Info($"Successfully loaded {_achievements.Count} achievements");
    }

    internal static async Task SaveStatsAndUnlock(Stats stats)
    {
        using var db = new EvoDbContext();
        var ranks = db.RankUnlocks.Where(x=>x.UserId == stats.UserId).Select(x=>x.Rank).AsNoTracking().ToList();
        var statsDb = db.Stats.FirstOrDefault(x=>x.UserId == stats.UserId);
        if (statsDb == null)
        {
            statsDb = stats;
            db.Stats.Add(statsDb);
        }
        else
        {
            statsDb.AddStats(stats);
        }
        foreach (Achievement achievement in _achievements.Where(x=> !ranks.Contains(x.Rank)))
        {
            if (achievement.RequirementFunc.Invoke(achievement.InOneRound ? stats : statsDb))
            {
                db.RankUnlocks.Add(new RankUnlock()
                {
                    UserId = stats.UserId,
                    Rank = achievement.Rank,
                    TimeUnlocked = DateTime.Now
                });
            }
        }
        await db.SaveChangesAsync();
    }
    
    internal static Rank GetUserRank(string userId)
    {
        using var db = new EvoDbContext();
        return db.RankUnlocks.Include(x=>x.Rank).Where(x=>x.UserId == userId).OrderByDescending(x=>x.Rank.Id).Select(x=>x.Rank).Include(x=>x.Rarity).AsNoTracking().FirstOrDefault();
    }
    
    private static readonly List<Achievement> _achievements = new();
    private static readonly ParsingConfig _config = new();
}