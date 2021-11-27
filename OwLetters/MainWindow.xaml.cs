using Autofac;
using OwLetter.Helpers;
using OwLetter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OwLetters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            PageA.Items.Clear();
            var container = AutofacContainer.Create();
            var jsonManager = container.Resolve<JsonManager>();
            var json = jsonManager.Load();
            var raddioButton = sender as RadioButton;
            if (raddioButton == null) return;
            char charIndex = Char.Parse(raddioButton.Content.ToString());
            foreach (var item in json)
            {
                if (item.Key.StartsWith(charIndex)) PageA.Items.Add(string.Join(" - ", item.Key, item.Value));
            }
        }
    }
}
