namespace AStarPathfinding
{
    public class Grid
    {
        public Tile[,] TileArray { get; set; }
        public int Size { get; set; }
        public Tile StartTile { get; set; }
        public Tile EndTile { get; set; }

        public Grid(int size)
        {
            Size = size;
            TileArray = new Tile[Size,Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TileArray[i, j] = new Tile(i,j);
                }
            }

            StartTile = new Tile(0,0);
            StartTile.Symbol = 'O';
            EndTile = new Tile(size - 1, size - 1);
            EndTile.Symbol = 'X';

            TileArray[StartTile.X, StartTile.Y] = StartTile;
            TileArray[EndTile.X, EndTile.Y] = EndTile;
        }
    }
}