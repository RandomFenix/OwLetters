using System.Windows;

namespace OwLetter.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для MockWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
