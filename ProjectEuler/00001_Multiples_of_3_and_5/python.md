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
    display_name: Python 3
    language: python
    name: python3
---

# Multiples of 3 and 5


## バージョン確認

```python
import sys
print(sys.version)
```

## Problem 1
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000.

> 1000 未満の 3 と 5 の倍数のすべての和を計算せよ。


## 方針またはプログラミング基礎


### 方針1
まずは1000未満の3の倍数と5の倍数を全部作ってみる。ただ、1000だと結果が見づらいので、`n=30`くらいにして見やすくする。

```python
# 本来の値
N = 1000
```

```python
n = 30
threes = []
for i in range(n):
    if i % 3 == 0:
        threes.append(i)

print(threes)
```

```python
fives = []
for i in range(n):
    if i % 5 == 0:
        fives.append(i)

print(fives)
```

このふたつのリストには重複がある。
具体的には15の倍数が重複する。
何らかの方法でこの重複を処理したい。

方法はいくつかある。
最終的には効率・速度も考えないといけないが、ここではそこまでは要求しない。

一番簡単なのはリストを一気に作る方法か？

```python
numbers = []
for i in range(n):
    if i % 3 == 0 or i % 5 == 0:
        numbers.append(i)
print(numbers)
```

あとは和を取る。

```python
numbers = []
for i in range(n):
    if i % 3 == 0 or i % 5 == 0:
        numbers.append(i)
sum(numbers)
```

`n`を`N`に変えて計算してみよう。

```python
numbers = []
for i in range(N):
    if i % 3 == 0 or i % 5 == 0:
        numbers.append(i)
sum(numbers)
```

これで確かに解答が得られた。
[解答1](#解答1)として別途まとめておこう。


### 方針2
引き続き効率やスピード度外視で考えよう。
今度はリストではなく集合で作ってみる。

まずは3の倍数から。

```python
threes = set()
for i in range(n):
    if i % 3 == 0:
        threes.add(i)
print(threes)
```

変わったのは`threes = []`ではなく`set()`とした部分。
5の倍数も同じ。

```python
fives = set()
for i in range(n):
    if i % 5 == 0:
        fives.add(i)
print(fives)
```

わざと同じ流れにしたが、はじめからリストの時と同じように`if i % 3 ==0 or i % 5 == 0`で作ってもいい。
あえて同じ流れにしたのは集合には便利な演算がありそれを紹介するため。
このデータ構造は重複があると勝手に重複を一意化してくれる。

特に和集合を作る演算があるので、それでリストの時と同じく、必要なすべての数をリストアップした`numbers`を作ってみよう。
具体的には関数`union`か`|`演算子で和集合が作れる。

```python
numbers = threes | fives
print(numbers)
```

```python
sum(numbers)
```

`n`の時の値は配列版と一致した。
`N`に変えれば正しい値が出るだろう。
まとめて[解答2](#解答2)にしておこう。


## コードの単純化
アルゴリズムのレベルで他にもやりようはあるだろう。
ただパッと思いつかないので、とりあえずここではいくつかコードを簡素化してみる。
いったん全てリストで対応する。


### リスト内包表記
読みやすいかどうかといった問題もあるが、一般にPythonは`for`で書くよりもリスト内包表記で書く方が速くメモリ効率もいいとされているようなので、リスト内包表記を使ってみよう。

まずは比較用にもともとの`for`で作ったリストを準備する。

```python
threes1 = []
for i in range(N):
    if i % 3 == 0:
        threes1.append(i)
print(threes1)
```

```python
threes2 = [i for i in range (N) if i % 3 == 0]
print(threes1 == threes2)
```

`for`で書くと4行だったのが1行になった。
慣れていないと読みづらいのは間違いない。
あと`for`の中身が長いとそもそも書けたものではない。

```python
numbers = [i for i in range(N) if i % 3 == 0 or i % 5 == 0]
sum(numbers)
```

本来の答え（リストの和）が欲しいだけならもっと短く書ける。

```python
sum([i for i in range(N) if i % 3 == 0 or i % 5 == 0])
```

### 高階関数
例えば`filter`を使ってみよう。
`filter`は第一引数が関数で、第二引数に「リスト」を取る関数で、第一引数の関数の真偽に応じてリストの要素をふるいにかける（フィルターする）。

よくわからなければ具体的に挙動を見るのが早い。
例を作って確認しよう。

```python
def lt5(x):
    return x < 5

below1000 = range(N)
lessthan5 = filter(lt5, below1000)
print(list(lessthan5))
```

`lt5`は less than 5 の頭文字で、5より小さい数に対して`True`を返す。
そして`filter`には`True`を返してほしい関数と対象リストを渡している。

長い関数ならともかく、関数本体が短い場合、いちいち関数を定義するのが面倒な場合がある。
そういうときはラムダを使うといい。
これも例を見た方が早い。

```python
below1000 = range(N)
lessthan5 = filter(lambda x: x < 5, below1000)
print(list(lessthan5))
```

これを使って解答を作ってみよう。

```python
all = range(N)
numbers = filter(lambda x: x % 3 == 0 or x % 5 == 0, all)
sum(numbers)
```

このくらいのコードなら、次のようにもっとシンプルにしてもいいだろう。

```python
sum(filter(lambda x: x % 3 == 0 or x % 5 == 0, range(N)))
```

## 解答


### 解答1

```python
numbers = []
for i in range(1000):
    if i % 3 == 0 or i % 5 == 0:
        numbers.append(i)
sum(numbers)
```

### 解答2

```python
threes = set()
for i in range(1000):
    if i % 3 == 0:
        threes.add(i)

fives = set()
for i in range(1000):
    if i % 5 == 0:
        fives.add(i)

numbers = threes | fives
sum(numbers)
```

### 解答3

```python
sum([i for i in range(1000) if i % 3 == 0 or i % 5 == 0])
```

### 解答4

```python
sum(filter(lambda x: x % 3 == 0 or x % 5 == 0, range(1000)))
```
