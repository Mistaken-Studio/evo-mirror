using System.ComponentModel.DataAnnotations;

namespace Xname.EVO;

public sealed class Rarity
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Color { get; set; }
}