using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OwLetter.Service
{
    public class CurrentObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nameObject = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameObject));
        }
    }
}
