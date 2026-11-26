# DailyApp

DailyApp 是一款 Windows 待办和备忘录应用。WPF 桌面客户端在 Windows 上运行，API 和 SQL Server Express 在本机的 Docker 容器中运行。

## 下载后使用

1. 在 Windows x64 电脑上安装并启动 Docker Desktop，选用 Linux 容器模式。
2. 从 [GitHub Releases](https://github.com/DustHuRuiChen/DailyApp/releases) 下载名称以 `DailyApp-Windows-x64-` 开头的 ZIP，把整个压缩包解压到同一个文件夹。
3. 双击 **Start-DailyApp.cmd**。首次启动会从 Microsoft 下载 SQL Server 镜像，请保持联网。脚本会导入随包提供的 API 镜像，生成数据库密码，建好数据表，然后打开登录窗口。
4. 第一次使用时在登录窗口注册自己的账号。客户端已包含 .NET 运行时，服务地址和数据库连接均已配置。

用完后关闭桌面窗口，双击 **Stop-DailyApp.cmd** 停止后台服务。下次从同一台电脑的 Docker Desktop 启动时，账号、待办和备忘录会从 Docker 数据卷中恢复。请保留 `dailyapp_dailyapp-sql-data` 和 `dailyapp_dailyapp-db-key` 两个卷。

API 绑定到本机 `127.0.0.1:33333`，请保持该端口空闲。运行中可打开 [API 接口页](http://localhost:33333/swagger)。如果启动脚本报错，可在解压目录运行 `docker compose logs --tail=50 db api` 查看原因。

## 从源码启动

在仓库根目录运行以下命令，Compose 会构建 API 镜像并等待数据库和 API 就绪。

```powershell
docker compose up --build -d --wait
```

安装 .NET SDK 的 Windows 开发机可以直接运行 WPF 项目。

```powershell
dotnet run --project DailyApp.WPF/DailyApp.WPF/DailyApp.WPF.csproj
```

源码沿用原项目的 .NET 6 目标框架。下载运行包适用于本机单机使用。
