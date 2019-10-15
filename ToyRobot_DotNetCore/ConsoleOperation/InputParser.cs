using Attribute.ConsoleOperation;
using Attribute.Toy;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotApp.ConsoleOperation
{
    public class InputParser : IInputParser
    {
        // this method takes a string array and compares the first element to the list of commands
        // if the command doesn't exist then an error is thrown, otherwise the command is returned
        public Command ParseCommand(string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException(ToyRobotApp.Constants.Messages.INVALID_COMMAND);
            return command;
        }

        // Extracts the parameters from the user input and returns it       
        public ToyRobotPlacementAttribute ParseCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new InitializeToyRobotPosition();
            return thisPlaceCommandParameter.InitializeToyRobot(input);
        }
    }

}
