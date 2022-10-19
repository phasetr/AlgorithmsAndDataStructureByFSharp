# README
- <https://atcoder.jp/contests/abc148/tasks/abc148_e>
- E - Double Factorial
## 問題文
0 以上の整数 n に対し、f(n) を次のように定義します。

- f(n)=1 (n<2 のとき)
- f(n)=nf(n−2) (n≥2 のとき)

整数N が与えられます。
f(N) を 10 進法で表記した時に末尾に何個の0 が続くかを求めてください。
## 制約
- 0≤N≤10^{18}
## 入力
入力は以下の形式で標準入力から与えられる。

```
N
```
## 出力
f(N) を 10 進法で表記した時の末尾の0 の個数を出力せよ。
## 入力例 1
```
12
```
## 出力例 1
```
1
```

f(12)=12×10×8×6×4×2=46080 なので、末尾の 0 の個数は1 個です。
## 入力例 2
```
5
```
## 出力例 2
```
0
```

f(5)=5×3×1=15 なので、末尾の 0 の個数は0 個です。
## 入力例 3
```
1000000000000000000
```

## 出力例 3
```
124999999999999995
```