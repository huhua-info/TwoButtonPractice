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
| Git 遠端名稱 | origin（預定） |
| 預設開發分支 | 待確認 |
| Solution 路徑 | 待建立 |
| 桌面應用專案路徑 | 待建立 |
| 測試專案路徑與執行器 | 待建立／待選定 |

目前沒有 Git 儲存庫，故本次文件建立尚未 commit 或 push。確認 GitHub 網址、分支並完成登入後，才可設定實際推送目的地。不要將 Token 寫入文件或遠端 URL。

## 開發環境

- Windows 與 PowerShell。
- .NET 10 SDK（不是只有 Runtime）。
- Git for Windows；GitHub 認證與推送權限。
- Avalonia 套件版本於初始化專案時確認並固定。

可先檢查：

```powershell
dotnet --list-sdks
git --version
```

使用 GitHub CLI 管理認證時，可執行 `gh auth login` 與 `gh auth setup-git`。

## 建置、測試與啟動

尚無 .sln／.slnx／.csproj，因此目前沒有可執行的應用程式建置或測試指令。初始化完成後，請在此填入實際的套件還原、Release 建置、測試與啟動命令；測試命令須與所選執行器相容。

`.gitignore` 排除常見建置輸出與本機秘密；既有 CAD 模型、圖片及腳本仍保留。若之後兩個 AI 同時開發，使用各自的工作目錄／worktree 與分支，避免互相覆蓋。
