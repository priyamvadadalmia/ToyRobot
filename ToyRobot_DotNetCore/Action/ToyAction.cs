using Attribute.Toy;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotApp.Action
{
    /// <summary>
    /// This class is used to simulate the Action of the toy.
    /// It calls the interfaces from other classes to make a Action object.
    /// Methods for this object include processing the string and
    /// rendering the report.
    /// </summary>
    public class ToyAction
    {
        public IToyRobot ToyRobot { get; private set; }
        public IToyBoard ToyBoard { get; private set; }
        public IInputParser InputParser { get; private set; }

        public ToyAction(IToyRobot toyRobot, IToyBoard toyBoard, IInputParser inputParser)
        {
            ToyRobot = toyRobot;
            ToyBoard = toyBoard;
            InputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {
            var command = InputParser.ParseCommand(input);
            if (command != Command.Place && ToyRobot.Position == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = InputParser.ParseCommandParameter(input);
                    if (ToyBoard.IsValidPosition(placeCommandParameter.Position))
                        ToyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    var newPosition = ToyRobot.GetNextPosition();
                    if (ToyBoard.IsValidPosition(newPosition))
                        ToyRobot.Position = newPosition;
                    break;
                case Command.Left:
                    ToyRobot.RotateLeft();
                    break;
                case Command.Right:
                    ToyRobot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", ToyRobot.Position.X,
                ToyRobot.Position.Y, ToyRobot.Direction.ToString().ToUpper());
        }
    }
}
