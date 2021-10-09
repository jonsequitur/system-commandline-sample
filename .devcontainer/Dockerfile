# this image is built and updated weekly
# https://github.com/cse-labs/codespaces-images
FROM ghcr.io/cse-labs/dind:latest

# some images require specific values
ARG USERNAME=vscode
ENV PATH $PATH:/usr/local/go/bin

RUN apt-get update && \
    apt-get upgrade -y && \
    apt-get autoremove -y && \
    apt-get clean -y
