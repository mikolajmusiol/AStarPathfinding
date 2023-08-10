using System.Drawing;

namespace AStarPathfinding
{
    public class Tile
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Wall { get; set; }
        public int FCost { get; set; }
        public int GCost { get; set; }
        public int HCost { get; set; }
        public List<Tile> Neighbours { get; set; } 
        public Tile? Previous { get; set; }
        public char Symbol { get; set; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            Wall = false;
            Neighbours = new List<Tile>();
            Previous = null;
            Symbol = ' ';
        }
    }
}