using System.Management.Automation;
using System.Management.Automation.Runspaces;

var app = WebApplication.CreateBuilder(args).Build();

// Visit the home page -> C# runs PowerShell -> lists installed software
app.MapGet("/", () =>
{
    var iss = InitialSessionState.CreateDefault2();
    iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Bypass;

    using var ps = PowerShell.Create(iss);
    ps.AddScript(@"
        $paths = 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\*',
                 'HKLM:\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\*',
                 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\*'

        Get-ItemProperty -Path $paths -ErrorAction SilentlyContinue |
            Where-Object DisplayName |
            Sort-Object DisplayName -Unique |
            ForEach-Object { ""$($_.DisplayName)  $($_.DisplayVersion)"" }
    ");

    var results = ps.Invoke().Select(r => r.ToString());
    return "Installed software on this machine:\n\n" + string.Join("\n", results);
});

app.Run();