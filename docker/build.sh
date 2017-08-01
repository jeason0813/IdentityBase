#!/bin/bash

DIR="$( cd "$( dirname "$0" )" && pwd )"

# prepare docker context
dotnet publish $DIR/../src/IdentityBase.Public/IdentityBase.Public.csproj -c Release -o $DIR/app

# build docker container
# docker build . -t docker.econduct.de/identitybase/identitybase
docker build . -t econduct/identitybase

# cleanup docker context
rm -rf $DIR/app
