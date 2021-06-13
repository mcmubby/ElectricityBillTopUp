FROM mcr.microsoft.com/dotnet/sdk:5.0 AS Test

WORKDIR /app
COPY CustomerPortal/ ./CustomerPortal
COPY PortalLibrary ./PortalLibrary

RUN dotnet publish ./CustomerPortal/CustomerPortal.csproj -c Release -o out

ENTRYPOINT [ "dotnet", "./out/CustomerPortal.dll" ]