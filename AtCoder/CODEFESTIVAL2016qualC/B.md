# README
- <https://atcoder.jp/contests/code-festival-2016-qualc/tasks/codefestival_2016_qualC_b>
## B - K個のケーキ / 問題文
K 個のケーキがあります。
高橋君は、1日に一つずつ、
K 日かけてこれらのケーキを食べようと考えています。

ケーキは T 種類あり、種類i(1≦i≦T) のケーキは ai​ 個あります。
二日連続で同じ種類のケーキを食べると飽きてしまうため、
高橋君は、うまくケーキを食べる順番を決めて、前日と同じ種類のケーキを食べる日数を最小にしようと考えました。

高橋君のために前日と同じ種類のケーキを食べる日数の最小値を求めてください。
## 制約
- 1≦K≦10000,1≦T≦100
- 1≦ai​≦100
- a1​+a2​+...+aT​=K
## 入力
入力は以下の形式で標準入力から与えられる。

```
K T
a1​ a2​ ... aT
```
## 出力
前日と同じ種類のケーキを食べる日数の最小値を出力せよ。
## 入力例 1
```
7 3
3 2 2
```
## 出力例 1
```
0
```

ケーキは7個あります。例えば種類2,1,2,3,1,3,1の順で食べると一度も前日と同じ種類のケーキを食べなくてすみます。
## 入力例 2
```
6 3
1 4 1
```
## 出力例 2
```
1
```

ケーキは6個あります。
種類2,3,2,2,1,2の順で食べると4日目だけ前日と同じ種類2のケーキを食べることになり、
これが最小になるので答えは1です。
## 入力例 3
```
100 1
100
```
## 出力例 3
```
99
```
高橋君は一種類のケーキしか持っていないため、2日目以降は毎日前日と同じ種類のケーキを食べるしかありません。
