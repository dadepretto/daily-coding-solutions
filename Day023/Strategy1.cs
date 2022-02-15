namespace Day023;

public class Strategy1 : IStrategy
{
    public int? Execute(bool[,] board, (int x, int y) start,
        (int x, int y) target)
    {
        return ExecuteStep(new Board(board), new Coordinate(start),
            new Coordinate(target));
    }

    private int? ExecuteStep(Board board, Coordinate current, Coordinate target)
    {
        if (!board.IsVisitable(target)) return null;
        if (!board.IsVisitable(current)) return null;

        if (target == current) return 0;

        var boardWithVisitedFlag = board.Visit(current);

        var paths = new[]
        {
            1 + ExecuteStep(boardWithVisitedFlag, current.Up, target),
            1 + ExecuteStep(boardWithVisitedFlag, current.Down, target),
            1 + ExecuteStep(boardWithVisitedFlag, current.Left, target),
            1 + ExecuteStep(boardWithVisitedFlag, current.Right, target)
        };

        return paths.Min();
    }

    private record Coordinate(int X, int Y)
    {
        // ReSharper disable once UseDeconstructionOnParameter
        public Coordinate((int x, int y) tuple) : this(tuple.x, tuple.y)
        {
        }

        public Coordinate Up => this with {X = X - 1};

        public Coordinate Down => this with {X = X + 1};

        public Coordinate Left => this with {Y = Y - 1};

        public Coordinate Right => this with {Y = Y + 1};
    }

    private record Tile(bool IsWall, bool IsVisited = false)
    {
        public Tile(Tile tile)
        {
            var (isWall, isVisited) = tile;
            IsWall = isWall;
            IsVisited = isVisited;
        }

        public bool IsVisitable => !IsWall && !IsVisited;

        public Tile Visit()
        {
            return this with {IsVisited = true};
        }
    }

    private class Board
    {
        private readonly Tile[,] _tiles;

        public Board(bool[,] wallsMap)
        {
            _tiles = wallsMap.Select(isWall => new Tile(isWall));
        }

        private Board(Tile[,] tiles)
        {
            _tiles = tiles.Select(tile => new Tile(tile));
        }

        public bool IsVisitable(Coordinate coordinate)
        {
            var (x, y) = coordinate;
            return x >= 0 && x < _tiles.GetLength(0)
                && y >= 0 && y < _tiles.GetLength(1)
                && _tiles[x, y].IsVisitable;
        }

        public Board Visit(Coordinate coordinate)
        {
            var (x, y) = coordinate;
            var boardWithUpdates = new Board(_tiles)
            {
                _tiles =
                {
                    [x, y] = _tiles[x, y].Visit()
                }
            };
            return boardWithUpdates;
        }
    }
}