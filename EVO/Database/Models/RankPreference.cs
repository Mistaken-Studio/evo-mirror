using System.ComponentModel.DataAnnotations;

namespace Xname.EVO;

public sealed class RankPreference
{
    [Key]
    public string UserId { get; set; }

    public int RankId { get; set; }
    
    public Rank Rank { get; set; }
}