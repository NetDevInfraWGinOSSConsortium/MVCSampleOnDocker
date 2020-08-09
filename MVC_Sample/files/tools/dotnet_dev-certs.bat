if exist aspnetapp.pfx (
  echo ファイルが存在しています。
)
else (
  dotnet dev-certs https -ep aspnetapp.pfx -p seigi@123
  dotnet dev-certs https --trust
)

copy aspnetapp.pfx ..\..\MVC_Sample\aspnetapp.pfx