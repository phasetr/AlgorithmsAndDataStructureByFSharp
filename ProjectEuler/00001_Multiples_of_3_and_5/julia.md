---
jupyter:
  jupytext:
    formats: ipynb,md
    text_representation:
      extension: .md
      format_name: markdown
      format_version: '1.2'
      jupytext_version: 1.5.1
  kernelspec:
    display_name: Julia 1.5.2
    language: julia
    name: julia-1.5
---

# Multiples of 3 and 5


## バージョン情報

```julia
versioninfo()
```

## Problem 1
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000.

> 1000 未満の 3 と 5 の倍数のすべての和を計算せよ。


## 方針またはプログラミング基礎
凝ったことをしていないのでPythonとほとんど同じように考えられる。
PythonとJuliaでプログラムを読みかえるのも大変だろうから、重複をいとわず書くことにしよう。

JuliaにはJuliaの都合があって、高速化を考えるといくつか工夫が必要だが、まずはあまり気にせず書くことにする。
### 方針1
まずは1000未満の3の倍数と5の倍数を全部作ってみる。

```julia
threes = Vector{Int}(undef, 0)
for i in 1:999
    if i % 3 == 0 append!(threes, i) end
end

println(threes)
```

```julia
fives = Vector{Int}(undef, 0)
for i in 1:999
    if i % 5 == 0 append!(fives, i) end
end

print(fives)
```

このふたつのリストには重複がある。
具体的には15の倍数が重複する。
何らかの方法でこの重複を処理したい。

方法はいくつかある。
最終的には効率・速度も考えないといけないが、ここではそこまでは要求しない。

一番簡単なのはリストを一気に作る方法か？

```julia
numbers = Vector{Int}(undef, 0)
for i in 1:999 
    if i % 3 == 0 || i % 5 == 0 append!(numbers, i) end
end
print(numbers)
```

あとは和を取る。

```julia
numbers = Vector{Int}(undef, 0)
for i in 1:999 
    if i % 3 == 0 || i % 5 == 0 append!(numbers, i) end
end
sum(numbers)
```

