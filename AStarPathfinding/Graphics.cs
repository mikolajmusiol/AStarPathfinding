using static AStarPathfinding.Tile;

namespace AStarPathfinding
{
    public class Graphics
    {
        public static void DrawGrid(Grid grid)
        {
            Console.Clear();
            Console.Write("+");
            for (int i = 0; i < grid.Size; i++)
            {
                Console.Write("---+");
            }
            Console.Write("\n");
            for (int i = 0; i < grid.Size; i++)
            {
                Console.Write("|");
                for (int j = 0; j < grid.Size; j++)
                {
                    Console.Write(" " + GetSymbol(grid.TileArray[i, j].TileType) + " |");
                }
                Console.Write("\n+");
                for (int j = 0; j < grid.Size; j++)
                {
                    Console.Write("---+");
                }
                Console.Write("\n");
            }
        }

        private static char GetSymbol(TypeOfTile type)
        {
            switch(type)
            {       
                case TypeOfTile.Wall:
                    return '?';
                case TypeOfTile.Start:
                    return 'O';
                case TypeOfTile.End:
                    return 'X';
                default:
                    return ' ';
            }
        }
    }
}