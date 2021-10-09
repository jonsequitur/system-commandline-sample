### Build and Test the App
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

### copy the source
COPY src /src

WORKDIR /src/app

# build the app
RUN dotnet publish -c Release -o /app

###########################################################


### Build the runtime container
FROM mcr.microsoft.com/dotnet/runtime:5.0-alpine AS release

WORKDIR /app

### create a user
### dotnet needs a home directory
RUN addgroup -S scl && \
    adduser -S scl -G scl && \
    mkdir -p /home/scl && \
    chown -R scl:scl /home/scl

### run as scl user
USER scl

### copy the app
COPY --from=build /app .

ENTRYPOINT [ "dotnet",  "scl.dll" ]
