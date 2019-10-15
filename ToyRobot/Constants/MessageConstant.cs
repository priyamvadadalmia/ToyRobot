﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Constants
{
    public static class MessageConstant
    {
        public const string OUT_OF_BOUNDS_MESSAGE = "Command ignored - out of bounds";
        public const string NOT_PLACED_YET_MESSAGE = "Command ignored - robot not placed yet";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Command ignored - robot did not understand this command";
        public const string VALID_COMMANDS_MESSAGE = "Error during command handling.\nValid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";
    }
}
