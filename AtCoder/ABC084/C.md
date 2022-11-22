# README
- <https://atcoder.jp/contests/abc084/tasks/abc084_c>
## C - Special Trains / 問題文
Atcoder国に、1 本の東西方向に走る鉄道が完成しました。

この鉄道にはN 個の駅があり、西から順に 1,2,...,N の番号がついています。
明日、鉄道の開通式が開かれます。
この鉄道では、1≦i≦N−1 を満たす全ての整数 i に対して、
駅 i から駅 i+1 に、Ci​ 秒で向かう列車が運行されます。
ただし、これら以外の列車は運行されません。

駅i から駅 i+1 に移動する列車のうち最初の列車は、
開通式開始 Si​ 秒後に駅 i を発車し、その後は Fi​ 秒おきに駅 i を発車する列車があります。

また、Si​ はFi​ で割り切れることが保証されます。

つまり、A％B で A を B で割った余りを表すとき、
Si​≦t,t％Fi​=0 を満たす全ての t に対してのみ、
開通式開始 t 秒後に駅 i を出発し、開通式開始 t+Ci​ 秒後に駅i+1 に到着する列車があります。

列車の乗り降りにかかる時間を考えないとき、
全ての駅i に対して、開通式開始時に駅 i にいる場合、
駅N に到着できるのは最も早くて開通式開始何秒後か、答えてください。
## 制約
- 1≦N≦500
- 1≦Ci​≦100
- 1≦Si​≦10^5
- 1≦Fi​≦100
- Si​％Fi​=0
- 入力は全て整数
## 入力
入力は以下の形式で標準入力から与えられる。

```
N
C1​ S1​ F1
:
C_{N−1} S_{N−1​} F_{N−1​}
```
## 出力
i 行目 (1≦i≦N) に、
開通式開始時に駅 i にいる場合、
駅 N に到着できるのが最も早くて開通式開始 x 秒後のとき、x を出力せよ。
## 入力例 1
```
3
6 5 1
1 10 1
```
## 出力例 1
```
12
11
0
```

駅1 からは、以下のように移動します。

- 開通式開始 5 秒後に、駅2 に向かう列車に乗る。
- 開通式開始 11 秒後に、駅2 に到着する。
- 開通式開始 11 秒後に、駅3 に向かう列車に乗る。
- 開通式開始 12 秒後に、駅3 に到着する。

駅2 からは、以下のように移動します。

- 開通式開始 10 秒後に、駅3 に向かう列車に乗る。
- 開通式開始 11 秒後に、駅3 に到着する。

駅3 に対しても、
0 を出力しなければならないことに注意してください。
## 入力例 2
```
4
12 24 6
52 16 4
99 2 2
```
## 出力例 2
```
187
167
101
0
```
## 入力例 3
```
4
12 13 1
44 17 17
66 4096 64
```
## 出力例 3
```
4162
4162
4162
0
```