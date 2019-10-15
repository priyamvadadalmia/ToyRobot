using Attribute.Toy;


namespace Attribute.ConsoleOperation
{
    // This is a class to store the attribute for the "PLACE" command.
    public class ToyRobotPlacementAttribute
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public ToyRobotPlacementAttribute(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
