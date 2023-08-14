namespace AStarPathfinding
{
    public interface IGraphics
    {
        void DrawGrid();
        void VisualizePath(List<Tile> path);
    }
}