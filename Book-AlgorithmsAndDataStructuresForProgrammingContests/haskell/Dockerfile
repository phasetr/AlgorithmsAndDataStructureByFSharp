FROM haskell:latest

ARG HOMEDIR="/home/hs"
ENV HOME ${HOMEDIR}

#RUN curl -sSL https://get.haskellstack.org/ | sh
# stackインストール
RUN stack upgrade
RUN stack --version
# stack の初期設定
RUN stack setup
