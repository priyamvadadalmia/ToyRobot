using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotApp.Constants
{
   public static class Messages
    {
       public static string MENU =  @"  **********        TOY ROBOT      ******************
  **************************************

     Welcome!

  1: Place the toy on a 5 x 5 grid
     using the following command:

     PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST)

  2: When the toy is placed, have at go at using
     the following commands.
                
     REPORT – Shows the current status of the toy. 
     LEFT   – turns the toy 90 degrees left.
     RIGHT  – turns the toy 90 degrees right.
     MOVE   – Moves the toy 1 unit in the facing direction.
     EXIT   – Closes the toy Simulator.
";

        public static string INVALID_COMMAND = "Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT";

    }
}
