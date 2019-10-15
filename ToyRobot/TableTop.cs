using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class TableTop
    {
        private const int xLowerBoundary = 0;
        private const int yLowerBoundary = 0;

        private int xUpperBoundary = -1;
        private int yUpperBoundary = -1;

       // private int valueX, valueY;
        
        public TableTop()
        {
            //default table size 5
            this.xUpperBoundary = this.yUpperBoundary = 5;
        }
        public TableTop(int dimensionX, int dimensionY)
        {
            this.xUpperBoundary = dimensionX;
            this.yUpperBoundary = dimensionY;
        }
        public TableTop GetTableBoundary()
        {
            return  new TableTop(this.xUpperBoundary - 1,this.yUpperBoundary - 1);

        }
        public bool IsOnTable(int xPosition,int yPosition)
        {
            if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                return false;
            else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                return false;
            else
                return true;

        }

    }
}
