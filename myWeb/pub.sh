# publish a release version togetter with the runtime release. runtime release not needed in taget image
# using redhat image rhel7.4-x64 for now

dotnet publish -c Release -r rhel.7.4-x64