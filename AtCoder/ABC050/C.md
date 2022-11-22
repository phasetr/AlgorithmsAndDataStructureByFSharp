# README
- <https://atcoder.jp/contests/abc050/tasks/arc066_a>
## C - Lining Up / 問題文
1～N までの番号がついた、N 人の人がいます。
彼らは昨日、ある順番で左右一列に並んでいましたが、
今日になってその並び方が分からなくなってしまいました。
しかし、彼らは全員、「自分の左に並んでいた人数と自分の右に並んでいた人数の差の絶対値」を覚えています。
彼らの報告によると、人 i の、
「自分の左に並んでいた人数と自分の右に並んでいた人数の差の絶対値」は Ai​ です。

彼らの報告を元に、元の並び方が何通りあり得るかを求めてください。
ただし、答えは非常に大きくなることがあるので、10^9+7 で割った余りを出力してください。
また、彼らの報告が間違っており、ありうる並び方がないこともありえます。
その際は 0 を出力してください。
## 制約
- 1≦N≦10^5
- 0≦Ai​≦N−1
## 入力
入力は以下の形式で標準入力から与えられる。

```
N

A1 A2 ... AN
```
## 出力
元の並び順としてありうるものが何通りあるか求め、
10^9+7 で割った余りを出力せよ。
## 入力例 1
```
5
2 4 4 0 2
```
## 出力例 1
```
4
```

ありうる並び方は、人の番号で書くと、

- 2,1,4,5,3
- 2,5,4,1,3
- 3,1,4,5,2
- 3,5,4,1,2

の4 通りです。
## 入力例 2
```
7
6 4 0 2 4 0 2
```
## 出力例 2
```
0
```

どのような並び方でも、報告と矛盾するので、0 が答えになります。
## 入力例 3
```
8
7 5 1 1 7 3 5 3
```
## 出力例 3
```
16
```