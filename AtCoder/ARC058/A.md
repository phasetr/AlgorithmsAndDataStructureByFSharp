# README
- <https://atcoder.jp/contests/arc058/tasks/arc058_a>
## C - こだわり者いろはちゃん / 問題文
いろはちゃんはこだわりもので、嫌いな数字が K 個あり、
それぞれ D1​,D2​,...,DK​ です。

いろはちゃんはお店でお買い物をしていて、N 円の品物を買おうとしています。
もちろん、この品物は N 円以上のお金を支払えば買うことができます。
しかし、先ほど述べたようにいろはちゃんは強いこだわりがあるので、
自分がお店に支払う金額の 10 進表記にいろはちゃんの嫌いな数字が出現しないような最も少ない金額を支払おうとします。

いろはちゃんが支払う金額を求めてください。
## 制約
- 1≦N<10000
- 1≦K<10
- 0≦D1​<D2​<…<DK​≦9
- {D1​,D2​,...,DK​} \neq {1,2,3,4,5,6,7,8,9}
## 入力
入力は以下の形式で標準入力から与えられる。

```
N K
D1 D2​ … DK
```
## 出力
いろはちゃんが支払う金額を出力せよ。
## 入力例 1
```
1000 8
1 3 4 5 6 7 8 9
```
## 出力例 1
```
2000
```

嫌いでない数字は 0 と 2 のみです。
N=1000 以上の整数で、桁に 0 と 2 のみが含まれる最小の整数は 2000 なのでそれを出力してください。
## 入力例 2
```
9999 1
0
```
## 出力例 2
```
9999
```