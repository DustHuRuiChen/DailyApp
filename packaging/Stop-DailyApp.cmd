@echo off
setlocal
pushd "%~dp0" || exit /b 1
docker compose -f docker-compose.yml down
set "result=%errorlevel%"
if not "%result%"=="0" pause
popd
exit /b %result%
