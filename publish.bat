@echo off

set runtime=win-x64
set mode=framework-dependent

:parse_args
if "%1"=="" goto done_args
if "%1"=="linux" set runtime=linux-x64
if "%1"=="linux32" set runtime=linux-x86
if "%1"=="windows" set runtime=win-x64
if "%1"=="windows32" set runtime=win-x86
if "%2"=="self-contained" set mode=self-contained
shift
goto parse_args

:done_args

echo Compiling to %runtime% as %mode%

if "%mode%"=="self-contained" (
    dotnet publish -r %runtime% --self-contained true -p:PublishSingleFile=true
) else (
    dotnet publish -r %runtime% --self-contained false -p:PublishSingleFile=true
)

echo Successfully compiled to %runtime%
