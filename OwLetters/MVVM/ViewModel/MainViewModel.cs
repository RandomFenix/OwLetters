using Autofac;
using OwLetter.Commands;
using OwLetter.Helpers;
using OwLetter.MVVM.View;
using OwLetter.Service;
using OwLetters;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace OwLetter.MVVM.ViewModel
{
    public class MainViewModel : CurrentObject
    {
        private Window window = Application.Current.MainWindow;
        public string MessageTextEnglish { get; set; }
        public string MessageTextRussian { get; set; }
        //public ShiftCommand ShiftCommand { get; set; }
        public InputCommand InputCommand { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public Collection<char> RadioButtons { get; set; }

        public MainViewModel()
        {
            //ShiftCommand = new ShiftCommand(OnPaged);
            InputCommand = new InputCommand(OnExecute);
            SearchCommand = new SearchCommand(OnSearch);
            RadioButtons = new Collection<char> {'A','B','C','D','E','F','G','H','I','J','K',
                                                        'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                                        'U', 'V', 'W', 'X', 'Y', 'Z'};
        }
        public void OnExecute()
        {
            var container = AutofacContainer.Create();
            if (string.IsNullOrEmpty(MessageTextEnglish) || string.IsNullOrEmpty(MessageTextRussian)) MessageBox.Show("Заполните поле");
            else
            {
                var result = MessageBox.Show($"Слово {MessageTextEnglish} добавлено в словарь", "", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    var jsonManager = container.Resolve<JsonManager>();
                    var jsonFile = jsonManager.Load();
                    jsonFile.Add(MessageTextEnglish, MessageTextRussian);
                    jsonManager.Save(jsonFile);
                }
            }
        }
        public void OnSearch()
        {
            var container = AutofacContainer.Create();
            var jsonManager = container.Resolve<JsonManager>();
            var json = jsonManager.Load();
            if (string.IsNullOrEmpty((window as MainWindow).SearchWord.Text)) MessageBox.Show("Введите слово для поиска");
            else
            {
                SearchWindow searchWindow = new SearchWindow();
                string searchWord = (window as MainWindow).SearchWord.Text;
                if (!json.ContainsKey(searchWord) && !json.ContainsValue(searchWord)) MessageBox.Show("Слово не найдено. Проверьте правильность написания");
                else
                {
                    if (Regex.IsMatch(searchWord, @"\p{IsCyrillic}"))
                    {
                        searchWindow.ThisWord.Text = string.Join(" - ", json.First(x => x.Value == searchWord).Key, searchWord);
                        searchWindow.Show();
                    }
                    else
                    {
                        searchWindow.ThisWord.Text = string.Join(" - ", searchWord, json.First(x => x.Key == searchWord).Value);
                        searchWindow.Show();
                    }
                }
            }
        }

        //public void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    (window as MainWindow).PageA.Items.Clear();
        //    #region
        //    var container = AutofacContainer.Create();
        //    var jsonManager = container.Resolve<JsonManager>();
        //    #endregion
        //    var json = jsonManager.Load();
        //    var raddioButton = sender as RadioButton;
        //    if (raddioButton == null) return;
        //    char charIndex = Char.Parse(raddioButton.Content.ToString());
        //    foreach (var item in json)
        //    {
        //        if (item.Key.StartsWith(charIndex)) (window as MainWindow).PageA.Items.Add(string.Join(" - ", item.Key, item.Value));
        //    }
        //}
        //public void OnPaged()
        //{
        //    var pageView = (window as MainWindow).PageA;
        //    (window as MainWindow).PageA.Items.Clear();
        //    #region
        //    var container = AutofacContainer.Create();
        //    var jsonManager = container.Resolve<JsonManager>();
        //    #endregion
        //    var json = jsonManager.Load();
        //    var raddioButton = (window as MainWindow).Letters.Items.CurrentItem as RadioButton;
        //    if (raddioButton == null) return;
        //    char charIndex = Char.Parse(raddioButton.Content.ToString());
        //    foreach (var item in json)
        //    {
        //        if (item.Key.StartsWith(charIndex)) (window as MainWindow).PageA.Items.Add(string.Join(" - ", item.Key, item.Value));
        //    }
        //}
    }
}
