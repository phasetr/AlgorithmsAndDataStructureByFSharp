# README
- <https://atcoder.jp/contests/diverta2019/tasks/diverta2019_c>
## C - AB Substrings / 問題文
すぬけ君は N 個の文字列を持っています。
i 番目の文字列は si​ です。

これらの文字列を好きな順序で並べたあと、連結して1 つの文字列を作ることを考えます。
作った文字列に AB という部分文字列が含まれる個数としてありうる値のうち、最大値を求めてください。
## 制約
- 1≤N≤10^4
- 2≤∣si​∣≤10
- si​ は英大文字のみからなる
## 入力
入力は以下の形式で標準入力から与えられる。

```
N
s1
⋮
sN
```
## 出力
答えを出力せよ。
## 入力例 1
```
3
ABCA
XBAZ
BAD
```
## 出力例 1
```
2
```

例えば、ABCA, BAD, XBAZ の順で連結して ABCABADXBAZ を作ったとき、AB という部分文字列は 2 つ含まれます。
## 入力例 2
```
9
BEWPVCRWH
ZZNQYIJX
BAVREA
PA
HJMYITEOX
BCJHMRMNK
BP
QVFABZ
PRGKSPUNA
```
## 出力例 2
```
4
```
## 入力例 3
```
7
RABYBBE
JOZ
BMHQUVA
BPA
ISU
MCMABAOBHZ
SZMEHMA
```
## 出力例 3
```
4
```
