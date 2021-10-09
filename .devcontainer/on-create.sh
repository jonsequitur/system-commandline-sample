#!/bin/bash

echo "on-create start" >> ~/status

# run dotnet restore
dotnet restore src/scl.csproj

docker pull mcr.microsoft.com/dotnet/runtime:5.0-alpine
docker pull mcr.microsoft.com/dotnet/sdk:5.0

echo "on-create complete" >> ~/status
