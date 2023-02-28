using System;

namespace Xname.EVO;

public sealed class RankUnlock
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    
    public Rank Rank { get; set; }
    
    public DateTime TimeUnlocked { get; set; }
}