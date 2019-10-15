
using Attribute.ConsoleOperation;
using Attribute.Toy;


namespace Interfaces
{
    public interface IInputParser
    {
        // Interface to process the raw input from the user.
        Command ParseCommand(string[] rawInput);

        // This extracts the parameters from the user's input.        
        ToyRobotPlacementAttribute   ParseCommandParameter(string[] input);
    }
}
