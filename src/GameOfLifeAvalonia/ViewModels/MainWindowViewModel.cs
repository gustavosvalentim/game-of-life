using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameOfLifeAvalonia.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private decimal _liveDensity = 0.3m;
        public decimal LiveDensity
        {
            get => _liveDensity;

            set
            {
                _liveDensity = value;
                OnPropertyChanged(nameof(LiveDensity));
            }
        }

        private int _fps = 30;
        public int Fps
        {
            get => _fps;

            set
            {
                _fps = value;
                OnPropertyChanged(nameof(Fps));
            }
        }

        private bool _isRenderLoopActive = false;
        public bool IsRenderLoopActive
        {
            get => _isRenderLoopActive;

            set
            {
                _isRenderLoopActive = value;
                OnPropertyChanged(nameof(IsRenderLoopActive));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
