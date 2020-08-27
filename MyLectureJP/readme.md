# MyLectureJP

## Introduction

This directory contains my lecture note for algorithms and data structures in Japanese.
In the following we have only Japanese documents.

## 前提

基本的にはデータ構造とアルゴリズムを `F#` で議論していきます。
それ以外にも予備知識があまり必要がない中高数学ネタもカバーしていきます。
適宜[AtCoder](https://atcoder.jp/)、[AOJ](http://judge.u-aizu.ac.jp/)、[Project Euler](https://projecteuler.net/) の問題なども解説する予定です。
必要に応じて `Haskell`、`Python`、`C++` なども紹介するかもしれません。

基本方針としてファイルは `fsx` で作り、`jupytext` で `ipynb` に変換して配布することにします。
少なくとも [binder のこのページ](https://mybinder.org/v2/gh/dotnet/try/master?urlpath=lab)からローカルでの環境整備なしに、
オンラインで `F#` が実行できます。
`ipynb` をここにアップしてもらい、そこで `F#` を使い倒してもらう想定です。

## 参考

`Python` による数学・物理・プログラミング系コンテンツがあります。

- [プログラミングで数学を 中高数学虎の穴](https://phasetr.com/mthlp1/)

詳しいことは上記案内ページに書いてあります。
興味があればぜひ受講してみてください。
これを書いている時点では無料で公開していますが、
じきに有料コンテンツにする予定です。

## 調査中

Microsoft の Azure と Onedrive などを使って,
Google Colaboratory と GoogleDrive のような連携ができるような
Microsoft のサービスがあると便利なのですが、そのような都合のいいサービスはあるでしょうか？
ご存知の方は教えてください。

## 検討中のこと

AtCoder やら AOJ やらも使う予定なので微妙なところなのですが、
このコンテンツをもとに有料の講座ができないか検討しています。
GitHub にあげているくらいですし、
コンテンツ自体は無料で公開します。
これまでの経験から、
自発的にゴリゴリ独学で勉強していける人ばかりではないのはわかっています。
そうした人たちに向けた教育サービスも需要があるだろうと思っています。
むしろ有料版はこのコンテンツで鍛えたアルゴリズムや基本的な実装力をもとにしつつ、
必要があれば復習を入れながら別のテーマを議論することを考えています。
たとえば数論や組み合わせ論に関する基本的な数学学習でもいいでしょうし、
離散数学を含めた応用向けの内容でもいいでしょう。

しばらくはコンテンツ作成をしつつ私自身の理解を深めるフェーズなので、
データ構造とアルゴリズム自体の教育サービスははじめられませんが、
ご興味ある方は適当な手段でご連絡ください。
一緒にコンテンツを作っていきましょう。
たとえば[私のサイト](https://phasetr.com/)のお問い合わせがあります。

## jupytext による実行済み ipynb 生成

大まかに言って次のコマンドで生成できます。

```sh
# pip install jupytext --upgrade
ls | grep ".*.fsx" | xargs jupytext --to notebook --execute
```
