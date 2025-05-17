using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using GameOfLifeAvalonia.Controls;
using GameOfLifeAvalonia.ViewModels;
using System;

namespace GameOfLifeAvalonia
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            _dispatcherTimer = new DispatcherTimer();

            var boardControl = GetBoardControl();

            if (boardControl != null && DataContext is MainWindowViewModel vm)
            {
                boardControl.Randomize(decimal.ToDouble(vm.LiveDensity));
            }
        }

        public void HandleClickRender(object sender, RoutedEventArgs e)
        {
            PlayRenderLoop(sender, e);
        }

        public void HandleClickReset(object sender, RoutedEventArgs e)
        {
            var boardControl = GetBoardControl();

            if (boardControl != null && DataContext is MainWindowViewModel vm)
            {
                vm.IsRenderLoopActive = false;
                
                boardControl.Randomize(decimal.ToDouble(vm.LiveDensity));
                boardControl.InvalidateVisual();
            }

            _dispatcherTimer.Stop();
        }

        public void HandleToggleRenderLoop(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                if (vm.IsRenderLoopActive)
                {
                    HandlePlayRenderLoop(sender, e);
                }
                else
                {
                    HandleStopRenderLoop(sender, e);
                }
            }
        }

        private void HandlePlayRenderLoop(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Tick += new EventHandler(PlayRenderLoop);

            if (DataContext is MainWindowViewModel vm)
            {
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000 / vm.Fps);
            }

            _dispatcherTimer.Start();
        }

        private void HandleStopRenderLoop(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
        }

        private void PlayRenderLoop(object? sender, EventArgs e)
        {
            var boardControl = GetBoardControl();

            if (boardControl != null)
            {
                boardControl.Advance();
                boardControl.InvalidateVisual();
            }
        }

        private BoardControl? GetBoardControl() => this.FindControl<BoardControl>("Board");
    }
}