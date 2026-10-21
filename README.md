# FreecadAI 工作目錄

本目錄目前保存 FreeCAD 模型、Python 腳本及匯出圖檔。新練習專案為「雙按鈕計數器」，使用 Windows／C#／Avalonia／.NET 10；需求已寫入 docs/REQUIREMENTS.md，程式尚未實作。

## 文件入口

- [AI 工作規則](AGENTS.md)：自主開發、測試、修正與 GitHub 推送。
- [功能需求](docs/REQUIREMENTS.md)：功能範圍、驗收條件與待確認問題。
- [程式架構](docs/ARCHITECTURE.md)：技術、分層與預定目錄。
- [工作進度](docs/TASKS.md)：已完成、待辦與阻礙。

Codex 與 Antigravity 共用根目錄 AGENTS.md。開始開發時可下達：

> 請閱讀 AGENTS.md 與 docs 下的專案文件，依本次需求自主實作、測試與修正；驗證通過後依已設定的 GitHub 目的地提交並推送，回報結果與阻礙。

## 專案設定

| 項目 | 設定 |
| --- | --- |
| 正式應用程式名稱 | 雙按鈕計數器（TwoButtonPractice） |
| 產品用途 | 練習增加與重設計數，以及 AI 開發與驗證流程 |
| GitHub 儲存庫 URL | 待填 |
| Git 遠端名稱 | origin |
| 預設開發分支 | 待確認 |
| Solution 路徑 | TwoButtonPractice.sln |
| 桌面應用專案路徑 | src/TwoButtonPractice/TwoButtonPractice.csproj |
| 測試專案路徑與執行器 | tests/TwoButtonPractice.Tests；xUnit／VSTest |

2026-10-21 實作狀態：雙按鈕計數器已以 .NET 9 實作，Release 建置及 11 個測試通過，部分 UI 縮放驗收待完成，詳見 docs/TASKS.md。本次已核對 Git 遠端為 https://github.com/huhua-info/TwoButtonPractice.git，使用者指定推送 origin/main。不要將 Token 寫入文件或遠端 URL。

## 開發環境

- Windows 與 PowerShell。
- .NET 9 SDK 9.0.317（global.json 固定版本；依本次使用者授權採用）。
- Git for Windows；GitHub 認證與推送權限。
- Avalonia 11.3.12、CommunityToolkit.Mvvm 8.4.0，版本固定於 csproj。

可先檢查：

```powershell
dotnet --list-sdks
git --version
```

使用 GitHub CLI 管理認證時，可執行 `gh auth login` 與 `gh auth setup-git`。

## 建置、測試與啟動

在儲存庫根目錄執行：

```powershell
dotnet restore TwoButtonPractice.sln
dotnet build TwoButtonPractice.sln -c Release --no-restore
dotnet test TwoButtonPractice.sln -c Release --no-build
dotnet run --project src/TwoButtonPractice/TwoButtonPractice.csproj -c Release --no-build
```

按「增加次數」累加至 999；「重設」歸零並恢復增加。Tab 移動焦點、Space 操作，關閉後不保存計數。

`.gitignore` 排除常見建置輸出與本機秘密；既有 CAD 模型、圖片及腳本仍保留。若之後兩個 AI 同時開發，使用各自的工作目錄／worktree 與分支，避免互相覆蓋。
