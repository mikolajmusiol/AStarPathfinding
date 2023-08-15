namespace AStarPathfinding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10, 40);
            grid.GenerateGrid();

            IGraphics graphics = new Graphics(grid);
            graphics.DrawGrid();

            Algorithm algorithm = new Algorithm(grid);
            graphics.VisualizePath(algorithm.ShortestPath);
        }
    }
}