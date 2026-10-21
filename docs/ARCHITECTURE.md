# 程式架構

## 目前狀態

此文件描述「雙按鈕計數器」（TwoButtonPractice）的初始設計方向。尚無 C# 專案或已驗證的應用程式架構。現有 Python 與 FreeCAD 檔案保留，不納入本次練習。

本次只需 MainWindow 與 MainWindowViewModel：ViewModel 提供計數、狀態訊息、增加命令與重設命令，View 負責繫結與顯示。計數僅保留於記憶體，無須建立 Model、Service 或資料庫。以下分層說明供未來擴充參考，目錄按需建立。

## 技術方向

| 項目 | 選擇與狀態 |
| --- | --- |
| 開發環境 | Windows、PowerShell |
| 語言／平台 | C#、.NET 10 |
| UI | Avalonia；套件版本初始化時確認 |
| 架構 | MVVM |
| MVVM 套件 | 新專案預設 CommunityToolkit.Mvvm |
| TargetFramework | 預設 net10.0；Windows 專用需求另行評估 |
| SDK | 初始化時用 global.json 固定實際可用版本 |
| 資料儲存 | 僅記憶體；關閉即清除 |
| 測試框架與執行器 | 初始化時選定並記錄 |

## 預定目錄（尚未建立）

```text
src/
  <AppName>/
    Views/
    ViewModels/
    Models/
    Services/
    Assets/
tests/
  <AppName>.Tests/
```

AppName 使用 TwoButtonPractice；本次只建立所需的 Views、ViewModels 與測試，不建立沒有用途的空架構。

## 分層責任

- Views：AXAML、資料繫結與必要 UI 互動，不包含商業邏輯或直接檔案存取。
- ViewModels：畫面狀態、命令、輸入驗證與 Service 呼叫，不直接操作控制項。
- Models：資料結構與領域規則，不依賴 Avalonia。
- Services：檔案、外部服務與應用程式操作；透過適當介面讓 ViewModel 可測試。

典型資料流程：View → ViewModel → Service → 儲存或外部系統；結果透過 ViewModel 狀態回到畫面。

## 實作約束

- I/O 使用非同步方法；UI 更新於正確執行緒。
- Nullable 啟用；錯誤須轉為適當提示與紀錄，不吞例外。
- 依需求建立抽象，不為形式拆分過多專案或介面。
- 套件版本固定並保持相容，不引用不存在的 API。
- 若採用檔案儲存，定義格式版本與儲存失敗時保護原檔的策略。
- 若需 FreeCAD 整合，另記錄程序啟動、通訊方式、相依版本、逾時與錯誤處理；未確認前不假設內嵌或外部程序方案。

## 驗證分工

- Model：資料及領域規則。
- ViewModel：命令、狀態轉換、驗證與失敗提示。
- Service：成功、錯誤與資料保存情境；檔案測試使用隔離的暫存位置。
- UI：主要操作流程、縮放、文字截斷及回應性。

## 設計決策紀錄

目前只有技術方向，尚無已完成實作的設計決策。後續重大變更記錄日期、原因、採用方案與影響，並同步更新本文件及 README 的操作指令。
