using System;

namespace Xname.EVO;

[Flags]
public enum AchievementFlag
{
    DISABLED = 0,
    ACTIVE = 1,
    ONLY_TITLE = 2,
    SECRET = 4,
}