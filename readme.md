# Algorithms and Data Structures by (mainly) the F# language

## Motivation

I'd like to write codes for algorithms and data structures **by F#**.

We have many many books for them in **imperative or objective-oriented** languages,
but we have few books in functional languages.
We have some famous books in functional languages,
but they are difficult to me.
And, for some reasons, I'd like to study the themes by F#.
Some comments are here.

- Richard Bird, Pearls of Functional Algorithm Design, written by Haskell:
  This is very difficult and we meet many unusual themes in it.
  I'd like to study usual themes.
  Furthermore it treats only algorithms.
- Chris Okasaki, Purely Functional Data Structures, written by SML and Haskell:
  We have only data structure themes in this book,
  and small amount of them.
- Masood, Learning F# Functional Data Structures and Algorithms written by F#:
  The codes in this book is written by imperative style, I think.
  I'd like to study functional style algorithms.
- [vkostrykov, scalacaster](https://github.com/vkostyukov/scalacaster) written by Scala:
  Data structure objects seem to be mutable objects.
  I'd like to study immutable style.
- Rabhi and Lapalme, Algorithms A Functional Programming Approach written by Haskell:
  This looks more algorithms than others.

Hence I decide to write codes by myself.

For my study and seminars I also contains programms by several languages other than F#,
e.g., C++, Python.

## Directory Structure

- AtCoder: Codes for the contests in [AtCoder](https://atcoder.jp/).
- DataStructures: Codes for data structures.
  I added comments for referenced sites, pages, book pages.
- Book-AlgorithmsAndDataStructuresForProgrammingContests:
  Codes for [this book](https://tatsu-zine.com/books/algorithm-and-datastructure).

## References

I know their names, but I do not read them thoroughly.

- <https://github.com/vkostyukov/scalacaster>
- Rabhi, Lapalme, Algorithms A Functional Programming Approach
- Heineman, Pollice, Selkow, Algorithms in a Nutshell
- Richard Bird, Pearls of Functional Algorithm Design
- Skiena, The Algorithm Design Manual
- [Advanced Data Structures](https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures)
- (In Japanese) 紀平拓男、春日伸弥、プログラミングの宝箱 アルゴリズムとデータ構造 第 2 版
- (In Japanese) 渡部有隆, Ozy(協力), 秋葉 拓哉(協力), プログラミングコンテスト攻略のためのアルゴリズムとデータ構造, [for buying pdf](https://tatsu-zine.com/books/algorithm-and-datastructure)
  - [Support site (in Japanese)](https://book.mynavi.jp/support/pc/5295/)
  - [AOJ](http://judge.u-aizu.ac.jp/)
- [PENSE-MOI](http://lepensemoi.free.fr/index.php/tag/data-structure):
  This site describes the F# implementation of the algorithms in Chris Okazaki's "Purely functional data structures".
- [FsProCon, AtCoder](https://github.com/natsukium/FsProCon/tree/master/src)
- [F# : Advanced Data Structures](https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures)

## F# official

- [FSharpx.collections](https://github.com/fsprojects/FSharpx.Collections/tree/master/src/FSharpx.Collections)

## For AtCoder

### Benchmark (people)
- [cojna (Haskeller)](https://atcoder.jp/users/cojna/history)

### VSCode C++ setting (in Japanese)

- [reference site (in Japanese)](https://qiita.com/2019Shun/items/5ab290a4117a00e373b6)
- build: `Ctrl+Shift+B`
- debug: `F5`

#### install tools for ubuntu

```sh
sudo apt install build-essential gdb -y
```
