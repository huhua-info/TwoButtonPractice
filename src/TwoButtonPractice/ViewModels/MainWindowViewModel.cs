using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TwoButtonPractice.ViewModels;

public sealed class MainWindowViewModel : ObservableObject
{
    public const int MaximumCount = 999;
    private int count;
    private string statusMessage = "請按下按鈕開始";

    public MainWindowViewModel()
    {
        IncrementCommand = new RelayCommand(Increment, () => Count < MaximumCount);
        ResetCommand = new RelayCommand(Reset);
    }

    public int Count
    {
        get => count;
        private set
        {
            if (SetProperty(ref count, value))
                IncrementCommand.NotifyCanExecuteChanged();
        }
    }

    public string StatusMessage
    {
        get => statusMessage;
        private set => SetProperty(ref statusMessage, value);
    }

    public IRelayCommand IncrementCommand { get; }
    public IRelayCommand ResetCommand { get; }

    private void Increment()
    {
        // Guard direct command calls as well as disabled UI activation.
        if (Count >= MaximumCount)
            return;

        Count++;
        StatusMessage = Count == MaximumCount ? "已達上限 999 次" : "已增加 1 次";
    }

    private void Reset()
    {
        Count = 0;
        StatusMessage = "已重設為 0";
    }
}
