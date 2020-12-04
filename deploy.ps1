$env:Path += ";C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin"
dotnet build --configuration Release
xcopy /I /Y .\Keyworder\bin\Release\netcoreapp3.1 ..\..\Tools\Keyworder /EXCLUDE:EXCLUDE