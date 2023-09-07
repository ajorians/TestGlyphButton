using System.ComponentModel;
using System.Windows.Input;

namespace TestGlyphButton
{
   public class VM : INotifyPropertyChanged
   {
      public VM()
      {
      }

      private ICommand _clearTextCommand;
      public ICommand ClearTextCommand => _clearTextCommand ?? ( _clearTextCommand = new RelayCommand( () => ClearText() ) );

      private void ClearText()
      {
         SomeText = string.Empty;
      }

      private string _someText = "ABC123";
      public string SomeText
      {
         get => _someText;
         set
         {
            if( _someText != value)
            {
               _someText = value;
               PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( SomeText ) ) );
            }
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;
   }
}