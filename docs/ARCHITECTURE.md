# 程式架構

更新日期：2026-10-21

## 技術與目錄

- C#、.NET 9（本次使用者允許取代 .NET 10），global.json 固定已安裝的 SDK 9.0.317。
- Avalonia.Desktop 與 Avalonia.Themes.Fluent 11.3.12。
- CommunityToolkit.Mvvm 8.4.0；Nullable 與 compiled bindings 啟用。
- Solution：TwoButtonPractice.sln。
- src/TwoButtonPractice：Program、App、Views/MainWindow 與 ViewModels/MainWindowViewModel。
- tests/TwoButtonPractice.Tests：xUnit 2.9.2、VSTest（Microsoft.NET.Test.Sdk 17.12.0、xunit.runner.visualstudio 2.8.2）。

## 設計

App 建立單一主視窗與新的 ViewModel。AXAML 以 x:DataType 宣告 compiled bindings，繫結計數、狀態訊息與兩個命令。Code-behind 僅初始化畫面。

MainWindowViewModel 繼承 ObservableObject，以私有 setter 維持 0～999 不變條件。增加命令提供 CanExecute；執行方法亦防護直接呼叫，避免超出上限。Count 變更通知畫面及命令可用狀態；StatusMessage 變更通知畫面。重設命令始終可用。

採用 Fluent 原生按鈕鍵盤操作與焦點外框，TabIndex 定義增加、重設順序。不增加自訂鍵盤事件，避免一次操作重複執行。計數僅存在每次啟動的新 ViewModel 中，無 Model、Service、儲存或網路存取。

## 驗證

11 個 ViewModel 測試涵蓋初始值、1／5／10／998 次增加、999 上限與直接呼叫防護、0／5／999 重設、重設後增加、屬性及命令通知、新實例初始值。實際 Windows UI 結果見 TASKS.md；自動化測試不取代顯示縮放驗收。

既有 FreeCAD 模型與 Python 腳本不納入本次應用程式，應繼續保留。
