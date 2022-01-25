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
- (NEW! 2020) [Bird, Gibbons, Algorithm Design with Haskell](https://www.cambridge.org/core/books/algorithm-design-with-haskell/824BE0319E3762CE8BA5B1D91EEA3F52).
  Now I reading this book (at 2022/1), and I am rewriting to F#!
  This book includes data structures, and is relatively easy to read.

Hence I decide to write codes by myself.

For my study and seminars I also contains programs by several languages other than F#,
e.g., C++, Python.

## Directory Structure

- AOJ: Codes for the contests in [AOJ](https://judge.u-aizu.ac.jp/onlinejudge/).
  This site also contains some fundamental algorithms and data structure codes in the form of problems,
  and is very good introductory one.
- AtCoder: Codes for the contests in [AtCoder](https://atcoder.jp/).
- DataStructures: Codes for data structures.
  I added comments for referenced sites, pages, book pages.
- Book-AlgorithmsAndDataStructuresForProgrammingContests:
  Codes for [this book](https://tatsu-zine.com/books/algorithm-and-datastructure).
- Library: Codes for important processes.

## References

I know their names, but I do not read them thoroughly.

### F# references

- [GitHub: F# Core Library Documentation (community edition)](https://fsharp.github.io/fsharp-core-docs)
- [F# を知ってほしい (in Japanese), by cannorin](https://qiita.com/cannorin/items/59d79cc9a3b64c761cd4)
- [docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/fsharp/)
  - [msdn, visual fsharp](https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/visual-fsharp)
- [F# for fun and profit](https://fsharpforfunandprofit.com/)
- [Wikibook: F# Programming](https://en.wikibooks.org/wiki/F_Sharp_Programming)
- [Functional Programming Patterns](https://www.slideshare.net/ScottWlaschin/fp-patterns-ndc-london2014)
  - Descriptions on "Pattern: Chaining callbacks with continuation" from P.85 helps me very much.
  - `Monadic Bind`
- [Russel, Essential Functional-First F#](https://leanpub.com/essential-fsharp)

### Algorithms and data structures

- [Project Euler](https://projecteuler.net/)
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
  This site describes the F# implementation of the algorithms in Chris Okasaki's "Purely functional data structures".
- [FsProCon, AtCoder](https://github.com/natsukium/FsProCon/tree/master/src)
- [F# : Advanced Data Structures](https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures)
- [Open Data Structures](http://opendatastructures.org/)
  - [日本語ページ](https://sites.google.com/view/open-data-structures-ja)
  - [日本語ソースコード](https://github.com/spinute/ods)
- [幾何の計算にコンピュータを使う 易しくない 計算幾何学](https://www.nakanihon.co.jp/gijyutsu/Shimada/Computational%20geometry/index.html)
- [nobsun/ProjectEuler](https://github.com/nobsun/ProjectEuler) by Haskell
- [TheAlgorithms / Python](https://github.com/TheAlgorithms/Python)

## F# official

- [FSharpx.collections](https://github.com/fsprojects/FSharpx.Collections/tree/master/src/FSharpx.Collections)

## memo

### Sample codes
- [mathcodes](https://github.com/phasetr/mathcodes): by myself

### Useful pages in fsharpforfunandprofit.com

- [Understanding map and apply-A toolset for working with elevated worlds](https://fsharpforfunandprofit.com/posts/elevated-world/)

### Jargon Alert

From the book Domain Modeling Made Functional by Wlaschin.

- In the error-handling context,
  the bind function converts a Result-generating function into a two-track function.
  It’s used to chain Result-generating functions "in series."
  More generally, the bind function is a key component of a monad.
- In the error-handling context,
  the map function converts a one-track function into a two-track function.
- The monadic approach to composition refers to combining functions in series
  using bind.
- The applicative approach to composition refers to combining results in parallel.
