@echo off
echo Would you like to push the packages to NuGet when finished?
set /p choice="Enter y/n: "

del *.nupkg
@echo on
".nuget/nuget.exe" pack Zlib.Portable.nuspec -symbols
".nuget/nuget.exe" pack Zlib.Portable.Signed.nuspec -symbols
if /i %choice% equ y (
    ".nuget/nuget.exe" push Zlib.Portable.*.nupkg
    ".nuget/nuget.exe" push Zlib.Portable.Signed.*.nupkg
)
pause