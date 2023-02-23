namespace Xname.EVO;

internal sealed class Config
{
    public bool Debug { get; set; } = false;

    public DbConfig Database { get; set; } = new DbConfig();
}