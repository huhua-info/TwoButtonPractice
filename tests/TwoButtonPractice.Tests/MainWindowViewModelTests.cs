using TwoButtonPractice.ViewModels;
using Xunit;

namespace TwoButtonPractice.Tests;

public class MainWindowViewModelTests
{
    [Fact]
    public void InitialStateIsReady()
    {
        var vm = new MainWindowViewModel();
        Assert.Equal(0, vm.Count);
        Assert.Equal("請按下按鈕開始", vm.StatusMessage);
        Assert.True(vm.IncrementCommand.CanExecute(null));
        Assert.True(vm.ResetCommand.CanExecute(null));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(998)]
    public void IncrementCountsEachActivationOnce(int times)
    {
        var vm = new MainWindowViewModel();
        for (var i = 0; i < times; i++)
            vm.IncrementCommand.Execute(null);
        Assert.Equal(times, vm.Count);
        Assert.Equal("已增加 1 次", vm.StatusMessage);
        Assert.True(vm.IncrementCommand.CanExecute(null));
    }

    [Fact]
    public void LimitDisablesIncrementAndRejectsDirectExecution()
    {
        var vm = new MainWindowViewModel();
        for (var i = 0; i < 999; i++)
            vm.IncrementCommand.Execute(null);
        Assert.Equal(999, vm.Count);
        Assert.Equal("已達上限 999 次", vm.StatusMessage);
        Assert.False(vm.IncrementCommand.CanExecute(null));
        for (var i = 0; i < 10; i++)
            vm.IncrementCommand.Execute(null);
        Assert.Equal(999, vm.Count);
        Assert.Equal("已達上限 999 次", vm.StatusMessage);
        Assert.True(vm.ResetCommand.CanExecute(null));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(999)]
    public void ResetAlwaysWorksAndRestoresIncrement(int times)
    {
        var vm = new MainWindowViewModel();
        for (var i = 0; i < times; i++)
            vm.IncrementCommand.Execute(null);
        vm.ResetCommand.Execute(null);
        Assert.Equal(0, vm.Count);
        Assert.Equal("已重設為 0", vm.StatusMessage);
        Assert.True(vm.IncrementCommand.CanExecute(null));
        Assert.True(vm.ResetCommand.CanExecute(null));
        vm.IncrementCommand.Execute(null);
        Assert.Equal(1, vm.Count);
        Assert.Equal("已增加 1 次", vm.StatusMessage);
    }

    [Fact]
    public void BindingsReceiveStateAndCommandNotifications()
    {
        var vm = new MainWindowViewModel();
        var properties = new List<string?>();
        var availability = new List<bool>();
        vm.PropertyChanged += (_, e) => properties.Add(e.PropertyName);
        vm.IncrementCommand.CanExecuteChanged += (_, _) => availability.Add(vm.IncrementCommand.CanExecute(null));
        vm.IncrementCommand.Execute(null);
        Assert.Contains(nameof(vm.Count), properties);
        Assert.Contains(nameof(vm.StatusMessage), properties);
        for (var i = 1; i < 999; i++)
            vm.IncrementCommand.Execute(null);
        Assert.False(availability[^1]);
        properties.Clear();
        vm.ResetCommand.Execute(null);
        Assert.True(availability[^1]);
        Assert.Contains(nameof(vm.Count), properties);
        Assert.Contains(nameof(vm.StatusMessage), properties);
    }

    [Fact]
    public void NewInstanceDoesNotRetainPreviousCount()
    {
        var vm = new MainWindowViewModel();
        vm.IncrementCommand.Execute(null);
        Assert.Equal(0, new MainWindowViewModel().Count);
    }
}
