namespace AStarPathfinding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10, 45);
            grid.GenerateGrid();
            Graphics.DrawGrid(grid);
        }
    }
}