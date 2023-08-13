namespace AStarPathfinding
{
    public class Grid
    {
        public Tile[,] TileArray { get; private set; }
        public int Size { get; private set; }
        public Tile StartTile { get; private set; }
        public Tile EndTile { get; private set; }

        private float _wallProbability;

        public Grid(int size, float wallProbability)
        {
            Size = size;
            _wallProbability = wallProbability;
            TileArray = new Tile[Size, Size];

            StartTile = new Tile(0, 0) { TileType = Tile.TypeOfTile.Start };
            EndTile = new Tile(Size - 1, Size - 1) { TileType = Tile.TypeOfTile.End };
        }

        public void SetStartAndEnd(Tile start, Tile end)
        {
            if (CheckIfTheSame(start, end))
                return;

            start.TileType = Tile.TypeOfTile.Start;
            StartTile = start;
            end.TileType = Tile.TypeOfTile.End;
            EndTile = end;
        }

        public void GenerateGrid()
        {
            Random random = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Tile tile = new Tile(i, j);

                    if (CheckIfTheSame(tile, StartTile))
                    {
                        tile.TileType = Tile.TypeOfTile.Start;
                    }
                    else if(CheckIfTheSame(tile, EndTile))
                    {
                        tile.TileType = Tile.TypeOfTile.End;
                    }
                    else
                    {
                        if (random.Next(1, 101) < _wallProbability)
                        {
                            tile.TileType = Tile.TypeOfTile.Wall;
                        }

                        tile.GCost = GetDistance(StartTile, tile);
                        tile.HCost = GetDistance(tile, EndTile);
                    }

                    TileArray[i, j] = tile;
                }
            }
        }

        public List<Tile> GetNeighbours(Tile tile)
        {
            List<Tile> neighbours = new List<Tile>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int neighbourX = tile.X + i;
                    int neighbourY = tile.Y + j;

                    if (neighbourX >= 0 && neighbourX < Size && neighbourY >= 0 && neighbourY < Size)
                    {
                        neighbours.Add(TileArray[neighbourX, neighbourY]);
                    }
                }
            }
            return neighbours;
        }

        public int GetDistance(Tile origin, Tile target)
        {
            int XAxisDist = Math.Abs(origin.X - target.X);
            int YAxisDist = Math.Abs(origin.Y - target.Y);

            if (XAxisDist > YAxisDist)
            {
                return 14 * YAxisDist + 10 * (XAxisDist - YAxisDist);
            }
            else
            {
                return 14 * XAxisDist + 10 * (YAxisDist - XAxisDist);
            }
        }

        private bool CheckIfTheSame(Tile tileA, Tile tileB)
        {
            if(tileA.X == tileB.X && tileA.Y == tileB.Y)
            {
                return true;
            }
            return false;
        }
    }
}