using YamlDotNet.Serialization;

namespace Xname.EVO;

internal sealed class DbConfig
{
    public string Host { get; set; } = "127.0.0.1";
    
    public int Port { get; set; } = 3306;
    
    public string Database { get; set; } = "evo";

    public string Username { get; set; } = "evo";
    
    public string Password { get; set; } = "evo";
    
    [YamlIgnore]
    public string ConnectionString => $"Server={Host};Port={Port};Database={Database};Uid={Username};Pwd={Password};Allow User Variables=True";
}