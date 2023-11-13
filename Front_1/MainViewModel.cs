using System.ComponentModel;

public class MainViewModel : INotifyPropertyChanged
{
    private string _inputText;

    public string InputText
    {
        get { return _inputText; }
        set
        {
            if (_inputText != value)
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}