# README
- <https://atcoder.jp/contests/abc147/tasks/abc147_d>
## D - Xor Sum 4 / 問題文
N 個の整数があり、i 番目の整数は A_i です。

$\sum_{i=1}^{N-1}\sum_{j=i+1}^{N} (A_i \text{ XOR } A_j)$ を 10^9+7 で割った余りを求めてください。
### `XOR` とは
整数 A, B のビットごとの排他的論理和 a \text{ XOR } b は、以下のように定義されます。

* a \text{ XOR } b を二進表記した際の 2^k (k \geq 0) の位の数は、A, B を二進表記した際の 2^k の位の数のうち一方のみが 1 であれば 1、そうでなければ 0 である。

例えば、3 \text{ XOR } 5 = 6 となります (二進表記すると: 011 \text{ XOR } 101 = 110)。
## 制約
* 2 \leq N \leq 3 \times 10^5
* 0 \leq A_i < 2^{60}
* 入力中のすべての値は整数である。
## 入力
入力は以下の形式で標準入力から与えられる。

```
N
A_1 A_2 ... A_N
```
## 出力
$\sum_{i=1}^{N-1}\sum_{j=i+1}^{N} (A_i \text{ XOR } A_j)$ を 10^9+7 で割った余りを出力せよ。
## 入力例 1
```
3
1 2 3
```
## 出力例 1
```
6
```

(1\text{ XOR } 2)+(1\text{ XOR } 3)+(2\text{ XOR } 3)=3+2+1=6 となります。
## 入力例 2
```
10
3 1 4 1 5 9 2 6 5 3
```
## 出力例 2
```
237
```
## 入力例 3
```
10
3 14 159 2653 58979 323846 2643383 27950288 419716939 9375105820
```
## 出力例 3
```
103715602
```

和を 10^9+7 で割った余りを出力してください。