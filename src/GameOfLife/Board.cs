namespace GameOfLife
{
    public class Board
    {
        private Random _random = new Random();
        public const int BoardWidth = 48;
        public const int BoardHeight = 48;

        public Cell[,] Cells { get; set; }

        public Board()
        {
            Cells = new Cell[BoardWidth, BoardHeight];
        }

        public void Initialize()
        {
            for (var i = 0; i < BoardWidth; i++)
            {
                for (var j = 0; j < BoardHeight; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

            ConnectNeighbors();
        }

        private void ConnectNeighbors()
        {
            for (var i = 0; i < BoardWidth; i++)
            {
                for (var j = 0; j < BoardHeight; j++)
                {
                    var isLeftBorder = i == 0;
                    var isRightBorder = i == BoardWidth - 1;
                    var isUpperBorder = j == 0;
                    var isBottomBorder = j == BoardHeight - 1;
                    var isEdge = isLeftBorder | isRightBorder | isUpperBorder | isBottomBorder;

                    if (isEdge)
                    {
                        continue;
                    }

                    int neighborLeft = isLeftBorder ? BoardWidth - 1 : i - 1;
                    int neighborRight = isRightBorder ? 0 : i + 1;
                    int neighborTop = isUpperBorder ? BoardHeight - 1 : j - 1;
                    int neighborBottom = isBottomBorder ? 0 : j + 1;

                    Cells[i, j].Neighbors.Add(Cells[neighborLeft, neighborTop]);
                    Cells[i, j].Neighbors.Add(Cells[i, neighborTop]);
                    Cells[i, j].Neighbors.Add(Cells[neighborRight, neighborTop]);
                    Cells[i, j].Neighbors.Add(Cells[neighborLeft, j]);
                    Cells[i, j].Neighbors.Add(Cells[neighborRight, j]);
                    Cells[i, j].Neighbors.Add(Cells[neighborLeft, neighborBottom]);
                    Cells[i, j].Neighbors.Add(Cells[i, neighborBottom]);
                    Cells[i, j].Neighbors.Add(Cells[neighborRight, neighborBottom]);
                }
            }
        }

        public void Randomize(double liveDensity)
        {
            foreach (var cell in Cells)
            {
                cell.IsAlive = _random.NextDouble() < liveDensity;
            }
        }

        public void Advance()
        {
            foreach (var cell in Cells)
            {
                cell.CalculateNextState();
            }
            foreach (var cell in Cells)
            {
                cell.Advance();
            }
        }
    }
}
