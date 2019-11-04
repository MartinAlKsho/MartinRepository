using System.Windows;
// My Name is Martin
namespace JoePets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            vm.Calc();
        }
    }
}
