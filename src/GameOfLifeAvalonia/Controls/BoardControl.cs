using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using GameOfLife;

namespace GameOfLifeAvalonia.Controls
{
    public class BoardControl : Control
    {
        private Board _board;
        private Size TileSize = new Size(12, 12);

        public BoardControl()
        {
            _board = new Board();
            _board.Initialize();
        }

        public sealed override void Render(DrawingContext context)
        {
            var whiteBrush = new SolidColorBrush(Colors.White);
            var blackBrush = new SolidColorBrush(Colors.Black);

            for (int i = 0; i < Board.Columns; i++)
            {
                for (int j = 0; j < Board.Rows; j++)
                {
                    var point = new Point(i * TileSize.Width, j * TileSize.Height);
                    context.FillRectangle(_board.Cells[i, j].IsAlive ? blackBrush : whiteBrush, new Rect(point, TileSize));
                }
            }

            base.Render(context);
        }

        public void Randomize(double liveDensity) => _board.Randomize(liveDensity);

        public void Advance() => _board.Advance();
    }
}
