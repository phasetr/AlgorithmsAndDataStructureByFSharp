# README
- <https://atcoder.jp/contests/abc142/tasks/abc142_d>
## D - Disjoint Set of Common Divisors
## 問題文
正整数A,B が与えられます。

A とB の正の公約数の中からいくつかを選びます。

ただし、選んだ整数の中のどの異なる2 つの整数についても互いに素でなければなりません。

最大でいくつ選べるでしょうか。
## 制約
- 入力は全て整数である。
- 1≤A,B≤10^{12}
## 入力
入力は以下の形式で標準入力から与えられる。

```
A B
```
## 出力
条件を満たすように選べる整数の個数の最大値を出力せよ。
## 入力例 1
```
12 18
```
## 出力例 1
```
3
```

12 と 18 の正の公約数は1,2,3,6 です。

1 と 2、2 と 3、3 と 1 は互いに素なので、1,2,3 を選ぶことができ、このときが最大です。
## 入力例 2
```
420 660
```
## 出力例 2
```
4
```
## 入力例 3
```
1 2019
```
## 出力例 3
```
1
```

1 と 2019 の正の公約数は1 しかありません。
