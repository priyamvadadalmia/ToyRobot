using Interfaces;
using System;
using ToyRobotApp.ConsoleOperation;
using ToyRobotApp.Action;
using ToyRobotApp.Toy;

namespace ToyRobotApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string description = ToyRobotApp.Constants.Messages.MENU;

            IToyBoard toyBoard = new ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyAction(robot, toyBoard, inputParser);

            var stopApplication = false;
            Console.WriteLine(description);
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.ToUpper().Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
