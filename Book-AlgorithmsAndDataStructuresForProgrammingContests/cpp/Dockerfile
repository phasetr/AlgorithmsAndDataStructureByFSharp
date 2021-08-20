FROM alpine:latest
RUN apk update && \
    apk add --no-cache make gcc libc-dev g++

ARG HOMEDIR="/home/cpp"
ENV HOME ${HOMEDIR}

