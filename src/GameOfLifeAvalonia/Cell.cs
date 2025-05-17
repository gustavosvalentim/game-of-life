using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeAvalonia
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public bool IsAliveNext { get; set; }
        public List<Cell> Neighbors { get; }

        public Cell()
        {
            IsAlive = false;
            IsAliveNext = false;
            Neighbors = new List<Cell>();
        }

        public void CalculateNextState()
        {
            var aliveNeighbors = Neighbors.Count(n => n.IsAlive);
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
