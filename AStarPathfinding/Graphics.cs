using static AStarPathfinding.Tile;

namespace AStarPathfinding
{
    public class Graphics : IGraphics
    {
        private Grid _grid;

        public Graphics(Grid grid)
        {
            _grid = grid;
        }

        public void DrawGrid()
        {
            Console.Clear();
            Console.Write("+");
            for (int i = 0; i < _grid.Size; i++)
            {
                Console.Write("---+");
            }
            Console.Write("\n");
            for (int i = 0; i < _grid.Size; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _grid.Size; j++)
                {
                    Console.Write(" " + GetTileType(_grid.TileArray[i, j].TileType) + " |");
                }
                Console.Write("\n+");
                for (int j = 0; j < _grid.Size; j++)
                {
                    Console.Write("---+");
                }
                Console.Write("\n");
            }
        }
        public void VisualizePath(List<Tile> path)
        {
            if(path.Count < 1)
            {
                Console.WriteLine("\nShortest path could not be found");
                return;
            }

            Console.Clear();
            foreach (Tile tile in path)
            {
                tile.TileType = TypeOfTile.Path;
                _grid.TileArray[tile.X, tile.Y] = tile;
                DrawGrid();
                Thread.Sleep(200);
            }
            Console.WriteLine("\nShortest path was found");
        }

        private char GetTileType(TypeOfTile type)
        {
            switch (type)
            {
                case TypeOfTile.Wall:
                    return '?';
                case TypeOfTile.Start:
                    return 'O';
                case TypeOfTile.End:
                    return 'X';
                case TypeOfTile.Path:
                    return '@';
                default:
                    return ' ';
            }
        }
    }
}