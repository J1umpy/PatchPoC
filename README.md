# PatchPOC

Proof of concept for Windows third-party patching tool.
This app shows that C# / ASP.NET Core can run PowerShell through the PowerShell SDK and read installed software from windows registry.

## Tech Stack
- Language: C#
- FrameworkL ASP.NET Core (.NET 10)
- Library: Microsoft.Powershell.SDK 7.6.6

## Test Environment
- OS: Windows 11 Pro 25H2
- .NET SDK: 10.0.401

## Prerequisites
- Windows 10/11
- .NET 10 SDK: https://dotnet.microsoft.com/download/dotnet/10.0

## Build and Run
```powershell
git clone https://github.com/J1umpy/PatchPoC
cd PatchPoC
dotnet build
dotnet run
```

Open the `http://localhost:XXXX` address shown in the terminal.
The page lists installed software (64-bit, 32-bit, and per-user) with versions.
Press Ctrl+C to stop.