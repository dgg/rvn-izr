# ensure release folder
New-Item -Type Directory release -Force

&.\tools\nuget\NuGet.exe pack -properties configuration=Release -build .\src\Rvn.Izr\Rvn.Izr.csproj -outputdirectory release