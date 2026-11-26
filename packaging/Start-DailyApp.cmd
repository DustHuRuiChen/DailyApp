@echo off
setlocal
pushd "%~dp0" || exit /b 1
if not exist "client\DailyApp.WPF.exe" (
  echo Extract the entire DailyApp ZIP before starting.
  goto :failed
)
docker version --format "{{.Server.Os}}" 2>nul | findstr /x /i "linux" >nul
if errorlevel 1 (
  echo Start Docker Desktop in Linux containers mode, then run this file again.
  goto :failed
)
docker image inspect dailyapp-api:2026-11-26 >nul 2>&1
if errorlevel 1 (
  docker load --input "dailyapp-api.tar.gz"
  if errorlevel 1 goto :failed
)
echo Starting DailyApp. The first run downloads SQL Server and creates your local database.
docker compose -f docker-compose.yml up --no-build -d --wait --wait-timeout 300
if errorlevel 1 goto :failed
start "" /D "%~dp0client" "%~dp0client\DailyApp.WPF.exe"
popd
exit /b 0

:failed
echo DailyApp could not start. See the message above. Press any key to close.
pause >nul
popd
exit /b 1
