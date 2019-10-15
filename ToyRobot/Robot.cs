using System;

namespace Robot
{
    public class Robot
    {
        private TableTop _tableTop;

        private const int xLowerBoundary = 0;
        private const int yLowerBoundary = 0;

        private int xUpperBoundary = -1;
        private int yUpperBoundary = -1;
        private int xPosition = -1;
        private int yPosition = -1;
        private string direction = string.Empty;
        private bool isPlaced = false;

        /// <summary>
        /// /Constructor
        /// </summary>
        public Robot()
        {
            _tableTop = new TableTop();

        }
        public Robot(int tableSizeX, int tableSizeY)
        {
            _tableTop = new TableTop(tableSizeX, tableSizeY);

        }

        private bool validatePosition(int xPosition,int yPosition)
        {
            return _tableTop.IsOnTable(xPosition, yPosition);
        }

        private string PlaceRobot(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            xPosition = Int32.Parse(wordsInCommand[1]);
            yPosition = Int32.Parse(wordsInCommand[2]);
            direction = wordsInCommand[3];

            if (!validatePosition(xPosition,yPosition))
                result = Constants.MessageConstant.OUT_OF_BOUNDS_MESSAGE;
            else
                isPlaced = true;

            return result;
        }

        private string Report()
        {
            return xPosition + "," + yPosition + "," + direction;
        }

        private string Move()
        {
            string result = string.Empty;
            int originalX = this.xPosition;
            int originalY = this.yPosition;

            switch (direction)
            {
                case "NORTH":
                case "N":
                    yPosition++; break;
                case "WEST":
                case "W":
                    xPosition--; break;
                case "SOUTH":
                case "S":
                    yPosition--; break;
                case "EAST":
                case "E":
                    xPosition++; break;
            }

            if (!validatePosition(xPosition,yPosition))
            {
                xPosition = originalX;
                yPosition = originalY;
                result = Constants.MessageConstant.OUT_OF_BOUNDS_MESSAGE;
            }
            return result;
        }

        private void left()
        {
            switch (direction)
            {
                case "NORTH":
                case "N":
                    direction = "WEST"; break;
                case "WEST":
                case "W":
                    direction = "SOUTH"; break;
                case "SOUTH":
                case "S":
                    direction = "EAST"; break;
                case "EAST":
                case "E":
                    direction = "NORTH"; break;
            }
        }

        private void right()
        {
            switch (direction)
            {
                case "NORTH":
                case "N":
                    direction = "EAST"; break;
                case "E":
                case "EAST":
                    direction = "SOUTH"; break;
                case "S":
                case "SOUTH":
                    direction = "WEST"; break;
                case "W":
                case "WEST":
                    direction = "NORTH"; break;
            }
        }

        public string command(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;

            try
            {
                if (command.Contains("PLACE"))
                    result = PlaceRobot(command);

                else if (!isPlaced)
                    result =Constants.MessageConstant.NOT_PLACED_YET_MESSAGE;

                else if (command.Contains("REPORT"))
                    result = Report();

                else if (command.Contains("MOVE"))
                    result = Move();

                else if (command.Contains("LEFT"))
                    left();

                else if (command.Contains("RIGHT"))
                    right();

                else
                    result = Constants.MessageConstant.COMMAND_NOT_RECOGNISED_MESSAGE;
            }
            catch (Exception e)
            {
                result = Constants.MessageConstant.VALID_COMMANDS_MESSAGE;
            }

            return result;
        }

    }

}
