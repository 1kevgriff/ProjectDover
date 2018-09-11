using System.ComponentModel;

namespace ProjectDover
{
    public enum Direction
    {
        [Description("North")]
        North,
        [Description("South")]
        South,
        [Description("East")]
        East,
        [Description("West")]
        West,
        [Description("Up")]
        Up,
        [Description("Down")]
        Down
    }
}