using System.Net.Http.Headers;

namespace GameOfLife
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public bool IsAliveNext { get; set; }
        public List<Cell> Neighbors { get; set; }

        public Cell()
        {
            IsAlive = false;
            IsAliveNext = false;
            Neighbors = new List<Cell>();
        }

        public void CalculateNextState()
        {
            var aliveNeighbors = Neighbors.Where(n => n.IsAlive).Count();
            IsAliveNext = false;
            if ((IsAlive && (aliveNeighbors >= 2 && aliveNeighbors <= 3)) || 
                (!IsAlive && aliveNeighbors == 3))
            {
                IsAliveNext = true;
            }
        }

        public void Advance()
        {
            IsAlive = IsAliveNext;
        }
    }
}
