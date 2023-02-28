using CommandSystem;
using PluginAPI.Core;
using System;
using Xname.EVO.Database;
using System.Linq.Dynamic.Core;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Xname.EVO;

[CommandHandler(typeof(ClientCommandHandler))]
internal sealed class EvoCommand : ICommand
{
    public string Command => "evo";

    public string[] Aliases => Array.Empty<string>();

    public string Description => "Komendy do evo";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var player = Player.Get(sender);
        if (arguments.Count == 0)
        {
            response = Usage;
            return false;
        }

        switch (arguments.At(0))
        {
            case "refresh" or "r":
                AchievementHandler.RefreshRank(player);
                break;

            case "show":
                Show(player);
                break;

            case "set":
                {
                    if (arguments.Count > 1 && int.TryParse(arguments.At(1), out var value))
                        Set(player, value);
                    else
                    {
                        response = "Podano niepoprawną wartość! - [Rank Id]";
                        return false;
                    }
                }
                
                break;

            default:
                response = Usage;
                return false;
        }

        response = "Zrobione";
        return true;
    }

    private const string Usage = "\n.evo refresh (alias 'r')\n.evo show\n.evo set [Rank Id]";

    private static readonly EvoDbContext _context = new();

    private static void Show(Player player)
    {
        StringBuilder sb = new();
        var ranks = _context.RankUnlocks.Include(x => x.Rank).Where(x => x.UserId == player.UserId).OrderByDescending(x => x.Rank.Id).AsNoTracking().ToArray();

        if (ranks.Length > 0)
        {
            sb.AppendLine("Zdobyte rangi:");
            foreach (var rank in ranks)
                sb.AppendLine($"{rank.Rank.Id}. - {rank.Rank.Name}");
        }
        else
            sb.AppendLine("Jeszcze nie posiadasz żadnej rangi!");

        player.SendConsoleMessage(sb.ToString());
    }

    private static void Set(Player player, int id)
    {
        var rank = _context.RankUnlocks.Include(x => x.Rank).Where(x => x.UserId == player.UserId && x.Rank.Id == id).AsNoTracking().FirstOrDefault();
        if (rank is null)
        {
            player.SendConsoleMessage("Jeszcze nie posiadasz żadnej rangi!");
            return;
        }

        var preference = _context.RankPreferences.Where(x => x.UserId == player.UserId).FirstOrDefault();
        if (preference is null)
            _context.RankPreferences.Add(new() { UserId = player.UserId, RankId = rank.Rank.Id });
        else
            preference.RankId = rank.Rank.Id;

        _context.SaveChanges();
        AchievementHandler.RefreshRank(player);
        player.SendConsoleMessage($"Pomyślnie ustawiono rangę na: {rank.Rank.Name}");
    }
}
