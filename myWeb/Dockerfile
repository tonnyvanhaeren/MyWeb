FROM registry.access.redhat.com/dotnet/dotnet-20-runtime-rhel7

ADD bin/release/netcoreapp2.0/rhel.7-x64/publish/. /app/

WORKDIR /app/

EXPOSE 5001

CMD ["scl", "enable", "rh-dotnet20", "--", "dotnet",  "myWeb.dll"]