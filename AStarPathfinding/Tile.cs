namespace AStarPathfinding
{
    public class Tile 
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int FCost { get { return GCost + HCost; } }
        public int GCost { get; set; }
        public int HCost { get; set; }
        public Tile? Previous { get; set; }
        public TypeOfTile TileType { get; set; }

        public enum TypeOfTile
        {
            Empty,
            Wall,
            Start,
            End,
            Path
        }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            Previous = null;
            TileType = TypeOfTile.Empty;
        }
    }
}