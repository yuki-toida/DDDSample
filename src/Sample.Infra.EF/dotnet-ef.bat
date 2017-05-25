@setlocal
@echo off

dotnet restore

set Connection="Server=(localdb)\Gaia;Database=Gaia;Trusted_Connection=True;"
set Provider=Microsoft.EntityFrameworkCore.SqlServer
dotnet ef dbcontext scaffold %Connection% %Provider% -o Model -c GaiaDbContext -f

@endlocal
pause
