@setlocal
@echo off

if "%1"=="" (
	set OutputPath=%CD%\bin
) else (
	set OutputPath=%1
)

echo %OutputPath%

for /f %%s in ('dir /b *.sln') do set Solution=%%s

dotnet restore
dotnet publish --output %OutputPath%

@endlocal
pause
