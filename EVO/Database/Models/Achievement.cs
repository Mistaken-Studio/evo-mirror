using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xname.EVO;
public sealed class Achievement
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Rank Rank { get; set; }
    
    public string Requirement { get; set; }
    
    public AchievementFlag Flags { get; set; }
    
    public bool InOneRound { get; set; }
    
    [NotMapped]
    internal Func<Stats, bool> RequirementFunc { get; set; }
}