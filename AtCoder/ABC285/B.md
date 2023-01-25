# README
- <https://atcoder.jp/contests/abc285/tasks/abc285_b>
## 問題文
英小文字からなる長さ N の文字列 S が与えられます。
S の x 文字目 (1≤x≤N) は Sx​ です。
i=1,2,…,N−1 それぞれについて、
以下の条件を全て満たす最大の非負整数 l を求めてください。

- l+i≤N である。
- 全ての1≤k≤l を満たす整数 k について、 Sk/=Sk+i​ を満たす。

なお、l=0 は常に条件を満たすことに注意してください。
## 制約
- N は2≤N≤5000 を満たす整数
- S は英小文字からなる長さ N の文字列
## 入力
入力は以下の形式で標準入力から与えられる。

```
N
S
```
## 出力
N−1 行にわたって出力せよ。
そのうち x 行目 (1≤x<N) にはi=x とした場合の答えを整数として出力せよ。
## 入力例 1
```
6
abcbac
```
## 出力例 1
```
5
1
2
0
1
```

この入力では、S= abcbac です。

- i=1 のとき、 S1​=S2​,S2​=S3​,…,S5​=S6​ であるため、 最大値はl=5 です。
- i=2 のとき、 S1​=S3​ ですが S2​=S4​ であるため、 最大値はl=1 です。
- i=3 のとき、 S1​=S4​,S2​=S5​ ですが S3​=S6​ であるため、 最大値はl=2 です。
- i=4 のとき、 S1​=S5​ であるため、 最大値はl=0 です。
- i=5 のとき、 S1​=S6​ であるため、 最大値はl=1 です。