using System.ComponentModel;
using System.Linq;

namespace ProjectDover
{
    public class Exit
    {
        public Direction Direction { get; set; }
        public long TargetRoomId { get; set; }

        public static string GetDirection(Direction value)
        {
            var firstOrDefault = value
                .GetType()
                .GetMember(value.ToString())
                .First();

            var attributes = firstOrDefault.GetCustomAttributes(false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}