これで確かに解答が得られた。
[解答1](#解答1)として別途まとめておこう。


### 方針2
引き続き効率やスピード度外視で考えよう。
今度はリストではなく集合で作ってみる。

まずは3の倍数から。

```julia
threes = Set{Int}()
for i in 1:999
    if i % 3 == 0 push!(threes, i) end
end
println(threes)
```

変わったのは`threes = []`ではなく`set()`とした部分。
5の倍数も同じ。

```julia
fives = Set{Int}()
for i in 1:999
    if i % 5 == 0 push!(fives, i) end
end
print(fives)
```

わざと同じ流れにしたが、はじめからリストの時と同じように`if i % 3 ==0 or i % 5 == 0`で作ってもいい。
あえて同じ流れにしたのは集合には便利な演算がありそれを紹介するため。
このデータ構造は重複があると勝手に重複を一意化してくれる。

特に和集合を作る演算があるので、それでリストの時と同じく、必要なすべての数をリストアップした`numbers`を作ってみよう。
具体的には関数`union`か`∪`演算子で和集合が作れる。

```julia
numbers1 = union(threes, fives)
numbers2 = ∪(threes, fives)
numbers3 = threes ∪ fives
println(numbers1 == numbers2)
println(numbers1 == numbers3)
```

```julia
sum(numbers3)
```

これをまとめて[解答2](#解答2)にしておこう。


## コードの単純化
アルゴリズムのレベルで他にもやりようはあるだろう。
ただパッと思いつかないので、とりあえずここではいくつかコードを簡素化してみる。
いったん全てリストで対応する。


### リスト内包表記
読みやすいかどうかといった問題もあるが、一般にJuliaは`for`で書くよりもリスト内包表記で書く方が速くメモリ効率もいいとされているようなので、リスト内包表記を使ってみよう。

まずは比較用にもともとの`for`で作ったリストを準備する。

```julia
threes1 = Vector{Int}(undef, 0)
for i in 1:999
    if i % 3 == 0 append!(threes1, i) end
end
print(threes1)
```

```julia
threes2 = [i for i in 1:999 if i % 3 == 0]
print(threes1 == threes2)
```

`for`で書くと4行だったのが1行になった。
慣れていないと読みづらいのは間違いない。
あと`for`の中身が長いとそもそも書けたものではない。

```julia
numbers = [i for i in 1:999 if i % 3 == 0 || i % 5 == 0]
sum(numbers)
```

本来の答え（リストの和）が欲しいだけならもっと短く書ける。

```julia
sum([i for i in 1:999 if i % 3 == 0 || i % 5 == 0])
```

### 高階関数
例えば`filter`を使ってみよう。
`filter`は第一引数が関数で、第二引数に「リスト」を取る関数で、第一引数の関数の真偽に応じてリストの要素をふるいにかける（フィルターする）。

よくわからなければ具体的に挙動を見るのが早い。
例を作って確認しよう。

```julia
function lt5(x)
    return x < 5
end

below1000 = 1:999
lessthan5 = filter(lt5, below1000)
println(lessthan5)
```

`lt5`は less than 5 の頭文字で、5より小さい数に対して`True`を返す。
そして`filter`には`True`を返してほしい関数と対象リストを渡している。

ラムダの記法以外にも、Juliaは短い関数を簡単に書く記法があるのでまずはそれを紹介しよう。

```julia
lt5(x) = x < 5

below1000 = 1:999
lessthan5 = filter(lt5, below1000)
println(lessthan5)
```

長い関数ならともかく、関数本体が短い場合、いちいち関数を定義するのが面倒な場合がある。
そういうときはラムダを使うといい。
これも例を見た方が早い。

```julia
below1000 = 1:999
lessthan5 = filter(x -> x < 5, below1000)
print(lessthan5)
```

これを使って解答を作ってみよう。

```julia
all = 1:999
numbers = filter(x -> x % 3 == 0 || x % 5 == 0, all)
sum(numbers)
```

このくらいのコードなら、次のようにもっとシンプルにしてもいいだろう。

```julia
sum(filter(x -> x % 3 == 0 || x % 5 == 0, 1:999))
```

### パイプライン演算子
F#でも便利な演算子で、処理の流れが読みやすい。
単純な標準出力で比較してみよう。

```julia
println([1,2,3])
[1,2,3] |> println
```

関数が一つだけの場合は後者の方が面倒かもしれないが、`sum(filter(x -> x % 3 == 0 || x % 5 == 0, 1:999))`くらいの長さになってくるとパイプラインが読みやすくなる（ことがある）。
試してみよう。

```julia
div3or5(x) = x % 3 == 0 || x % 5 == 0
[1:999;] |> x -> filter(div3or5, x) |> sum
```

もちろん`div3or5`もラムダにできる。

```julia
[1:999;] |> x -> filter(n -> n % 3 == 0 || n % 5 == 0, x) |> sum
```

## 解答


### 解答1

```julia
numbers = Vector{Int}(undef, 0)
for i in 1:999 
    if i % 3 == 0 || i % 5 == 0 append!(numbers, i) end
end
sum(numbers)
```

### 解答2

```julia
threes = Set{Int}()
for i in 1:999
    if i % 3 == 0 push!(threes, i) end
end

fives = Set{Int}()
for i in 1:999
    if i % 5 == 0 push!(fives, i) end
end

numbers3 = threes ∪ fives
sum(numbers3)
```

### 解答3

```julia
sum([i for i in 1:999 if i % 3 == 0 || i % 5 == 0])
```

### 解答4

```julia
sum(filter(x -> x % 3 == 0 || x % 5 == 0, 1:999))
```

### 解答5

```julia
[1:999;] |> x -> filter(n -> n % 3 == 0 || n % 5 == 0, x) |> sum
```
