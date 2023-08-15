namespace AStarPathfinding;

public class Algorithm
{
    public List<Tile> ShortestPath { get; private set; }
    private List<Tile> _open = new List<Tile>();
    private List<Tile> _closed = new List<Tile>();
    private Grid _grid;

    public Algorithm(Grid grid)
    {
        _grid = grid;
        ShortestPath = Pathfinding();
    }

    private List<Tile> Pathfinding()
    {
        _open.Add(_grid.StartTile);

        while (_open.Count > 0)
        {
            Tile current = _open[0];

            for (int i = 0; i < _open.Count; i++)
            {
                if (_open[i].FCost < current.FCost || _open[i].FCost == current.FCost && _open[i].HCost < current.HCost)
                {
                    current = _open[i];
                }
            }

            _open.Remove(current);
            _closed.Add(current);

            if (_grid.CheckIfTheSameCoords(current, _grid.EndTile))
            {
                return Backtrack(current);
            }

            foreach (Tile neighbour in _grid.GetNeighbours(current))
            {
                if (neighbour.TileType == Tile.TypeOfTile.Wall || _closed.Contains(neighbour))
                {
                    continue;
                }

                if ((current.GCost + _grid.GetDistance(current, neighbour)) < neighbour.GCost || _open.Contains(neighbour) == false)
                {
                    neighbour.GCost = current.GCost + _grid.GetDistance(current, neighbour);
                    neighbour.HCost = _grid.GetDistance(neighbour, _grid.EndTile);
                    neighbour.Previous = current;

                    if (_open.Contains(neighbour) == false)
                    {
                        _open.Add(neighbour);
                    }
                    else
                    {
                        _open[_open.IndexOf(neighbour)].GCost = current.GCost + _grid.GetDistance(current, neighbour);
                        _open[_open.IndexOf(neighbour)].HCost = _grid.GetDistance(neighbour, _grid.EndTile);
                        _open[_open.IndexOf(neighbour)].Previous = current;
                    }
                }

            }
        }

        return new List<Tile>();
    }

    private List<Tile> Backtrack(Tile end)
    {
        List<Tile> path = new List<Tile>();
        Tile current = end;

        while (current != _grid.StartTile && current != null)
        {
            path.Add(current);
            current = current.Previous;
        }

        path.RemoveAt(0);
        path.Reverse();

        return path;
    }
}