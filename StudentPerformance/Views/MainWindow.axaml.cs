using Avalonia.Controls;
using StudentPerformance.ViewModels;

namespace StudentPerformance.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
