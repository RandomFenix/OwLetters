using Autofac;
using OwLetter.Commands;
using OwLetter.Helpers;
using OwLetter.MVVM.Models;
using OwLetter.Service;
using OwLetter.Service.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace OwLetter.MVVM.ViewModel
{
    public class InputViewModel : BaseViewModel
    {
        public InputCommand InputCommand { get; set; }
        public Dictionary<string, string> jsonDictionary = new Dictionary<string, string>();
        string _englishMessage;
        string _russianMessage;
        string _message;
        public string MessageTextEnglish { get => _englishMessage; set => Set(ref _englishMessage, value); }
        public string MessageTextRussian { get => _russianMessage; set => Set(ref _russianMessage, value); }
        public string MessageText { get => _message; set => Set(ref _message, value); }


        public InputViewModel()
        {
            InputCommand = new InputCommand(OnExecute);
        }
        public void OnExecute()
        {
            var result = MessageBox.Show($"Слово {MessageTextEnglish} добавлено в словарь","", MessageBoxButton.OK);
            if(result == MessageBoxResult.OK)
            {
                #region
                var container = AutofacContainer.Create();
                var jsonManager = container.Resolve<JsonManager>();
                #endregion
                var jsonFile = jsonManager.Load();
                jsonFile.Add(MessageTextEnglish, MessageTextRussian);
                jsonManager.Save(jsonFile);
            }
        }
    }
}
