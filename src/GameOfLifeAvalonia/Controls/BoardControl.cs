using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace GameOfLifeAvalonia.Controls
{
    public class BoardControl : Control
    {
        private readonly Board _board;
        private readonly Size _tileSize = new Size(12, 12);

        public BoardControl()
        {
            _board = new Board();
            _board.Initialize();
        }

        public sealed override void Render(DrawingContext context)
        {
            var whiteBrush = new SolidColorBrush(Colors.White);
            var blackBrush = new SolidColorBrush(Colors.Black);

            for (var i = 0; i < Board.Columns; i++)
            {
                for (var j = 0; j < Board.Rows; j++)
                {
                    var point = new Point(i * _tileSize.Width, j * _tileSize.Height);
                    context.FillRectangle(_board.Cells[i, j].IsAlive ? blackBrush : whiteBrush, new Rect(point, _tileSize));
                }
            }

            base.Render(context);
        }

        public void Randomize(double liveDensity) => _board.Randomize(liveDensity);

        public void Advance() => _board.Advance();
    }
}
