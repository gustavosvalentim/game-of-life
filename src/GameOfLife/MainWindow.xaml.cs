using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int CellSize = 18;

        private Board _board = new Board();
        private DispatcherTimer _dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();

            _board.Initialize();
            _board.Randomize(double.Parse(LiveDensity.Text));
        }

        public void myCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Render();
        }

        public void Window_SizeChanged(object sender, RoutedEventArgs e)
        {
            Render();
        }

        public void RenderButton_Render(object sender, RoutedEventArgs e)
        {
            _board.Advance();
            Render();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _board.Advance();
            Render();
        }

        public void StartButton_Start(object sender, RoutedEventArgs e)
        {
            if (_dispatcherTimer == null)
            {
                _dispatcherTimer = new DispatcherTimer();
                _dispatcherTimer.Tick += new EventHandler(Timer_Tick);
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000 / 30);
            }

            _dispatcherTimer.Start();
        }

        public void StopButton_Stop(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
        }

        public void ResetButton_Reset(object sender, RoutedEventArgs e)
        {
            if (_dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
            }

            _board.Randomize(double.Parse(LiveDensity.Text));
            Render();
        }

        public void LiveDensity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void Render()
        {
            using (var bmp = new Bitmap((int)myCanvas.ActualWidth, (int)myCanvas.ActualHeight))
            using (var gfx = Graphics.FromImage(bmp))
            using (var aliveBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
            using (var deadBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White))
            {
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gfx.Clear(System.Drawing.Color.Black);

                var cellSize = new System.Drawing.Size(CellSize, CellSize);

                for (int i = 0; i < Board.BoardWidth; i++)
                {
                    for (int j = 0; j < Board.BoardHeight; j++)
                    {
                        var cellLocation = new System.Drawing.Point(i * CellSize, j * CellSize);
                        var cellRect = new System.Drawing.Rectangle(cellLocation, cellSize);
                        var cell = _board.Cells[i, j];

                        if (cell.IsAlive)
                        {
                            gfx.FillRectangle(aliveBrush, cellRect);
                        } 
                        else
                        {
                            gfx.FillRectangle(deadBrush, cellRect);
                        }
                    }
                }

                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();

                    myImage.Source = bitmapImage;
                }
            }
        }
    }
}