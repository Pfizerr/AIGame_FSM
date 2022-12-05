using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIGame
{
    public class InfluenceMap
    {
        private int[,] map;

        private Point cellSize;
        private Point location;
        

        public InfluenceMap(int resolution, Point location, Point cellSize)
        {
            map = new int[resolution, resolution];
            this.cellSize = cellSize;
        }

        public void ModifyCell(int x, int y, int diff)
        {
            map[x, y] = diff;
        }

        public bool ContainsPoint(int ix, int iy)
        {
            Point cellWorldLocation = new Point(location.X + (cellSize.X * ix), location.Y + (cellSize.X * ix));
            return (cellWorldLocation.X >= ix && cellWorldLocation.X + cellSize.X <= ix)
                && (cellWorldLocation.Y >= iy && cellWorldLocation.X + cellSize.Y <= iy);
            
        }
    }
}
