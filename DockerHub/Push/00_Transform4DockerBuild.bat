xcopy /Y /E "..\..\MVC_Sample\MVC_Sample" "MVC_Sample\"
xcopy /Y /E "..\..\MVC_Sample\files" "MVC_Sample\files\"
xcopy /Y /E "..\..\MVC_Sample\OpenTouryoAssemblies\Build_netcore30" "MVC_Sample\Assemblies\"
copy /Y "..\..\MVC_Sample\files\resource\X509\SHA256RSA_Server.cer" "MVC_Sample\X509\SHA256RSA_Server.cer"
copy /Y ".\MVC_Sample.csproj" "MVC_Sample\MVC_Sample.csproj"
copy /Y ".\appsettings.json" "MVC_Sample\appsettings.json"
del /Q "MVC_Sample\Dockerfile"