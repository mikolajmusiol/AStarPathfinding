namespace AStarPathfinding
{
    public static class Graphics
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
                    Console.Write(" " + grid.TileArray[i, j].Symbol + " |");
                }
                Console.Write("\n+");
                for (int j = 0; j < grid.Size; j++)
                {
                    Console.Write("---+");
                }
                Console.Write("\n");
            }
        }
    }
}