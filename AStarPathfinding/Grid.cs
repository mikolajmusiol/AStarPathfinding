namespace AStarPathfinding
{
    public class Grid
    {
        public Tile[,] TileArray { get; private set; }
        public int Size { get; private set; }
        public float WallProbability { get; private set; }

        public Grid(int size, float wallProbability)
        {
            Size = size;
            WallProbability = wallProbability;

            TileArray = GenerateGrid();
            SetStartOrEnd();
        }

        public Grid(int size, float wallProbability, Tile start, Tile end)
            :this(size, wallProbability)
        {
            SetStartOrEnd(start, end);
        }

        private Tile[,] GenerateGrid()
        {
            Tile[,] ArrayOfTiles = new Tile[Size, Size];
            Random random = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Tile tile = new Tile(i,j);

                    if (random.Next(1, 11) < WallProbability)
                    {
                        tile.TileType = Tile.TypeOfTile.Wall;
                    }

                    ArrayOfTiles[i, j] = tile;
                }
            }
            
            return ArrayOfTiles;
        }

        private void SetStartOrEnd()
        {
            TileArray[0, 0].TileType = Tile.TypeOfTile.Start;
            TileArray[Size - 1, Size - 1].TileType = Tile.TypeOfTile.End;
        }

        private void SetStartOrEnd(Tile start, Tile end)
        {
            TileArray[0, 0].TileType = Tile.TypeOfTile.Empty;
            TileArray[Size - 1, Size - 1].TileType = Tile.TypeOfTile.Empty;

            TileArray[start.X, start.Y].TileType = Tile.TypeOfTile.Start;
            TileArray[end.X, end.Y].TileType = Tile.TypeOfTile.End;
        }
    }
}